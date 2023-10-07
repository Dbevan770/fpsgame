public abstract class ArmorItem : EquipableItem
{
    // Getters and Setters
    public abstract ArmorSlots Slot { get; }
}

public enum ArmorSlots
{
    Helmet,
    Body,
    Arms,
    Legs,
    Back,
}
