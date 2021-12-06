using Sirenix.OdinInspector;
using System.Linq;

namespace Undefined.CommonFeaturesToolkit.ScriptableEventSystem
{
    /// <summary>
    /// A generic MonoBehaviour that can dynamically assign relative data for events in inspector.
    /// </summary>
    public sealed class ChannelReceiver : SerializedMonoBehaviour
    {
        /// <summary>
        /// Reference to the intended data, this will define the type for the dependant classes.
        /// </summary>
        [Required]
        public ISelectableChannel m_selectableChannel;

        /// <summary>
        /// Unregister the effective channel on disable to ensure consistency.
        /// </summary>
        public void OnDisable() => m_selectableChannel.OnDisable(m_selectableChannel);


        /// <summary>
        /// Register the effective channel on enable to ensure consistency.
        /// </summary>
        public void OnEnable() => m_selectableChannel.OnEnable(m_selectableChannel);


        /// <summary>
        /// ScriptableObject that will allow for the event to link seamlessly across screens.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class ChannelSO<T> : SerializedScriptableObject
        {
            /// <summary>
            /// HashSet of N matching types to Raise the selected events from.
            /// </summary>
            private readonly System.Collections.Generic.HashSet<ISelectableChannel> m_hashset =
                new System.Collections.Generic.HashSet<ISelectableChannel>();

            /// <summary>
            /// Unregister the effective channel on disable to ensure consistency.
            /// </summary>
            /// <param name="channel">The channel which wished to be unregistered.</param>
            public void UnregisterListener(ISelectableChannel channel) => m_hashset.Remove(channel);

            /// <summary>
            /// Register the effective channel on enable to ensure consistency.
            /// </summary>
            /// <param name="channel">The channel which wished to be registered.</param>
            public void RegisterListener(ISelectableChannel channel) => m_hashset.Add(channel);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            public void Raise(T obj) { foreach (var current in m_hashset.Reverse()) { current?.Raise(obj); } }
        }

        /// <summary>
        /// Acts as a class binding to simplify the creation of new events.
        /// </summary>
        /// <typeparam name="T1">The argument type being provided.</typeparam>
        /// <typeparam name="T2">Serialized Scriptable Object declaration assuming of type T1.</typeparam>
        /// <typeparam name="T3">The unity event declaration assuming of type T1.</typeparam>
        [HideLabel, InlineEditor]
        public abstract class Channel<T1, T2, T3> : ISelectableChannel
            where T2 : ChannelSO<T1> where T3 : UnityEngine.Events.UnityEvent<T1>
        {
            /// <summary>
            /// Reference to the Serialized Scriptable Object.
            /// </summary>
            [UnityEngine.SerializeField, Required(InfoMessageType.Warning)]
            private T2 m_scriptableObjectEvent = default;

            /// <summary>
            /// The action to invoke through unity events to allow for default inspector actions.
            /// </summary>
            [UnityEngine.SerializeField, DrawWithUnity]
            private T3 m_unityEventResponse = (T3)System.Activator.CreateInstance(typeof(T3));

            /// <summary>
            /// Unregister the effective channel on disable to ensure consistency.
            /// </summary>
            /// <param name="channel">The channel which wished to be registered.</param>
            public void OnDisable(ISelectableChannel channel) => m_scriptableObjectEvent?.UnregisterListener(channel);

            /// <summary>
            /// Register the effective channel on enable to ensure consistency.
            /// </summary>
            /// <param name="channel">The channel which wished to be registered.</param>
            public void OnEnable(ISelectableChannel channel) => m_scriptableObjectEvent?.RegisterListener(channel);

            /// <summary>
            /// Raise the effective events from UnityEvent<T1>.
            /// </summary>
            /// <param name="obj">The argument to be passed to through the event system, cast as T1.</param>
            public void Raise(object obj) => m_unityEventResponse?.Invoke((T1)obj);
        }

        /// <summary>
        /// This interface in used by odin to direct compatable tpes within unity inspector.
        /// </summary>
        [HideLabel, InlineEditor, InlineProperty]
        public interface ISelectableChannel
        {
            /// <summary>
            /// This function will be used to cast the object from a base type into a usable type T. 
            /// </summary>
            /// <param name="obj">The argument to be passed to through the event system.</param>
            void Raise(object obj);

            /// <summary>
            /// On Disable to expose a pass through to unity's OnDisable.
            /// </summary>
            /// <param name="channel">The channel which wished to be unregistered.</param>
            void OnDisable(ISelectableChannel channel);

            /// <summary>
            /// On Disable to expose a pass through to unity's OnEnable.
            /// </summary>
            /// <param name="channel">The channel which wished to be registered.</param>
            void OnEnable(ISelectableChannel channel);
        }
    }
}
