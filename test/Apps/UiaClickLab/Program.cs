using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UiaClickLab
{
    /// <summary>
    /// Entry point of the click lab, a small window that the live UIA click tests drive.
    /// </summary>
    /// <remarks>
    /// The window holds one button named <c>Click Target</c> and a status label. Each press on the button names the
    /// pressed mouse button in the label text and in its accessible name, so a rule such as
    /// <c>//Text[@Name='Last button: Middle']</c> finds the label only after a middle press. Every press and release
    /// is also appended to <c>clicks.log</c> next to the executable, which shows what reached the window when a test
    /// fails. The window stays on top at a fixed position, so a click at its screen points is not covered by another
    /// window that is already open.
    /// </remarks>
    internal static class Program
    {
        #region *** Constants    ***
        // The text the status label starts with and prefixes to every pressed button name.
        private const string StatusPrefix = "Last button: ";
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Shows the click lab window and runs its message loop until the window closes.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Apply the project's high DPI and visual style settings before any control is created.
            ApplicationConfiguration.Initialize();

            // Build the window with its click target and status label at fixed positions.
            var form = NewForm();
            var target = NewTarget();
            var status = NewStatus();
            var logPath = Path.Combine(AppContext.BaseDirectory, "clicks.log");

            // Name the pressed button in the label and log the press, so a test can wait for the label text.
            target.MouseDown += (_, arguments) =>
            {
                WriteLog(logPath, $"MouseDown {arguments.Button}");
                status.Text = $"{StatusPrefix}{arguments.Button}";
                status.AccessibleName = status.Text;
            };

            // Log the release too, because a press without a release points at a lost input.
            target.MouseUp += (_, arguments) => WriteLog(logPath, $"MouseUp {arguments.Button}");

            // Show the window and run until a test closes it.
            form.Controls.Add(target);
            form.Controls.Add(status);
            Application.Run(form);
        }

        // Creates the main window, which stays on top at a fixed screen position so the tests click a known area.
        private static Form NewForm() => new()
        {
            ClientSize = new Size(420, 220),
            Location = new Point(200, 200),
            Name = "UiaClickLab",
            StartPosition = FormStartPosition.Manual,
            Text = "UIA Click Lab",
            TopMost = true
        };

        // Creates the status label; its accessible name follows its text, because UIA reports it as the Name.
        private static Label NewStatus() => new()
        {
            AccessibleName = $"{StatusPrefix}None",
            AutoSize = true,
            Font = new Font("Segoe UI", 12),
            Location = new Point(40, 150),
            Name = "Status",
            Text = $"{StatusPrefix}None"
        };

        // Creates the button the tests click; its accessible name is the Name the tests locate it by.
        private static Button NewTarget() => new()
        {
            AccessibleName = "Click Target",
            Font = new Font("Segoe UI", 14),
            Location = new Point(40, 40),
            Name = "ClickTarget",
            Size = new Size(340, 80),
            Text = "Click Target"
        };

        // Appends one time-stamped line to the click log next to the executable.
        private static void WriteLog(string logPath, string text)
        {
            // Stamp the line with the local time to the millisecond, so it lines up with the driver log.
            var line = $"{DateTime.Now:HH:mm:ss.fff} {text}{Environment.NewLine}";
            File.AppendAllText(logPath, line);
        }
        #endregion
    }
}
