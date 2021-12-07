using Undefined.CommonFeaturesToolkit.ScriptableEventSystem;

[UnityEngine.CreateAssetMenu(menuName = "Scriptable Event System/UnityEngine/Int Channel")]
public sealed class IntChannelSO : ChannelReceiver.ChannelSO<int> { }

public sealed class IntChannel : ChannelReceiver.Channel<int, IntChannelSO, UnityEngine.Events.UnityEvent<int>> { }