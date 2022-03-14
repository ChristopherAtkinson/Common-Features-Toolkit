# Common Features Toolkit [![version support][shield-unity]](#) [![version support][shield-odin_inspector]](#) [![MIT licensed][shield-license]](#)

Common Features Toolkit is a set of tools design for improving workflow in Unity and adding missing or much needed features commonly available in other engines, and platforms.

## Table of Contents

  * [Dependencies](#dependencies)
    * [Unity Long Term Support](#unity-long-term-support)
    * [Odin Inspector and Serializer](#odin-inspector-and-serializer)
  * [Installation](#installation)
  * [Features](#features)
    * [Scriptable Event System](#scriptable-event-system)
  * [License](#license)

## Dependencies

### [Unity Long Term Support](https://unity3d.com/unity/whats-new/2018.4.36) 

this project depends on Unity as it is a Unity package intended for sharing and re-using Unity projects and collections of assets.

[![version support][shield-unity]](#)

### [Odin Inspector and Serializer](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041) 

This project depends heavily on the use of [Odin - Inspector and Serializer](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041) to be able to create robust and intuitive inspectors in unity.

Due to Odin's license agreement, this package will not distribute or share any source material.

[![version support][shield-odin_inspector]](#)

## Installation

The Unity Package Manager can [load a package from a Git repository](https://docs.unity3d.com/Manual/upm-ui-giturl.html) on a remote server.

![Package Manager UI Image Not Found](https://docs.unity3d.com/uploads/Main/PackageManagerUI-GitURLPackageButton-Add.png "Package Manager UI")

Alterantivly to add the following [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager, append the follwoing information to the `manifest.json`:

```
"com.undefined.common-features-toolkit": "https://github.com/ChristopherAtkinson/Common-Features-Toolkit"
```

## Features

```
Include introduction for the features included and information about new and upcoming features in the future.
```

### Scriptable Event System  

Scriptable Event System is a core features to build on top of ScriptableObjects as an Event system. Event architectures help modularize your code by sending messages between systems that do not directly know about each other. They allow things to respond to a change in state without constantly monitoring it in an update loop.

#### Creation of New Events Types

Here is an example script for generating GameObject based events **GameObjectChannelSO.cs**

```c#

// STEP 1: Include the namespace.
using Undefined.CommonFeaturesToolkit.ScriptableEventSystem;

// STEP 2: Define a new scriptable object and inherit from ChannelReceiver.ChannelSO for the desired type.
// IMPORTANT: The class must match the name of the file for unity to correctly associated with the CreateAssetMenu.
[UnityEngine.CreateAssetMenu(fileName = "New GameObjectChannelSO", menuName = "Game Events/GameObjectChannelSO")]
public sealed class GameObjectChannelSO : ChannelReceiver.ChannelSO<UnityEngine.GameObject> { }

// STEP 3: Define a new type defined from ChannelReceiver.Channel to expose to the inspector.
// IMPORTANT: This must be defined for the inspector to correctly find the type during reflection.
public sealed class GameObjectChannel : ChannelReceiver.Channel<UnityEngine.GameObject, GameObjectChannelSO, UnityEngine.Events.UnityEvent<UnityEngine.GameObject>> { }

```

**It is important to not that the these events can be created using most primitive types but can also be defined by using custom classes including several types.**

#### Interface and Listening for Events

Selecting type based on the previously defined interfaces through reflection.

![Channel Receiver - Interface Selection](/Documentation/Images/ChannelReceiver-InterfaceSelection.png "Channel Receiver - Interface Selection")

Interface expansion once type is defined and adjustable fields for suitable event responses.

![Channel Receiver - Empty Interface](/Documentation/Images/ChannelReceiver-EmptyInterface.png "Channel Receiver - Empty Interface")

## License 

Common-Features-Toolkit is licensed under the [MIT](#) license. 

Copyright &copy; 2021, Christopher Atkinson.

[shield-unity]: https://img.shields.io/badge/unity%20support-2018.4.36-brightgreen.svg
[shield-odin_inspector]: https://img.shields.io/badge/odin_inspector%20support-3.0.12-brightgreen.svg
[shield-license]: https://img.shields.io/badge/license-MIT-blue.svg
