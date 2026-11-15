using UnityEngine;

public enum StoneType { Fire, Water, Earth, Air }

public abstract class StoneSO : ScriptableObject
{
    [SerializeField] private StoneType type;
    public StoneType Type => type;

    public abstract void Activate(Player player);
}