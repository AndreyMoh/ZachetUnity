using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Create New Upgrade")]

public class UpgradeScript : ScriptableObject
{
    public int cost;
    public int value;
    public int counter = 0;
    public Sprite icon;

    public bool isUsed;

    public UpgradeType type;

    public enum UpgradeType
    {
        Damage, 
        Health, 
        Mana, 
        AttackSpeed, 
        MoveSpeed, 
        ManaRegen, 
        ManaCost
    }
}
