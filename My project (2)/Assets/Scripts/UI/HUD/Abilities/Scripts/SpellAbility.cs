using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAbility : MonoBehaviour
{
    public AbilityScript Ability;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Ability.value);
            Destroy(gameObject);
        }

        EnemyCloser enemyCloser = collision.gameObject.GetComponent<EnemyCloser>();
        if (enemyCloser != null)
        {
            enemyCloser.destroy();
            Destroy(gameObject);
        }

        Wallscript wall = collision.gameObject.GetComponent<Wallscript>();
        if (wall != null)
        {
            Destroy(gameObject);
        }

        BossScript bossScript = collision.gameObject.GetComponent<BossScript>();
        if (bossScript != null)
        {
            bossScript.TakeDamage(Ability.value);
            Destroy(gameObject);
        }
    }
}
