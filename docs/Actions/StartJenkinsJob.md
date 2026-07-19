# Start Jenkins Job (StartJenkinsJob)

[Table of Content](../Home.md)  

~23 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sends a request to Jenkins to start a specific job and can optionally wait until the build finishes.
It supports both simple and parameterized jobs so that different Jenkins job types can be triggered from the same automation.
It captures key job details such as status, duration, and URLs so later steps in the workflow can make decisions or log results.

### Key Features and Functionality

| Feature               | Description                                                                  |
|-----------------------|------------------------------------------------------------------------------|
| Jenkins Job Trigger   | Starts a Jenkins job using the standard build or buildWithParameters API.    |
| Parameter Support     | Detects parameterized jobs and sends the request to the correct endpoint.    |
| Wait for Completion   | Optionally polls Jenkins until the build is finished or a timeout occurs.    |
| Authentication        | Uses HTTP Basic authentication based on Username and Token parameters.       |
| Polling Configuration | Uses configurable polling interval and timeout values for job monitoring.    |
| Output Metadata       | Stores status code, job duration, and job URL for later workflow steps.      |
| JSONPath Extraction   | Optionally extracts specific fields from the JSON response using JSONPath.   |
| Regex Post-Processing | Applies a regular expression on the job response and stores the first match. |

### Usages in RPA

| Use Case                            | Description                                                                                  |
|-------------------------------------|----------------------------------------------------------------------------------------------|
| Trigger nightly maintenance jobs    | Start scheduled Jenkins jobs that perform system cleanups, backups, or maintenance actions.  |
| Orchestrate multi-step DevOps flows | Call Jenkins jobs from larger RPA flows that also touch issue trackers and deployment tools. |
| Environment preparation jobs        | Run Jenkins jobs that prepare test or staging environments before other automated steps run. |
| Automated release tasks             | Trigger release-related Jenkins jobs as part of a broader RPA-driven release procedure.      |
| Status-based branching              | Use stored job status and URL to decide whether the RPA flow continues or raises an alert.   |

### Usages in Automation Testing

| Use Case                                  | Description                                                                                          |
|-------------------------------------------|------------------------------------------------------------------------------------------------------|
| Trigger automated test suites             | Start Jenkins jobs that run unit, integration, or end-to-end test suites from a central test runner. |
| Run smoke tests before deployments        | Launch Jenkins smoke-test jobs and wait for completion before allowing deployment steps to proceed.  |
| Collect timing metrics for test runs      | Use stored duration to measure how long Jenkins test jobs take and track performance over time.      |
| Conditional test result handling          | Use JSONPath and regex extraction to read result fields and decide if follow-up actions are needed.  |
| Integrate CI results into test dashboards | Store job URL and status so external dashboards or reporters can link directly to Jenkins job pages. |

## Examples

### Example No.1

### Trigger Jenkins job and wait for completion

Start a Jenkins job by calling the StartJenkinsJob action with a macro that supplies connection details and control flags.
Use the macro in the argument property to pass the URL, job path, username, token, and the Wait flag as runtime values.
When Wait is present, the action polls Jenkins until the job finishes or the timeout elapses, then returns the HTTP status code, computed duration, job URL, and raw response body.
The macro only produces the argument string at runtime, and the StartJenkinsJob action consumes this value to perform the Jenkins HTTP request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartJenkinsJob",
    Argument = "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartJenkinsJob")
    .setArgument("{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StartJenkinsJob",
    argument: "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}"
};
```

_**JSON**_

```js
{
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}"
}
```
### Example No.2

### Trigger Jenkins job with a custom polling interval

Start a Jenkins job and specify how often the action polls Jenkins for build status by setting PollingInterval in milliseconds.
A macro supplies URL, job path, credentials, the Wait flag, and the PollingInterval value. The macro only produces the argument text at runtime, and the action uses it to perform the Jenkins requests.
The action continues polling at the specified interval until the job finishes or a timeout occurs, then outputs the status code, computed duration, job URL, and response body.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartJenkinsJob",
    Argument = "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait --PollingInterval:5000}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartJenkinsJob")
    .setArgument("{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait --PollingInterval:5000}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StartJenkinsJob",
    argument: "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait --PollingInterval:5000}}"
};
```

_**JSON**_

```js
{
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait --PollingInterval:5000}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait --PollingInterval:5000}}"
}
```
### Example No.3

### Trigger a parameterized Jenkins job using multiple Field parameters

Start a Jenkins job that requires parameters by using the Field property to specify key-value pairs.
A macro supplies the URL, job path, credentials, Wait flag, and multiple Field parameters. The macro only produces the argument text, and the action consumes it to perform the Jenkins request.
The action submits the Field parameters to Jenkins, waits for job completion, and then returns the status code, computed duration, job URL, and response body.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartJenkinsJob",
    Argument = "{{$ --Url:https://jenkins.example.com --JobPath:my-parameterized-job --Username:admin --Token:apitoken --Wait --Field:env=production --Field:retryCount=3}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartJenkinsJob")
    .setArgument("{{$ --Url:https://jenkins.example.com --JobPath:my-parameterized-job --Username:admin --Token:apitoken --Wait --Field:env=production --Field:retryCount=3}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StartJenkinsJob",
    argument: "{{$ --Url:https://jenkins.example.com --JobPath:my-parameterized-job --Username:admin --Token:apitoken --Wait --Field:env=production --Field:retryCount=3}}"
};
```

_**JSON**_

```js
{
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-parameterized-job --Username:admin --Token:apitoken --Wait --Field:env=production --Field:retryCount=3}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-parameterized-job --Username:admin --Token:apitoken --Wait --Field:env=production --Field:retryCount=3}}"
}
```
### Example No.4

### Extract build number using JPath and regular expression

Start a Jenkins job, wait for it to finish, and select the displayName field using JPath from the returned JSON.
A regular expression `build-(\d+)` is applied to the value attribute to extract only the numeric part.
The final extracted value is stored in the JenkinsJobResponse output parameter.
The macro in the argument only produces the text value at runtime, and the StartJenkinsJob action performs the extraction logic using that value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartJenkinsJob",
    Argument = "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}",
    OnElement = "$.displayName",
    RegularExpression = "build-(\d+)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartJenkinsJob")
    .setArgument("{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}")
    .setOnElement("$.displayName")
    .setRegularExpression("build-(\d+)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StartJenkinsJob",
    argument: "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}",
    onElement: "$.displayName",
    regularExpression: "build-(\d+)"
};
```

_**JSON**_

```js
{
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}",
    "onElement": "$.displayName",
    "regularExpression": "build-(\d+)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken --Wait}}",
    "onElement": "$.displayName",
    "regularExpression": "build-(\d+)"
}
```
### Example No.5

### Trigger Jenkins job without waiting for completion

Start a Jenkins job using connection details supplied by a macro, but omit the Wait flag to return immediately.
The action posts the job to Jenkins and returns the initial HTTP response with status code and queue item location.
Because the Wait flag is not set, no polling or duration computation is performed; the action returns as soon as Jenkins accepts the job.
The macro only generates the argument string at runtime, and the action uses this value to send the request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartJenkinsJob",
    Argument = "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartJenkinsJob")
    .setArgument("{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StartJenkinsJob",
    argument: "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken}}"
};
```

_**JSON**_

```js
{
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StartJenkinsJob",
    "argument": "{{$ --Url:https://jenkins.example.com --JobPath:my-job --Username:admin --Token:apitoken}}"
}
```

## Output Parameter

### Start Jenkins Job Jenkins Job Duration (StartJenkinsJob:JenkinsJobDuration)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Job duration tracks how long the Jenkins job ran from start to finish in milliseconds.
The value supports timing analysis and helps detect slow or failing build steps.

### Start Jenkins Job Jenkins Job Response (StartJenkinsJob:JenkinsJobResponse)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The matched response value captures specific text extracted from the Jenkins reply.
Encoding the value in Base64 ensures safe transport even when the content includes symbols or special characters.

### Start Jenkins Job Jenkins Job Status Code (StartJenkinsJob:JenkinsJobStatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

HTTP status code helps identify whether Jenkins accepted or rejected the job trigger request.
It allows workflows to react to success, failure, or unexpected responses in a predictable way.

### Start Jenkins Job Jenkins Job Url (StartJenkinsJob:JenkinsJobUrl)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Job URL shows the exact Jenkins build instance that was triggered.
The link allows follow-up steps to query logs, artifacts, or job results directly.

## Properties

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

RegularExpression defines a regex pattern used to extract specific data from the Jenkins job response.
The value is optional and helps capture targeted information such as IDs, URLs, or status messages.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement specifies a JSONPath expression that selects a part of the Jenkins response to read or process.
The value is optional and is useful when the response contains nested JSON and only a specific section is relevant.

## Parameters

### Field (Field)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | KeyValue          |

Field provides key-value parameters for Jenkins jobs that accept build parameters.
The value lets you pass dynamic inputs, such as branch names or environment flags, to the job at runtime.

### Job Path (JobPath)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Job path identifies the exact Jenkins job or foldered job to trigger, such as my-job or folder/my-job.
The value allows the automation to target the correct pipeline or build definition inside Jenkins.

### Polling Interval (PollingInterval)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 5000              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Polling interval defines how often the plugin checks Jenkins for job status updates.
The default value of 5000 milliseconds balances timely feedback with reduced load on the Jenkins server.

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 600000            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Timeout sets the maximum time to wait for the Jenkins job to finish before giving up.
The default value of 600000 milliseconds (10 minutes) prevents workflows from hanging indefinitely if a job stalls.

### Token (Token)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Token holds the Jenkins API token or password for the configured username.
The value must be kept secret because it grants access to trigger jobs and read their results.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Base URL points to the root address of the Jenkins server, including the protocol and port if needed.
The value is used to build all Jenkins API requests, so it must be reachable from the machine running the automation.

### Username (Username)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Username specifies the Jenkins account used to authenticate API calls.
The value controls which permissions are applied when triggering and monitoring the job.

### Wait (Wait)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | false             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Wait controls whether the plugin returns immediately after triggering the job or waits for completion.
Setting this value to true makes the workflow block until Jenkins finishes the job, which is useful when later steps depend on the result.

## Scope

* Any