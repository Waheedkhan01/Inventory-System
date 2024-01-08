using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public GameObject itemPrefab;
    public Sprite itemSprite;

    [SerializeField] private string itemName;
    [SerializeField] private ItemCategory itemType;
    [SerializeField] private int itemValue;
    [SerializeField] private int itemWeight;
    [SerializeField] private int itemRarity;


    // Item Effects (Consumable)
    public int effectOnHealth;
    public int effectOnMana;
    public int effectOnStamina;

    //// Item Effects (Equipment)
    //public int effectOnStrength;
    //public int effectOnDexterity;
    //public int effectOnIntelligence;
    //public int effectOnWisdom;
    //public int effectOnCharisma;


    public string Name { get { return itemName; } }
    public int Value { get { return itemValue; } }
    public int Weight { get { return itemWeight; } }
    public int Rarity { get { return itemRarity; } }
    public ItemCategory Type { get { return itemType; } }
    
    public enum ItemCategory
    {
        Equipment,
        Consumable,
        Quest,
    }
}
