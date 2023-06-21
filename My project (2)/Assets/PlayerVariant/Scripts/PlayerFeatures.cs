using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Player")]

public class PlayerFeatures : ScriptableObject
{
    public float hp;
    public float maxHp;
    public float mana;
    public float maxMana;
    public float MaxDamage;
    public float MinDamage;
    public float moveSpeed;
    public float attackSpeed;
    public float manaRegen;
    public float manaCost;

    public float Damage;

    public bool isEnabled = false;
    private bool isVenom;
    public bool isBurn = false;

    public Sprite skin;
    public GameObject PlayerPrefab;
    public GameObject BulletPrefab;
    public RuntimeAnimatorController PlayerAnimator;
    public Transform PlayerSpawnPoint;

    public int BitCoins;
    public int Souls;
    public int Keys; 
}
