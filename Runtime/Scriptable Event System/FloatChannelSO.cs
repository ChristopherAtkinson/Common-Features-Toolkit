using Undefined.CommonFeaturesToolkit.ScriptableEventSystem;

[UnityEngine.CreateAssetMenu(menuName = "Scriptable Event System/UnityEngine/Float Channel")]
public sealed class FloatChannelSO : ChannelReceiver.ChannelSO<float> { }

public sealed class FloatChannel : ChannelReceiver.Channel<float, FloatChannelSO, UnityEngine.Events.UnityEvent<float>> { }