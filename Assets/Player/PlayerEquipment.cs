using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    // Equipment Slots in the inspector
    [SerializeField]
    private Helmet _helment;
    [SerializeField]
    private Body _body;
    [SerializeField]
    private Arms _arms;
    [SerializeField]
    private Legs _legs;
    [SerializeField]
    private Back _back;

    // Equipment Getters and Setters
    public Helmet Helmet
    {
        get { return _helment; }
        set
        {
            if (value != null && value.Slot != ArmorSlots.Helmet)
            {
                Debug.LogError("You cannot equip items other than helmets in the helmet slot");
                return;
            }
            _helment = value;
        }
    }

    public Body Body
    { 
        get { return _body; } 
        set 
        {
            if (value != null && value.Slot != ArmorSlots.Body)
            {
                Debug.LogError("You cannot equip items other than bodys in the body slot");
                return;
            }
            _body = value;
        } 
    }

    public Arms Arms
    {
        get { return _arms; }
        set
        {
            if (value != null && value.Slot != ArmorSlots.Arms)
            {
                Debug.LogError("You cannot equip items other than arms in the arms slot");
                return;
            }
            _arms = value;
        }
    }

    public Legs Legs
    {
        get { return _legs; }
        set
        {
            if (value != null && value.Slot != ArmorSlots.Legs)
            {
                Debug.LogError("You cannot equip items other than legs in the legs slot");
                return;
            }
            _legs = value;
        }
    }

    public Back Back
    {
        get { return _back; }
        set
        {
            if (value != null && value.Slot != ArmorSlots.Back)
            {
                Debug.LogError("You cannot equip items other than backs in the back slot");
                return;
            }
            _back = value;
        }
    }

    public void EquipHelmet(Helmet helmet)
    {
        Helmet = helmet;
    }

    public void UnequipHelmet()
    {
        Helmet = null;
    }

    public void EquipBody(Body body)
    {
        Body = body;
    }

    public void UnequipBody()
    {
        Body = null;
    }

    public void EquipArms(Arms arms)
    {
        Arms = arms;
    }

    public void UnequipArms()
    {
        Arms = null;
    }

    public void EquipLegs(Legs legs)
    {
        Legs = legs;
    }

    public void UnequipLegs()
    {
        Legs = null;
    }

    public void EquipBack(Back back)
    {
        Back = back;
    }

    public void UnequipBack()
    {
        Back = null;
    }
}
