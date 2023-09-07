using UnityEngine;
using UnityEngine.Events;

namespace STP.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with")]
        public GameEvent gameEvent;

        [Tooltip("Response to invoke when Event is raised")]
        public UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response?.Invoke();
        }
    }
}