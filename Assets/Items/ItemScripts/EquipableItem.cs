using UnityEngine;

public class EquipableItem : Item
{
    // Private properties
    private bool _isEquipable = true;

    public bool IsEquipable { get { return _isEquipable; } }
}
