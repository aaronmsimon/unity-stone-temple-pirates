using UnityEngine;

public class WaterBody : MonoBehaviour, IStoneReactive
{
    [SerializeField] private StoneEventChannel stoneEventChannel;
    [SerializeField] private float reactRadius = 1f;
    private bool raised;

    private void OnEnable()  => stoneEventChannel.stoneActivatedEvent += OnStoneActivated;
    private void OnDisable() => stoneEventChannel.stoneActivatedEvent -= OnStoneActivated;

    private void OnStoneActivated(Stone stone, Vector3 position)
    {
        if (!CanReactTo(stone.Type)) return;
        if (Vector3.Distance(position, transform.position) > reactRadius) return;
        ReactTo(stone.Type);
    }

    public bool CanReactTo(StoneType type) => type == StoneType.Water;
    public void ReactTo(StoneType type) { raised = !raised; /* animate */ }
}
