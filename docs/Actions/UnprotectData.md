# Unprotect Data (UnprotectData)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Decrypts a Base64-encoded encrypted value and recovers the original plaintext for use in downstream workflow steps.
It takes the `Value` and `Key` parameters from the `Argument` expression, decodes the value from Base64, and decrypts it with the supplied key.
The decrypted result is stored in the session as `UnprotectData:Result` and exposed through the response entity.
It is the symmetric inverse of the `ProtectData` plugin.

### Key Features and Functionality

| Feature         | Description                                                                                 |
|-----------------|---------------------------------------------------------------------------------------------|
| Base64 Decoding | Decodes the `Value` parameter from Base64 to recover the encrypted bytes.                   |
| Decryption      | Decrypts the decoded bytes using the `Key` parameter to recover the original plaintext.     |
| Session Output  | Stores the decrypted result in the session as `UnprotectData:Result` for downstream access. |

### Usages in RPA

| Use Case                | Description                                                                                    |
|-------------------------|------------------------------------------------------------------------------------------------|
| Credential Recovery     | Decrypt a protected password or token before using it in a subsequent workflow step.           |
| Secure Data Retrieval   | Recover plaintext from an encrypted session parameter before passing it to an external system. |
| Config Value Decryption | Decrypt a protected configuration value before it is consumed by a downstream action.          |

### Usages in Automation Testing

| Use Case              | Description                                                                                        |
|-----------------------|----------------------------------------------------------------------------------------------------|
| Roundtrip Validation  | Decrypt a value encrypted by ProtectData and assert the recovered plaintext matches the original.  |
| Secret Injection      | Decrypt a test credential at runtime and inject the plaintext into a form or API call.             |
| Key Sensitivity Check | Verify that decryption with a wrong key does not produce the original plaintext.                   |

## Examples

### Example No.1

### Decrypt a Protected Session Token

Recover the original plaintext from a Base64-encoded encrypted value stored in a session parameter.
It uses the `UnprotectData` plugin with `--Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}}` and `--Key:SuperSecret`.
The G4 expression resolves the `ProtectedToken` session parameter at runtime, the value is decoded from Base64 and decrypted, and the plaintext is stored in the session as `UnprotectData:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UnprotectData",
    Argument = "{{$ --Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}} --Key:SuperSecret}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UnprotectData")
    .setArgument("{{$ --Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}} --Key:SuperSecret}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UnprotectData",
    argument: "{{$ --Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}} --Key:SuperSecret}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UnprotectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}} --Key:SuperSecret}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UnprotectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:ProtectedToken --Scope:Session}} --Key:SuperSecret}}"
}
```
### Example No.2

### Decrypt a Session Parameter Value

Recover the original plaintext from a Base64-encoded encrypted value stored in a session parameter.
It uses the `UnprotectData` plugin with `--Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}}` and `--Key:VaultKey`.
The G4 expression is resolved at runtime, the resolved value is decoded from Base64 and decrypted, and the plaintext is stored in the session as `UnprotectData:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UnprotectData",
    Argument = "{{$ --Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}} --Key:VaultKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UnprotectData")
    .setArgument("{{$ --Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}} --Key:VaultKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UnprotectData",
    argument: "{{$ --Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}} --Key:VaultKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UnprotectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}} --Key:VaultKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UnprotectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:EncryptedCredential --Scope:Session}} --Key:VaultKey}}"
}
```

## Output Parameter

### Unprotect Data Result (UnprotectData:Result)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The session parameter that holds the decrypted plaintext result.
Its value is the original plaintext recovered by decoding the Base64 input and decrypting with the supplied key.
It can be referenced by other parameters or expressions in downstream workflow steps.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the `Value` and `Key` parameters using the G4 parameter expression syntax.
Use `--Value` to provide the Base64-encoded encrypted string and `--Key` to provide the decryption key.
The `Value` must have been produced by a prior `ProtectData` step using the same `Key`.

## Parameters

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The Base64-encoded encrypted string to decrypt.
Must be the output of a prior `ProtectData` step that used the same encryption key.
Accepts a literal Base64 string or a G4 expression that resolves to one at runtime.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The decryption key used to recover the original plaintext.
Must be the same key that was used during the corresponding `ProtectData` step.
Using a different key will not recover the original plaintext.

## Scope

* Any