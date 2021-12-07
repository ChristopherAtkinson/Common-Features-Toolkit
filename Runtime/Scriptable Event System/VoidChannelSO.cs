using Undefined.CommonFeaturesToolkit.ScriptableEventSystem;

[UnityEngine.CreateAssetMenu(menuName = "Scriptable Event System/UnityEngine/Void Channel")]
public sealed class VoidChannelSO : ChannelReceiver.ChannelSO<Void> { public void Raise() => Raise(new Void()); }

public sealed class VoidChannel : ChannelReceiver.Channel<Void, VoidChannelSO, UnityEngine.Events.UnityEvent<Void>> { }

public class Void { }