# Switch Activity (SwitchActivity)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Starts an Android activity by its package and activity name, which brings that screen to the foreground.
The action calls the Appium UiAutomator2 `mobile: startActivity` command with the intent `package/activity`.
Use it to open a screen directly, without navigating to it through the user interface.
The G4 Android recorder records a move to another activity as this action.

### Key Features and Functionality

| Feature                  | Description                                                        |
| --- | --- |
| Direct Navigation        | Opens an activity by name instead of tapping through the app.      |
| Intent Building          | Joins Package and Activity as package/activity.                    |
| Full Intent Pass-Through | Uses Activity as the full intent when it already contains a slash. |
| Early Validation         | Fails before any driver call when Activity is missing.             |

### Usages in RPA

| Use Case         | Description                                                          |
| --- | --- |
| Jump to a Screen | Opens a settings or report screen directly to save navigation steps. |
| Recover a Flow   | Returns the app to a known screen after an unexpected dialog.        |

### Usages in Automation Testing

| Use Case             | Description                                                  |
| --- | --- |
| Screen Isolation     | Starts each test on the activity under test.                 |
| Recorded Flow Replay | Replays a screen change captured by the G4 Android recorder. |

## Examples

### Example No.1

### Open an activity by package and name

Starts `com.example.app.SettingsActivity` in the `com.example.app` package.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchActivity",
    Argument = "{{$ --Package:com.example.app --Activity:com.example.app.SettingsActivity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchActivity")
    .setArgument("{{$ --Package:com.example.app --Activity:com.example.app.SettingsActivity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SwitchActivity",
    argument: "{{$ --Package:com.example.app --Activity:com.example.app.SettingsActivity}}"
};
```

**JSON:**

```js
{
    "pluginName": "SwitchActivity",
    "argument": "{{$ --Package:com.example.app --Activity:com.example.app.SettingsActivity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SwitchActivity",
    "argument": "{{$ --Package:com.example.app --Activity:com.example.app.SettingsActivity}}"
}
```

### Example No.2

### Open an activity by its full intent

Starts the activity from a full `package/activity` intent, without a separate Package argument.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchActivity",
    Argument = "{{$ --Activity:com.example.app/.MainActivity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchActivity")
    .setArgument("{{$ --Activity:com.example.app/.MainActivity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SwitchActivity",
    argument: "{{$ --Activity:com.example.app/.MainActivity}}"
};
```

**JSON:**

```js
{
    "pluginName": "SwitchActivity",
    "argument": "{{$ --Activity:com.example.app/.MainActivity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SwitchActivity",
    "argument": "{{$ --Activity:com.example.app/.MainActivity}}"
}
```

## Parameters

### Activity (Activity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Activity names the Android activity to start, such as com.example.app.MainActivity.
When it contains a slash it is used as the full package/activity intent and Package is ignored.
It is mandatory; a missing value fails the step before any driver call.

### Package (Package)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Package names the Android package that owns the activity, such as com.example.app.
It is joined with Activity as package/activity.
It is ignored when Activity already holds a full intent.

## Scope

* Mobile Native

## See Also

apiDocumentation: [https://github.com/appium/appium-uiautomator2-driver#mobile-startactivity](https://github.com/appium/appium-uiautomator2-driver#mobile-startactivity)
