using UnityEngine;

[CreateAssetMenu(fileName = "Arms", menuName = "ScriptableObjects/Items/Armor/Arms Item")]
public class Arms : ArmorItem
{
    public override ArmorSlots Slot => ArmorSlots.Arms;
}
