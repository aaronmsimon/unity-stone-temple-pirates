using UnityEngine;

namespace STP.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}