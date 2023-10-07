using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "ScriptableObjects/Items/Armor/Body Item")]
public class Body : ArmorItem
{
    public override ArmorSlots Slot => ArmorSlots.Body;
}
