using Undefined.CommonFeaturesToolkit.ScriptableEventSystem;

[UnityEngine.CreateAssetMenu(menuName = "Scriptable Event System/UnityEngine/GameObject Channel")]
public sealed class GameObjectChannelSO : ChannelReceiver.ChannelSO<UnityEngine.GameObject> { }

public sealed class GameObjectChannel : ChannelReceiver.Channel<UnityEngine.GameObject, GameObjectChannelSO, UnityEngine.Events.UnityEvent<UnityEngine.GameObject>> { }