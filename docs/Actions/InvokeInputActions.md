# Invoke Input Actions (InvokeInputActions)

[Table of Content](../Home.md)

~24 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

InvokeInputActions performs a custom gesture built from single input actions.
The steps placed inside it form one group, and each step adds one action, such as a key press, a pointer move, a button release, a pause, or a wheel scroll.
The container sends all of them together, so the application receives one continuous gesture such as a drag, a Ctrl+click, or a keyboard shortcut.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| One sequence | Sends every action of the group in a single request, in the order the steps appear. |
| Named gesture | Takes an optional name or comment in its argument, which the container does not act on. |
| Keys, pointer, and wheel together | Mixes key, pointer, pause, and wheel actions in one gesture. |
| All or nothing | Sends nothing when a step fails to add its action, so a broken group never starts its gesture. |
| Elements found first | Finds the element of every step before the sequence is sent, so each element must already be in the page. |
| Release on failure | Releases pressed keys and buttons when the driver rejects the sequence part way through the gesture. |
| State kept between groups | Leaves a key or a button pressed after a successful send, so a later group can continue the gesture. |
| Guarded content | Accepts input action steps only and fails with a clear message for any other step. |
| Loop support | Runs once per iteration inside a loop and passes the current element of a for-each loop to its steps. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Drag and drop | Move a card or a slider handle by pressing, moving, and releasing the pointer. |
| Multi-selection | Hold Control or Shift while clicking several rows or list items. |
| Keyboard shortcuts | Press a key combination such as Ctrl+Shift+S that an application reads as one chord. |
| Hover menus | Move over a menu and wait for it to open, then click an item the menu creates in a following container. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Gesture checks | Verify that a drag, a long press, or a wheel scroll changes the page as expected. |
| Shortcut checks | Verify that a key combination triggers the expected command. |
| Hover state checks | Open a tooltip or a hover menu and assert its content in the next step. |
| Canvas and map checks | Drive a canvas, a chart, or a map with exact pointer positions. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Hold Control and click two rows

The group presses Control, clicks two table rows, and releases Control.
All eight actions travel in one request, so the key stays down for both clicks.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeInputActions",
    Argument = "Ctrl+click rows 1 and 3",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "AddKeyDown",
            Argument = "Control"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerMove",
            OnElement = "//tr[@data-id='1']"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerDown"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerUp"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerMove",
            OnElement = "//tr[@data-id='3']"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerDown"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerUp"
        }
        new ActionRuleModel
        {
            PluginName = "AddKeyUp",
            Argument = "Control"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeInputActions")
    .setArgument("Ctrl+click rows 1 and 3")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("AddKeyDown")
            .setArgument("Control"),

        new ActionRuleModel()        
            .setPluginName("AddPointerMove")
            .setOnElement("//tr[@data-id='1']"),

        new ActionRuleModel()        
            .setPluginName("AddPointerDown"),

        new ActionRuleModel()        
            .setPluginName("AddPointerUp"),

        new ActionRuleModel()        
            .setPluginName("AddPointerMove")
            .setOnElement("//tr[@data-id='3']"),

        new ActionRuleModel()        
            .setPluginName("AddPointerDown"),

        new ActionRuleModel()        
            .setPluginName("AddPointerUp"))
        new ActionRuleModel()        
            .setPluginName("AddKeyUp")
            .setArgument("Control");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeInputActions",
    argument: "Ctrl+click rows 1 and 3",
    rules: [,
        {
            pluginName: "AddKeyDown",
            argument: "Control"
        },
        {
            pluginName: "AddPointerMove",
            onElement: "//tr[@data-id='1']"
        },
        {
            pluginName: "AddPointerDown"
        },
        {
            pluginName: "AddPointerUp"
        },
        {
            pluginName: "AddPointerMove",
            onElement: "//tr[@data-id='3']"
        },
        {
            pluginName: "AddPointerDown"
        },
        {
            pluginName: "AddPointerUp"
        }
        {
            pluginName: "AddKeyUp",
            argument: "Control"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeInputActions",
    "argument": "Ctrl+click rows 1 and 3",
    "rules": [,
        {
            "pluginName": "AddKeyDown",
            "argument": "Control"
        },
        {
            "pluginName": "AddPointerMove",
            "onElement": "//tr[@data-id='1']"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerUp"
        },
        {
            "pluginName": "AddPointerMove",
            "onElement": "//tr[@data-id='3']"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerUp"
        }
        {
            "pluginName": "AddKeyUp",
            "argument": "Control"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeInputActions",
    "argument": "Ctrl+click rows 1 and 3",
    "rules": [,
        {
            "pluginName": "AddKeyDown",
            "argument": "Control"
        },
        {
            "pluginName": "AddPointerMove",
            "onElement": "//tr[@data-id='1']"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerUp"
        },
        {
            "pluginName": "AddPointerMove",
            "onElement": "//tr[@data-id='3']"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerUp"
        }
        {
            "pluginName": "AddKeyUp",
            "argument": "Control"
        }
    ]
}
```

### Example No.2

### Drag an item and drop it on a target

The group moves to a card, presses the left button, moves a short distance, moves on to the target column, waits, and releases.
The short first move starts the drag, because many pages begin a drag only after the pointer moved while the button is down.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeInputActions",
    Argument = "Drag card 7 to the done column",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "AddPointerMove",
            Locator = "CssSelector",
            OnElement = "#card-7"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerDown"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerMove",
            Argument = "{{$ --X:20 --Y:0 --Duration:100}}"
        },
        new ActionRuleModel
        {
            PluginName = "AddPointerMove",
            Argument = "{{$ --Duration:400}}",
            Locator = "CssSelector",
            OnElement = "#done-column"
        },
        new ActionRuleModel
        {
            PluginName = "AddPause",
            Argument = "200"
        }
        new ActionRuleModel
        {
            PluginName = "AddPointerUp"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeInputActions")
    .setArgument("Drag card 7 to the done column")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("AddPointerMove")
            .setLocator("CssSelector")
            .setOnElement("#card-7"),

        new ActionRuleModel()        
            .setPluginName("AddPointerDown"),

        new ActionRuleModel()        
            .setPluginName("AddPointerMove")
            .setArgument("{{$ --X:20 --Y:0 --Duration:100}}"),

        new ActionRuleModel()        
            .setPluginName("AddPointerMove")
            .setArgument("{{$ --Duration:400}}")
            .setLocator("CssSelector")
            .setOnElement("#done-column"),

        new ActionRuleModel()        
            .setPluginName("AddPause")
            .setArgument("200"))
        new ActionRuleModel()        
            .setPluginName("AddPointerUp");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeInputActions",
    argument: "Drag card 7 to the done column",
    rules: [,
        {
            pluginName: "AddPointerMove",
            locator: "CssSelector",
            onElement: "#card-7"
        },
        {
            pluginName: "AddPointerDown"
        },
        {
            pluginName: "AddPointerMove",
            argument: "{{$ --X:20 --Y:0 --Duration:100}}"
        },
        {
            pluginName: "AddPointerMove",
            argument: "{{$ --Duration:400}}",
            locator: "CssSelector",
            onElement: "#done-column"
        },
        {
            pluginName: "AddPause",
            argument: "200"
        }
        {
            pluginName: "AddPointerUp"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeInputActions",
    "argument": "Drag card 7 to the done column",
    "rules": [,
        {
            "pluginName": "AddPointerMove",
            "locator": "CssSelector",
            "onElement": "#card-7"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerMove",
            "argument": "{{$ --X:20 --Y:0 --Duration:100}}"
        },
        {
            "pluginName": "AddPointerMove",
            "argument": "{{$ --Duration:400}}",
            "locator": "CssSelector",
            "onElement": "#done-column"
        },
        {
            "pluginName": "AddPause",
            "argument": "200"
        }
        {
            "pluginName": "AddPointerUp"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeInputActions",
    "argument": "Drag card 7 to the done column",
    "rules": [,
        {
            "pluginName": "AddPointerMove",
            "locator": "CssSelector",
            "onElement": "#card-7"
        },
        {
            "pluginName": "AddPointerDown"
        },
        {
            "pluginName": "AddPointerMove",
            "argument": "{{$ --X:20 --Y:0 --Duration:100}}"
        },
        {
            "pluginName": "AddPointerMove",
            "argument": "{{$ --Duration:400}}",
            "locator": "CssSelector",
            "onElement": "#done-column"
        },
        {
            "pluginName": "AddPause",
            "argument": "200"
        }
        {
            "pluginName": "AddPointerUp"
        }
    ]
}
```

### Example No.3

### Press a three-key shortcut

The group presses Control, Shift, and S in order and releases them in reverse order.
The application receives the three keys as one chord.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeInputActions",
    Argument = "Press Ctrl+Shift+S",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "AddKeyDown",
            Argument = "Control"
        },
        new ActionRuleModel
        {
            PluginName = "AddKeyDown",
            Argument = "Shift"
        },
        new ActionRuleModel
        {
            PluginName = "AddKeyDown",
            Argument = "s"
        },
        new ActionRuleModel
        {
            PluginName = "AddKeyUp",
            Argument = "s"
        },
        new ActionRuleModel
        {
            PluginName = "AddKeyUp",
            Argument = "Shift"
        }
        new ActionRuleModel
        {
            PluginName = "AddKeyUp",
            Argument = "Control"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeInputActions")
    .setArgument("Press Ctrl+Shift+S")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("AddKeyDown")
            .setArgument("Control"),

        new ActionRuleModel()        
            .setPluginName("AddKeyDown")
            .setArgument("Shift"),

        new ActionRuleModel()        
            .setPluginName("AddKeyDown")
            .setArgument("s"),

        new ActionRuleModel()        
            .setPluginName("AddKeyUp")
            .setArgument("s"),

        new ActionRuleModel()        
            .setPluginName("AddKeyUp")
            .setArgument("Shift"))
        new ActionRuleModel()        
            .setPluginName("AddKeyUp")
            .setArgument("Control");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeInputActions",
    argument: "Press Ctrl+Shift+S",
    rules: [,
        {
            pluginName: "AddKeyDown",
            argument: "Control"
        },
        {
            pluginName: "AddKeyDown",
            argument: "Shift"
        },
        {
            pluginName: "AddKeyDown",
            argument: "s"
        },
        {
            pluginName: "AddKeyUp",
            argument: "s"
        },
        {
            pluginName: "AddKeyUp",
            argument: "Shift"
        }
        {
            pluginName: "AddKeyUp",
            argument: "Control"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeInputActions",
    "argument": "Press Ctrl+Shift+S",
    "rules": [,
        {
            "pluginName": "AddKeyDown",
            "argument": "Control"
        },
        {
            "pluginName": "AddKeyDown",
            "argument": "Shift"
        },
        {
            "pluginName": "AddKeyDown",
            "argument": "s"
        },
        {
            "pluginName": "AddKeyUp",
            "argument": "s"
        },
        {
            "pluginName": "AddKeyUp",
            "argument": "Shift"
        }
        {
            "pluginName": "AddKeyUp",
            "argument": "Control"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeInputActions",
    "argument": "Press Ctrl+Shift+S",
    "rules": [,
        {
            "pluginName": "AddKeyDown",
            "argument": "Control"
        },
        {
            "pluginName": "AddKeyDown",
            "argument": "Shift"
        },
        {
            "pluginName": "AddKeyDown",
            "argument": "s"
        },
        {
            "pluginName": "AddKeyUp",
            "argument": "s"
        },
        {
            "pluginName": "AddKeyUp",
            "argument": "Shift"
        }
        {
            "pluginName": "AddKeyUp",
            "argument": "Control"
        }
    ]
}
```

### Example No.4

### Scroll a list and wait for more items

The group turns the wheel 600 pixels down over the center of a list.
A short pause lets the list load its next items before the following step runs.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeInputActions",
    Argument = "Scroll the results list",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "AddScroll",
            Argument = "{{$ --DeltaY:600}}",
            OnElement = "//div[@id='results']"
        }
        new ActionRuleModel
        {
            PluginName = "AddPause",
            Argument = "300"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeInputActions")
    .setArgument("Scroll the results list")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("AddScroll")
            .setArgument("{{$ --DeltaY:600}}")
            .setOnElement("//div[@id='results']"))
        new ActionRuleModel()        
            .setPluginName("AddPause")
            .setArgument("300");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeInputActions",
    argument: "Scroll the results list",
    rules: [,
        {
            pluginName: "AddScroll",
            argument: "{{$ --DeltaY:600}}",
            onElement: "//div[@id='results']"
        }
        {
            pluginName: "AddPause",
            argument: "300"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeInputActions",
    "argument": "Scroll the results list",
    "rules": [,
        {
            "pluginName": "AddScroll",
            "argument": "{{$ --DeltaY:600}}",
            "onElement": "//div[@id='results']"
        }
        {
            "pluginName": "AddPause",
            "argument": "300"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeInputActions",
    "argument": "Scroll the results list",
    "rules": [,
        {
            "pluginName": "AddScroll",
            "argument": "{{$ --DeltaY:600}}",
            "onElement": "//div[@id='results']"
        }
        {
            "pluginName": "AddPause",
            "argument": "300"
        }
    ]
}
```

### Example No.5

### Press a key and keep it down after the group

The group sends one key press and no release.
The key stays down after the group until a later group releases it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeInputActions",
    Argument = "Hold Shift for the next steps",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "AddKeyDown",
            Argument = "Shift"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeInputActions")
    .setArgument("Hold Shift for the next steps")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("AddKeyDown")
            .setArgument("Shift");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeInputActions",
    argument: "Hold Shift for the next steps",
    rules: [
        {
            pluginName: "AddKeyDown",
            argument: "Shift"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeInputActions",
    "argument": "Hold Shift for the next steps",
    "rules": [
        {
            "pluginName": "AddKeyDown",
            "argument": "Shift"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeInputActions",
    "argument": "Hold Shift for the next steps",
    "rules": [
        {
            "pluginName": "AddKeyDown",
            "argument": "Shift"
        }
    ]
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names or comments the gesture, such as `Ctrl+click rows 1 and 3`, so the flow reads clearly.
The container does not act on the text; macros in it are resolved like in any other rule.

### Rules (Rules)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Lists the input action steps of the gesture, in the order they are performed.
Each step adds one action, and the container sends them together after the last step.
Only input action steps are accepted, such as AddKeyDown, AddPointerMove, or AddScroll.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
