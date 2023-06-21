using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemScript : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public int cost;
    public Sprite icon;
    public ItemType type;
    public GameObject obj;

    public enum ItemType
    {
        Potion, 
        Weapon
    }
}
