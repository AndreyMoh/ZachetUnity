using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ItemScript;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Create New Ability")]
public class AbilityScript : ScriptableObject
{
    public int id;
    public int value;
    public int cooldown;
    public int attackSpeed;
    public bool isCooldown;
    public Sprite icon;
    public Sprite effect;
    public AbilityType type;
    public GameObject pref;

    public enum AbilityType
    {
        FrozenBall, 
        Freeze, 
        MegaPower
    }
}
