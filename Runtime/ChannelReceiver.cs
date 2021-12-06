using Sirenix.OdinInspector;
using System.Linq;

namespace Undefined.CommonFeaturesToolkit
{
    public sealed class ChannelReceiver : SerializedMonoBehaviour
    {
        [Required]
        public ISelectableChannel m_selectableChannel;

        public void OnDisable() => m_selectableChannel.OnDisable(m_selectableChannel);

        public void OnEnable() => m_selectableChannel.OnEnable(m_selectableChannel);

        public abstract class ChannelSO<T> : SerializedScriptableObject
        {
            private readonly System.Collections.Generic.HashSet<ISelectableChannel> m_hashset =
                new System.Collections.Generic.HashSet<ISelectableChannel>();

            public void UnregisterListener(ISelectableChannel channel) => m_hashset.Remove(channel);

            public void RegisterListener(ISelectableChannel channel) => m_hashset.Add(channel);

            public void Raise(T obj) { foreach (var current in m_hashset.Reverse()) { current?.Raise(obj); } }
        }

        [HideLabel, InlineEditor]
        public abstract class Channel<T1, T2, T3> : ISelectableChannel
            where T2 : ChannelSO<T1> where T3 : UnityEngine.Events.UnityEvent<T1>
        {
            [UnityEngine.SerializeField, Required(InfoMessageType.Warning)]
            private T2 m_scriptableObjectEvent = default;

            [DrawWithUnity]
            [UnityEngine.SerializeField]
            private T3 m_unityEventResponse = (T3)System.Activator.CreateInstance(typeof(T3));

            public void OnDisable(ISelectableChannel channel) => m_scriptableObjectEvent?.UnregisterListener(channel);

            public void OnEnable(ISelectableChannel channel) => m_scriptableObjectEvent?.RegisterListener(channel);

            public void Raise(object obj) => m_unityEventResponse?.Invoke((T1)obj);
        }

        [HideLabel, InlineEditor, InlineProperty]
        public interface ISelectableChannel
        {
            void Raise(object obj);

            void OnDisable(ISelectableChannel channel);

            void OnEnable(ISelectableChannel channel);
        }
    }
}
