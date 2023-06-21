using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomeSpell : MonoBehaviour
{

    public PlayerController playerController;
    public PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
        
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = Stats.Damage;
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        EnemyCloser enemyCloser = collision.gameObject.GetComponent<EnemyCloser>();
        if (enemyCloser != null)
        {
            enemyCloser.destroy();
            Destroy(gameObject);
        }

        // Boss collision
        BossScript boss = collision.gameObject.GetComponent<BossScript>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }

        // Wall collision
        Wallscript wall = collision.gameObject.GetComponent<Wallscript>();
        if (wall != null)
        {
            Destroy(gameObject);
        }
    }
}
