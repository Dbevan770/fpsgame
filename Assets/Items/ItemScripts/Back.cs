using UnityEngine;

[CreateAssetMenu(fileName = "Back", menuName = "ScriptableObjects/Items/Armor/Back Item")]
public class Back : ArmorItem
{
    public override ArmorSlots Slot => ArmorSlots.Back;
}
