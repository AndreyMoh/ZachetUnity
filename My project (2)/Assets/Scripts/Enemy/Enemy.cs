using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public GameObject pref;
    public GameObject[] loot;
    public GameObject coffin;
    GameObject player;
    public float force;
    public float cooldown;

    public int bodyDamage;
    private Slider slider;

    private int Counter = 0;
    public bool isExplosion = false;

    public PlayerController playerController;
    public PlayerFeatures stats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("EnemyShooting", cooldown, cooldown);
        playerController = FindObjectOfType<PlayerController>();
        stats = playerController.playerFeatures;
        slider = gameObject.GetComponentInChildren<Slider>();

        //enemyStuffs = this;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        slider.value = slider.value - (float) damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Vector3 position = gameObject.transform.position;
        Destroy(gameObject);
        stats.Souls += 1;
        int count = Random.Range(0, loot.Length);
        GameObject stuf = loot[count];
        Instantiate(stuf, position, Quaternion.identity);
        Instantiate(coffin, position, Quaternion.identity);
    }
    //private void Update()
    //{
        
    //}
    public void EnemyShooting() { 
        if (GetComponent<TriggerAttacking>().IsAttacking)
        {
            if (Counter == 3)
            {
                pref.GetComponent<Transform>().localScale.Set(2, 2, 1);
                isExplosion = true;
                Counter = 0;
            }
            else
            {
                pref.GetComponent<Transform>().localScale.Set(1, 1, 1);
                GameObject spell = Instantiate(pref, transform.position, Quaternion.identity);
                Vector2 targetPosition = player.GetComponent<Transform>().position;
                Vector2 myPosition = transform.position;
                Vector2 direction = targetPosition - myPosition;
                spell.GetComponent<Rigidbody2D>().velocity = direction * force;
                Counter++;
                Destroy(spell, 3);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            playerController.getDamage(bodyDamage);
        }
    }
}
