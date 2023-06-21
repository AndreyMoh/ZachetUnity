using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BossScript : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerFeatures Stats;

    public static BossScript instance;

    GameObject player;
    Rigidbody2D rigidBody2D;
    Animator animator;

    public GameObject BossChestPrefab;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public float health;
    public float maxHealth;
    public float damage;
    public bool IsAttacking;

    public float speed;
    public int bodyDamage;
    public int attackSpeed;

    private bool IsTouch = false;
    private bool modeOfShooting = false;
    private float cooldown = 2;

    Slider HpSlider;

    float horizontal, vertical;
    void Start()
    {
        instance = this;

        health = maxHealth;

        HpSlider = gameObject.GetComponentInChildren<Slider>();
        HpSlider.maxValue = health;
        HpSlider.value = health;

        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;

        player = GameObject.FindWithTag("Player");
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InvokeRepeating("BossShoot", cooldown, cooldown);
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 plPos = player.transform.position;
        Vector2 myPos = transform.position;
        Debug.DrawLine(plPos, myPos);
        Vector2 wrongDistance = plPos - myPos;
        if (Math.Abs(wrongDistance.x) < 18 && Math.Abs(wrongDistance.y) < 18 && IsAttacking)
        {
            //rigidBody2D.velocity = new Vector2(horizontal * speed * plPos.x, vertical * speed * plPos.y);
            animator.SetBool("IsVisible", true);
            rigidBody2D.velocity = (plPos - myPos) * speed;
        }
        else
        {
            animator.SetBool("IsVisible", false);
            rigidBody2D.velocity = new Vector2(0, 0);
        }
    }

    public void BossShoot()
    {
        Debug.Log("Boss" + IsAttacking);
        if (IsAttacking)
        {
            if (!modeOfShooting)
            {
                // single mode

                GameObject spell = Instantiate(BulletPrefab1, transform.position, Quaternion.identity);
                Vector2 targetPosition = player.GetComponent<Transform>().position;
                Vector2 myPosition = transform.position;
                Vector2 direction = targetPosition - myPosition;
                spell.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
                Destroy(spell, 3);

                //Debug.Log("Single Mode");
                modeOfShooting = true;
            }
            else
            {
                // multi mode

                GameObject spell1 = Instantiate(BulletPrefab2, transform.position, Quaternion.identity);
                Vector2 targetPosition = player.GetComponent<Transform>().position;
                Vector2 myPosition = transform.position;
                Vector2 direction = targetPosition - myPosition;
                spell1.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
                Destroy(spell1, 3);

                GameObject spell2 = Instantiate(BulletPrefab2, transform.position, Quaternion.identity);
                Vector2 direction2 = direction + new Vector2(-1, -2);
                spell2.GetComponent<Rigidbody2D>().velocity = direction2 * attackSpeed;
                Destroy(spell2, 3);

                GameObject spell3 = Instantiate(BulletPrefab2, transform.position, Quaternion.identity);
                Vector2 direction3 = direction + new Vector2(1, -2);
                spell3.GetComponent<Rigidbody2D>().velocity = direction3 * attackSpeed;
                Destroy(spell3, 3);

                //Debug.Log("Multi Mode");
                modeOfShooting &= false;
            }
        }
        
    }

    IEnumerator MakeDamage(int damage)
    {
        if (IsTouch)
        {
            playerController.getDamage(bodyDamage);
            yield return new WaitForSeconds(1);
        }
        else yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouch = true;
        StartCoroutine(MakeDamage(bodyDamage));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouch = false;
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        HpSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Stats.Souls += 5;
        Instantiate(BossChestPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
