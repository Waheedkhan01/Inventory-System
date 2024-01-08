using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is responsible for storing the items that the character has collected.
/// Each character has their own inventory.
/// Charater component is required.
/// </summary>
public class Inventory : MonoBehaviour
{
    private Character character; // Reference to the character component on this game object.

    public Dictionary<Item, int> inventory = new(); // Dictionary of items and their quantities.

    private void Awake()
    {
        character = GetComponent<Character>();
        if (character == null)
        {
            Debug.LogError("Character component not found on " + gameObject.name);
        }
    }


    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item]++;
        }
        else
        {
            inventory.Add(item, 1);
        }
    }


    /// <summary>
    /// Equips or uses an item from the inventory.
    /// </summary>
    /// <param name="item"></param>
    public void EquipUseItem(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            if (item.Type == Item.ItemCategory.Equipment)
            {
                character.EquipItem(item);
            }
            else if (item.Type == Item.ItemCategory.Consumable)
            {
                character.UseItem(item);
                RemoveItem(item);
            }
        }
    }


    /// <summary>
    /// Drops an item from the inventory.
    /// </summary>
    /// <param name="item"></param>
    public void DropItem(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            character.DropItem(item);
            RemoveItem(item);
        }
    }
    

    /// <summary>
    /// Removes an item from the inventory.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item]--;
            if (inventory[item] <= 0)
            {
                inventory.Remove(item);
            }
        }
    }
}
