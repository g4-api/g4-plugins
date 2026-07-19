# Protect Data (ProtectData)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Encrypts a plaintext value with a caller-supplied key and encodes the result to Base64 for safe storage and transport.
It takes the `Value` and `Key` parameters from the `Argument` expression, applies symmetric encryption, and stores the protected output.
The encoded result is stored in the session as `ProtectData:Result` and exposed through the response entity.

### Key Features and Functionality

| Feature         | Description                                                                               |
|-----------------|-------------------------------------------------------------------------------------------|
| Encryption      | Encrypts the `Value` parameter using the `Key` parameter before encoding.                 |
| Base64 Encoding | Encodes the encrypted output to Base64 for safe transport and storage.                    |
| Session Output  | Stores the protected result in the session as `ProtectData:Result` for downstream access. |

### Usages in RPA

| Use Case                | Description                                                                               |
|-------------------------|-------------------------------------------------------------------------------------------|
| Credential Protection   | Encrypt passwords or tokens before storing them in session parameters.                    |
| Secure Data Hand-off    | Pass encrypted values between workflow steps without exposing plaintext in logs or state. |
| Config Value Protection | Protect sensitive configuration values before writing them to shared storage.             |

### Usages in Automation Testing

| Use Case               | Description                                                                                     |
|------------------------|-------------------------------------------------------------------------------------------------|
| Test Secret Management | Encrypt test credentials at runtime so they are never present in plaintext during a test run.   |
| Roundtrip Validation   | Encrypt a known value and assert that decryption with the same key recovers the original input. |
| Key Sensitivity Check  | Verify that different encryption keys produce different protected outputs for the same value.   |

## Examples

### Example No.1

### Encrypt a Static Value

Encrypt a fixed plaintext value using a known key during automation execution.
It uses the `ProtectData` plugin with `--Value:MySecret` and `--Key:SuperSecret`.
The value is encrypted and the result is Base64-encoded before being stored in the session as `ProtectData:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ProtectData",
    Argument = "{{$ --Value:MySecret --Key:SuperSecret}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ProtectData")
    .setArgument("{{$ --Value:MySecret --Key:SuperSecret}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ProtectData",
    argument: "{{$ --Value:MySecret --Key:SuperSecret}}"
};
```

_**JSON**_

```js
{
    "pluginName": "ProtectData",
    "argument": "{{$ --Value:MySecret --Key:SuperSecret}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ProtectData",
    "argument": "{{$ --Value:MySecret --Key:SuperSecret}}"
}
```
### Example No.2

### Encrypt a Session Parameter Value

Encrypt the runtime value of a session parameter using a known key.
It uses the `ProtectData` plugin with `--Value:{{$Get-Parameter --Name:Password --Scope:Session}}` and `--Key:VaultKey`.
The G4 expression is resolved at runtime, the resolved value is encrypted, and the Base64 result is stored in the session as `ProtectData:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ProtectData",
    Argument = "{{$ --Value:{{$Get-Parameter --Name:Password --Scope:Session}} --Key:VaultKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ProtectData")
    .setArgument("{{$ --Value:{{$Get-Parameter --Name:Password --Scope:Session}} --Key:VaultKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ProtectData",
    argument: "{{$ --Value:{{$Get-Parameter --Name:Password --Scope:Session}} --Key:VaultKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "ProtectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:Password --Scope:Session}} --Key:VaultKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ProtectData",
    "argument": "{{$ --Value:{{$Get-Parameter --Name:Password --Scope:Session}} --Key:VaultKey}}"
}
```

## Output Parameter

### Protect Data Result (ProtectData:Result)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The session parameter that holds the Base64-encoded encrypted result.
Its value can be decoded from Base64 and decrypted with the original key to recover the plaintext.
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
Use `--Value` to provide the plaintext to encrypt and `--Key` to provide the encryption key.
Both parameters are required; omitting either will result in an empty or unkeyed encryption.

## Parameters

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The plaintext value to encrypt.
Accepts a literal string or a G4 expression that resolves at runtime.
This value is never stored in plaintext; only the encrypted Base64 output is retained.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The encryption key used to protect the value.
Must be the same key used during any subsequent decryption step.
Keep this key secure; loss of the key makes the encrypted value unrecoverable.

## Scope

* Any