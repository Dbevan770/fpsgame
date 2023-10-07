using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    // Private Item properties
    [SerializeField]
    private string _name = "";
    [SerializeField]
    private Rarity _rarity;
    [SerializeField]
    private string _description = "";

    // Getters and Setters
    public string Name { get { return _name; } set { _name = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public Rarity Rarity { get { return _rarity;  } }
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary,
    Epic,
}
