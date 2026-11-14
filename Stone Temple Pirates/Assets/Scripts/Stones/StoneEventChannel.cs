using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Stone Event Channel")]
public class StoneEventChannel : ScriptableObject
{
    public event UnityAction<Stone, Vector3> stoneActivatedEvent;
    public void RaiseActivated(Stone stone, Vector3 position) =>
        stoneActivatedEvent?.Invoke(stone, position);
}