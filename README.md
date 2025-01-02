# WaitForSecondsCache and WaitForSecondsDebugView Documentation

This project introduces a caching system for `WaitForSeconds` in Unity to optimize the creation of identical timers and a debug view for monitoring cached timers in the Unity Editor.

---

## Table of Contents
1. [Overview](#overview)
2. [Features](#features)
3. [Usage](#usage)
4. [Debug View](#debug-view)
5. [Dependencies](#dependencies)
6. [Integration](#integration)
7. [Contributions](#contributions)

---

## Overview

The `WaitForSecondsCache` class provides a simple and efficient caching mechanism for `WaitForSeconds` objects. This reduces memory allocation overhead and improves performance, especially in projects where timers with identical durations are used frequently.

The `WaitForSecondsDebugView` is a utility designed to help developers monitor and debug cached timers during development.

---

## Features

- **Efficient caching**: Avoids redundant creation of `WaitForSeconds` objects.
- **Debugging support**: View and monitor cached timers in the Unity Editor.
- **Singleton design**: The `WaitForSecondsDebugView` leverages a `MonoSingleton` implementation for centralized management.
- **Editor-only Debugging**: The debug view is included only when the project is running in the Unity Editor.

---

## Usage

### Caching Timers

To retrieve or cache a `WaitForSeconds` object:
```csharp
WaitForSeconds wait = WaitForSecondsCache.Get(0.5f);
yield return wait;
```

### Resetting the Cache

To clear all cached timers:
```csharp
WaitForSecondsCache.Reset();
```

### Accessing the Cache Directly

To get a read-only view of the current cache:
```csharp
var cache = WaitForSecondsCache.GetCache();
foreach (var entry in cache)
{
    Debug.Log($"Time: {entry.Key}, WaitForSeconds: {entry.Value}");
}
```

---

## Debug View

The `WaitForSecondsDebugView` provides a GUI for monitoring cached timers in the Unity Editor. 

### Features
- Displays all currently cached `WaitForSeconds` objects.
- Allows enabling/disabling the debug view via an Inspector toggle.

### GUI Example

The debug view appears in the top-left corner of the game view when running in the Editor:
```
WaitForSeconds Cache Debug View:
Time: 0.5 seconds
Time: 1.0 seconds
Time: 2.0 seconds
```

### Enable/Disable Debugging

You can enable or disable the debug view using the `enableDebugView` checkbox in the `WaitForSecondsDebugView` component.

---

## Dependencies

- **MonoSingleton**: The `WaitForSecondsDebugView` relies on a generic MonoSingleton implementation, which can be found [here](https://github.com/RimuruDev/MonoSingleton.git).

To integrate the MonoSingleton, ensure the following class is available in your project:
```csharp
namespace AbyssMoth.Internal.Codebase.Runtime._MainMenuModule.User
{
    public abstract class MonoSingleton<TComponent> : MonoBehaviour where TComponent : Component
    {
        // Implementation here (already included in the project).
    }
}
```

---

## Integration

1. Add the `WaitForSecondsCache` and `WaitForSecondsDebugView` classes to your project.
2. Ensure the `MonoSingleton` implementation is present in your codebase.
3. Add the `WaitForSecondsDebugView` to a GameObject in your scene or let it auto-instantiate.

---

## Contributions

Contributions are welcome! If you find a bug or have a suggestion, feel free to open an issue or a pull request.

For questions, contact me:
- **Email**: rimuru.dev@gmail.com
- **LinkedIn**: [Rimuru's Profile](https://www.linkedin.com/in/rimuru/)
- **GitHub**: [Rimuru's GitHub](https://github.com/RimuruDev)

---

**License**: Open Source, available under the MIT License.
