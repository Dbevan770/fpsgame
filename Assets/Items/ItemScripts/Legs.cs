using UnityEngine;

[CreateAssetMenu(fileName = "Legs", menuName = "ScriptableObjects/Items/Armor/Legs Item")]
public class Legs : ArmorItem
{
    public override ArmorSlots Slot => ArmorSlots.Legs;
}
