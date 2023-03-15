using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Food, Default, Story, Consumable, Misc, Weapon, Armor, Helmet, OffHand, Boots }

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Item")]
public class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15, 20)] public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public Item()
    {
        Name = "";
        Id = -1;
    }

    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
    }
}