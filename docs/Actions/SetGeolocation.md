# Set Geolocation (SetGeolocation)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetGeolocation` plugin is to allow automation scripts to set the geographical location of a mobile device. 
This functionality is essential in scenarios where location-based features or services need to be tested under various conditions. 
The plugin aims to streamline mobile automation by providing precise control over the device's geolocation.

### Key Features and Functionality

| Feature              | Description                                                                                                                           |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| Geolocation Control  | Allows setting the device's latitude, longitude, and altitude, providing comprehensive control over its location.                     |
| Compatibility Check  | Verifies if the WebDriver in use supports geolocation, ensuring the plugin's functionality is invoked only in supported environments. |
| Seamless Integration | Integrates with WebDriver's geolocation capabilities, enabling precise configuration of the device's location.                        |

### Usages in RPA

| Usage                     | Description                                                                                                       |
|---------------------------|-------------------------------------------------------------------------------------------------------------------|
| Location-Based Automation | Automates tasks that require the device to be at a specific location, such as testing location-based services.    |
| Testing Geofencing        | Ensures that geofencing features trigger correctly by simulating the device entering or leaving predefined areas. |

### Usages in Automation Testing

| Usage                          | Description                                                                                                                        |
|--------------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Comprehensive Location Testing | Enables testing of location-based features by setting the device to various coordinates and validating the application's response. |
| UI Stability Validation        | Ensures that the application's UI remains stable and functions correctly when the device's location changes.                       |

## Examples

### Example No.1

Set the geolocation to specific coordinates with default altitude.
This is useful for testing location-based features by setting the device to a specific latitude and longitude.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetGeolocation",
    Argument = "{{$ --Latitude:37.7749 --Longitude:-122.4194}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetGeolocation")
    .setArgument("{{$ --Latitude:37.7749 --Longitude:-122.4194}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetGeolocation",
    argument: "{{$ --Latitude:37.7749 --Longitude:-122.4194}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetGeolocation",
    "argument": "{{$ --Latitude:37.7749 --Longitude:-122.4194}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetGeolocation",
    "argument": "{{$ --Latitude:37.7749 --Longitude:-122.4194}}"
}
```
### Example No.2

Set the geolocation to specific coordinates with a specified altitude.
This configuration is useful for testing features that depend on both location and altitude, such as elevation-based services.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetGeolocation",
    Argument = "{{$ --Latitude:37.7749 --Longitude:-122.4194 --Altitude:30}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetGeolocation")
    .setArgument("{{$ --Latitude:37.7749 --Longitude:-122.4194 --Altitude:30}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetGeolocation",
    argument: "{{$ --Latitude:37.7749 --Longitude:-122.4194 --Altitude:30}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetGeolocation",
    "argument": "{{$ --Latitude:37.7749 --Longitude:-122.4194 --Altitude:30}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetGeolocation",
    "argument": "{{$ --Latitude:37.7749 --Longitude:-122.4194 --Altitude:30}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Used to pass additional information or instructions to the `SetGeolocation` plugin, such as specifying coordinates or altitude.

## Parameters

### Latitude (Latitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The latitude coordinate to set for the device's geolocation. It represents the north-south position on the Earth's surface.

### Longitude (Longitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The longitude coordinate to set for the device's geolocation. It represents the east-west position on the Earth's surface.

### Altitude (Altitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The altitude value to set for the device's geolocation. It represents the height above the Earth's surface.

## Scope

* Mobile Native
* Mobile Web
## See Also

apiDocumentation: [https://appium.readthedocs.io/en/latest/en/commands/session/geolocation/set-geolocation/#http-api-specifications](https://appium.readthedocs.io/en/latest/en/commands/session/geolocation/set-geolocation/#http-api-specifications)
