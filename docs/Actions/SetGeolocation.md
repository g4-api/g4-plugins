# Set Geolocation (SetGeolocation)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetGeolocation` plugin is to allow automation scripts to set the geographical location of a mobile device. 
This functionality is essential in scenarios where location-based features or services need to be tested under various conditions. 
The plugin aims to streamline mobile automation by providing precise control over the device's geolocation.

### Key Features and Functionality

| Feature              | Description                                                                                                                   |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------|
| Geolocation Control  | Allows setting the device's latitude, longitude, and altitude, providing comprehensive control over its location.             |
| Compatibility Check  | Verifies if the WebDriver in use supports geolocation, throwing a `NotImplementedException` on unsupported drivers.           |
| Default Coordinates  | All three coordinate parameters default to `0.0` when omitted, placing the device at the equator/prime-meridian at sea level. |

### Usages in RPA

| Usage                     | Description                                                                                                       |
|---------------------------|-------------------------------------------------------------------------------------------------------------------|
| Location-Based Automation | Automates tasks that require the device to be at a specific location, such as testing location-based services.    |
| Testing Geofencing        | Ensures that geofencing features trigger correctly by simulating the device entering or leaving predefined areas. |

### Usages in Automation Testing

| Usage                          | Description                                                                                                                        |
|--------------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Comprehensive Location Testing | Enables testing of location-based features by setting the device to various coordinates and validating the application's response. |
| Altitude-Sensitive Features    | Tests elevation-dependent behaviors by combining latitude, longitude, and altitude in a single plugin call.                        |

## Examples

### Example No.1

### Set geolocation to a specific latitude and longitude

Set the device's geolocation to San Francisco coordinates without specifying altitude.
Altitude defaults to `0.0`, placing the device at sea level for the given coordinates.

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

### Set geolocation with latitude, longitude, and altitude

Set the device's geolocation to San Francisco coordinates at 30 metres altitude.
This configuration is useful for testing features that depend on both position and elevation, such as floor-level detection or elevation-based service boundaries.

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
### Example No.3

### Reset geolocation to zero coordinates

Reset the device's geolocation by omitting all parameters, which defaults all coordinates to `0.0`.
This places the device at null island (0°N, 0°E, 0m) and is useful for clearing a previously set location before a test step.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetGeolocation"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetGeolocation");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetGeolocation"
};
```

_**JSON**_

```js
{
    "pluginName": "SetGeolocation"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetGeolocation"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Used to pass coordinate arguments to the `SetGeolocation` plugin, such as `Latitude`, `Longitude`, and `Altitude`.

## Parameters

### Latitude (Latitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The latitude coordinate to set for the device's geolocation. Represents the north-south position on the Earth's surface. 
Valid range is `-90` to `90`. Defaults to `0.0` when not specified.

### Longitude (Longitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The longitude coordinate to set for the device's geolocation. Represents the east-west position on the Earth's surface. 
Valid range is `-180` to `180`. Defaults to `0.0` when not specified.

### Altitude (Altitude)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The altitude value to set for the device's geolocation. Represents the height above the Earth's surface in metres. 
Defaults to `0.0` (sea level) when not specified.

## Scope

* Mobile Native
* Mobile Web
## See Also

apiDocumentation: [https://appium.readthedocs.io/en/latest/en/commands/session/geolocation/set-geolocation/#http-api-specifications](https://appium.readthedocs.io/en/latest/en/commands/session/geolocation/set-geolocation/#http-api-specifications)
