using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "ScriptableObjects/Items/Armor/Helmet Item")]
public class Helmet : ArmorItem
{
    public override ArmorSlots Slot => ArmorSlots.Helmet;
}
