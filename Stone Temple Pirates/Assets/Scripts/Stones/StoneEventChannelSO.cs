using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Stone Event Channel")]
public class StoneEventChannelSO : ScriptableObject
{
    public event UnityAction<StoneSO> stoneActivatedEvent;

    public void RaiseActivated(StoneSO stone) {
        stoneActivatedEvent?.Invoke(stone);
    }
}