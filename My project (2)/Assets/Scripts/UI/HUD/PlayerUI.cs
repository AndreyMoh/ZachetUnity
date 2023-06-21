using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI plBars;

    public Slider hpBar;
    public Slider mannaBar;

    public GameObject coinsBar;
    public GameObject soulsBar;
    public GameObject keysBar;

    public GameObject attackSpeedBar;
    public GameObject moveSpeedBar;
    public GameObject damageBar;
    public GameObject maxHpBar;

    public PlayerController playerController;
    public PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }

    void Update()
    {
        hpBar.maxValue = Stats.maxHp;
        hpBar.value = Stats.hp;

        mannaBar.maxValue = Stats.maxMana;
        mannaBar.value = Stats.mana;
        hpBar.GetComponentInChildren<TMP_Text>().text = Stats.hp.ToString();
        mannaBar.GetComponentInChildren<TMP_Text>().text = Stats.mana.ToString();

        coinsBar.GetComponentInChildren<TMP_Text>().text = Stats.BitCoins.ToString();
        soulsBar.GetComponentInChildren<TMP_Text>().text = Stats.Souls.ToString();
        keysBar.GetComponentInChildren<TMP_Text>().text = Stats.Keys.ToString();

        attackSpeedBar.GetComponentInChildren<TMP_Text>().text = Stats.attackSpeed.ToString();
        moveSpeedBar.GetComponentInChildren<TMP_Text>().text = Stats.moveSpeed.ToString();
        damageBar.GetComponentInChildren<TMP_Text>().text = Stats.Damage.ToString();
        maxHpBar.GetComponentInChildren<TMP_Text>().text = Stats.maxHp.ToString();
    }
}
