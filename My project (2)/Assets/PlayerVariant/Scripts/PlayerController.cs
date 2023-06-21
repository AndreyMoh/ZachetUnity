using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    float horizontal, vertical;
    Vector2 direction;
    Animator animator;
    Rigidbody2D rigidBody2D;

    public PlayerFeatures playerFeatures;

    public List<UpgradeScript> Upgrades = new List<UpgradeScript>(16);

    void Start()
    {
        Instance = this;

        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        
        StartCoroutine(getManna(playerFeatures.manaRegen));
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void AnimatorMovement(float x, float y)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("DirectionX", x);
        animator.SetFloat("DirectionY", y);
    }
    private void FixedUpdate()
    {
        if (horizontal != 0 || vertical != 0)
        {
            AnimatorMovement(horizontal, vertical);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        rigidBody2D.velocity = new Vector2(horizontal * playerFeatures.moveSpeed, vertical * playerFeatures.moveSpeed);
    }
    public void getDamage(float damage)
    {
        playerFeatures.hp -= playerFeatures.Damage;
        if (playerFeatures.hp <= 0)
        {
            playerFeatures.hp = playerFeatures.maxHp;
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void getHeal(int heal)
    {
        playerFeatures.hp += heal;
        if (playerFeatures.hp > playerFeatures.maxHp)
        {
            playerFeatures.hp = playerFeatures.maxHp;
        }
    }
    IEnumerator getManna(float manaIteration)
    {
        while (true)
        {
            if (playerFeatures.mana > playerFeatures.maxMana)
            {
                playerFeatures.mana = playerFeatures.maxMana;
                yield return null;
            }
            playerFeatures.mana += manaIteration;
            yield return new WaitForSeconds(3);
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
        playerFeatures.mana += Manna;
        if (playerFeatures.mana > playerFeatures.maxMana)
        {
            playerFeatures.mana = playerFeatures.maxMana;
        }
    }
    public void DamageUp(int percentages)
    {
        float value = playerFeatures.Damage / 100 * percentages;

        playerFeatures.Damage += value;
    }

    public void HealthUp(int percentages)
    {
        playerFeatures.maxHp += playerFeatures.maxHp / 100 * percentages;
    }

    public void ManaFullUp(int percentages)
    {
        playerFeatures.maxMana += playerFeatures.maxMana / 100 * percentages;
    }
    public void AttackSpeedUp(int percentages)
    {
        playerFeatures.attackSpeed += playerFeatures.attackSpeed / 100 * percentages;
    }
    public void MoveSpeedUp(int percentages)
    {
        playerFeatures.moveSpeed += playerFeatures.moveSpeed / 100 * percentages;
    }
    public void ManaRegenUp(int percentages)
    {
        playerFeatures.manaRegen += playerFeatures.manaRegen / 100 * percentages;
    }
    public void ManaCostDown(int percentages)
    {
        playerFeatures.manaCost -= playerFeatures.manaCost / 100 * percentages;
    }
    public void RemoveSouls(int amount)
    {
        playerFeatures.Souls -= amount;
    }
}
