using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public static PlayerStats plStats;
    public float health;
    public float maxHealth;
    public float speed;
    public int keys;
    public int damage;
    public int manna;
    public int maxManna;

    public int bitCoins;
    public int souls;

    public bool isEnabled = false;
    private bool isVenom;
    public bool isBurn = false;
    void Start()
    {
        plStats = this;
        health = maxHealth;
        manna = maxManna;
        StartCoroutine(getManna(10));
    }
    public void getDamage(float damage)
    {
        //hBarPlayer.SetActive(true)
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //SceneManager.LoadScene(1);
    }
    public void getHeal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    IEnumerator getManna(int mannaIteration)
    {
        while (true) {
            manna += mannaIteration;
            yield return new WaitForSeconds(3);
            if (manna > maxManna)
            {
                manna = maxManna;
                yield return null;
            }
        }
    }

    public IEnumerator Poison(int Damage, int count, int delay)
    {
        Damage = 5;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(delay);
            getDamage(Damage);
        }
    }
    public void GetManna(int Manna)
    {
        manna += Manna;
        if (manna > maxManna)
        {
            manna = maxManna;
        }
    }
}
