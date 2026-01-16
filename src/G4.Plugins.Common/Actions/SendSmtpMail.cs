using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SendSmtpMail)}.json")]
    public class SendSmtpMail(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Build the SMTP configuration options from the plugin parameters.
            var options = NewOptions(pluginData);

            // Build the email request (recipients, subject, body, etc.)
            // from the plugin parameters.
            var request = NewRequest(pluginData);

            // Send the email.
            // This is executed synchronously to match the plugin execution model.
            // Error handling, logging, and retries are managed by PluginBase.
            SendSmtpMailAsync(options, request, cancellationToken: default)
                .GetAwaiter()
                .GetResult();

            // Return a standard response produced by the plugin framework.
            return this.NewPluginResponse();
        }

        #region *** Methods      ***
        // Creates a new SmtpOptions instance from the provided plugin data.
        // This method extracts SMTP-related configuration values such as host,
        // credentials, port, and security settings.
        private static SmtpOptions NewOptions(PluginDataModel pluginData)
        {
            // Retrieve the default sender address.
            // Used when no explicit "From" address is provided in the mail request.
            var defaultFrom = pluginData.Parameters.Get(
                key: "DefaultFrom",
                defaultValue: "no-reply@mail.io"
            );

            // Determine whether SSL/TLS should be enabled.
            // The presence of the key indicates that SSL is enabled.
            var enableSsl = pluginData.Parameters.ContainsKey(key: "EnableSsl");

            // Determine whether the "From" address should always be forced
            // to the default sender value.
            var forceFrom = pluginData.Parameters.ContainsKey(key: "ForceFrom");

            // Retrieve the SMTP server hostname or IP address.
            var host = pluginData.Parameters.Get(key: "Host", defaultValue: string.Empty);

            // Retrieve the password for SMTP authentication.
            // This is typically an app password or token.
            var password = pluginData.Parameters.Get(
                key: "Password",
                defaultValue: string.Empty);

            // Retrieve the SMTP port.
            // Common ports:
            //  - 587: STARTTLS (recommended)
            //  - 465: SSL
            //  - 25:  Plain (not recommended)
            var port = pluginData.Parameters.Get(key: "Port", defaultValue: 587);

            // Retrieve the SMTP username.
            // Often the same as the sender email address.
            var username = pluginData.Parameters.Get(key: "Username", defaultValue: string.Empty);

            // Construct and return the SMTP options object.
            return new SmtpOptions
            {
                DefaultFrom = defaultFrom,
                EnableSsl = enableSsl,
                ForceFrom = forceFrom,
                Host = host,
                Password = password,
                Port = port,
                Username = username
            };
        }

        // Creates a new SendMailRequest instance from the provided plugin data.
        // This method extracts mail-related parameters, parses recipient lists,
        // and maps them into a strongly-typed request object.
        private static SendMailRequest NewRequest(PluginDataModel pluginData)
        {
            // Configure string splitting behavior:
            // - Trim whitespace from each entry
            // - Remove empty entries
            const StringSplitOptions splitOptions =
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

            // Extract parameters from the plugin data model.
            // If a parameter is missing, fall back to an empty string.
            var bcc = pluginData.Parameters.Get(key: "Bcc", defaultValue: string.Empty);
            var cc = pluginData.Parameters.Get(key: "Cc", defaultValue: string.Empty);
            var from = pluginData.Parameters.Get(key: "From", defaultValue: string.Empty);
            var isBodyHtml = pluginData.Parameters.Get(key: "IsBodyHtml", defaultValue: false);
            var subject = pluginData.Parameters.Get(key: "Subject", defaultValue: string.Empty);
            var text = pluginData.Parameters.Get(key: "Text", defaultValue: string.Empty);
            var to = pluginData.Parameters.Get(key: "To", defaultValue: string.Empty);

            // Create and return a new SendMailRequest object
            // by mapping and transforming the raw parameter values.
            return new SendMailRequest
            {
                // Blind carbon copy recipients
                Bcc = bcc.Split(separator: ';', options: splitOptions),

                // Carbon copy recipients
                Cc = cc.Split(separator: ';', options: splitOptions),

                // Sender email address
                From = from,

                // Indicates if the email body is HTML
                IsBodyHtml = isBodyHtml,

                // Email subject line
                Subject = subject,

                // Plain-text email body
                Text = text,

                // Split semicolon-separated email lists into arrays
                To = to.Split(separator: ';', options: splitOptions),
            };
        }

        /// <summary>
        /// Sends an email using classic SMTP (<see cref="SmtpClient"/>) based on the provided options and request.
        /// </summary>
        /// <param name="options">SMTP connection and authentication settings.</param>
        /// <param name="request">The email payload (recipients, subject, and body).</param>
        /// <param name="cancellationToken">A token used to cancel the send operation.</param>
        /// <returns>A task that completes when the email has been sent.</returns>
        private static async Task SendSmtpMailAsync(
            SmtpOptions options,
            SendMailRequest request,
            CancellationToken cancellationToken)
        {
            // Resolve the sender:
            // - If request.From is missing/blank, fall back to the configured DefaultFrom.
            // - If ForceFrom is enabled, ALWAYS use DefaultFrom (even if request.From is provided).
            var resolvedFrom = string.IsNullOrWhiteSpace(request.From)
                ? options.DefaultFrom
                : request.From;

            // Final "From" address after applying ForceFrom logic.
            var from = options.ForceFrom
                ? options.DefaultFrom
                : resolvedFrom;

            // Build the mail message (disposed automatically by the using statement).
            using var message = new MailMessage();

            // Populate sender + content fields.
            message.From = new MailAddress(from);
            message.Subject = request.Subject;
            message.Body = request.Text;
            message.IsBodyHtml = request.IsBodyHtml;

            // Add primary recipients.
            foreach (var to in request.To)
            {
                message.To.Add(to);
            }

            // Ensure CC list is non-null, then add.
            request.Cc ??= [];
            foreach (var cc in request.Cc)
            {
                message.CC.Add(cc);
            }

            // Ensure BCC list is non-null, then add.
            request.Bcc ??= [];
            foreach (var bcc in request.Bcc)
            {
                message.Bcc.Add(bcc);
            }

            // Create the SMTP client (disposed automatically by the using statement).
            // Host/Port come from the options; TLS is controlled via EnableSsl.
            using var client = new SmtpClient(options.Host, options.Port)
            {
                EnableSsl = options.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Configure authentication:
            // - If Username is provided, use explicit credentials.
            // - Otherwise, fall back to default system credentials.
            if (!string.IsNullOrWhiteSpace(options.Username))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                    userName: options.Username,
                    password: options.Password ?? "");
            }
            else
            {
                client.UseDefaultCredentials = true;
            }

            // SmtpClient is synchronous (in many frameworks), so we offload it to a background thread
            // to keep this method awaitable and responsive to cancellation requests.
            await Task.Run(() =>
            {
                // Cooperatively honor cancellation before starting the blocking send.
                cancellationToken.ThrowIfCancellationRequested();

                // Perform the blocking SMTP send.
                client.Send(message);
            }, cancellationToken);
        }
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// Represents the configuration settings required to connect to an SMTP server
        /// and send emails.
        /// </summary>
        private sealed class SmtpOptions
        {
            /// <summary>
            /// Gets or sets the default sender email address.
            /// This value is used when the mail request does not explicitly specify a "From" address.
            /// </summary>
            public string DefaultFrom { get; set; } = "no-reply@test.local";

            /// <summary>
            /// Gets or sets a value indicating whether SSL/TLS should be enabled
            /// for the SMTP connection.
            /// </summary>
            public bool EnableSsl { get; set; } = true;

            /// <summary>
            /// Gets or sets a value indicating whether the "From" address
            /// should always be forced to <see cref="DefaultFrom"/>,
            /// regardless of what is provided in the mail request.
            /// </summary>
            public bool ForceFrom { get; set; } = true;

            /// <summary>
            /// Gets or sets the hostname or IP address of the SMTP server.
            /// Example: smtp.gmail.com
            /// </summary>
            public string Host { get; set; }

            /// <summary>
            /// Gets or sets the password used for authenticating with the SMTP server.
            /// This is typically an app password or API-specific credential.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets the port used to connect to the SMTP server.
            /// Common values:
            ///  - 587: STARTTLS (recommended)
            ///  - 465: SSL
            ///  - 25:  Plain (not recommended)
            /// </summary>
            public int Port { get; set; } = 587;

            /// <summary>
            /// Gets or sets the username used for authenticating with the SMTP server.
            /// This is often the same as the sender email address.
            /// </summary>
            public string Username { get; set; }
        }

        /// <summary>
        /// Represents a mail message payload used for sending emails.
        /// This object defines the sender, recipients, subject, and body content.
        /// </summary>
        private sealed class SendMailRequest
        {
            /// <summary>
            /// Gets or sets the list of email addresses that will receive the email as Blind Carbon Copy (BCC).
            /// Recipients in this list are hidden from other recipients.
            /// </summary>
            public string[] Bcc { get; set; } = [];

            /// <summary>
            /// Gets or sets the list of email addresses that will receive the email as Carbon Copy (CC).
            /// These recipients are visible to all other recipients.
            /// </summary>
            public string[] Cc { get; set; } = [];

            /// <summary>
            /// Gets or sets the sender email address.
            /// This value is used as the "From" field in the email header.
            /// </summary>
            public string From { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the body of the message is in HTML format.
            /// </summary>
            public bool IsBodyHtml { get; set; } = false;

            /// <summary>
            /// Gets or sets the subject line of the email.
            /// This is what the recipient will see as the email title.
            /// </summary>
            public string Subject { get; set; } = "";

            /// <summary>
            /// Gets or sets the plain-text body of the email.
            /// This is the main content of the message.
            /// </summary>
            public string Text { get; set; } = "";

            /// <summary>
            /// Gets or sets the list of primary recipient email addresses.
            /// At least one address is typically required for a valid email.
            /// </summary>
            public string[] To { get; set; } = [];
        }
        #endregion
    }
}
