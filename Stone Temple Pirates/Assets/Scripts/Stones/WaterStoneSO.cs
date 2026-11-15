using UnityEngine;

[CreateAssetMenu(menuName = "Stones/Water Stone")]
public class WaterStoneSO : StoneSO
{
    public override void Activate(Player player)
    {
        // water-specific self effect: aim tint, VFX, SFX...
    }
}