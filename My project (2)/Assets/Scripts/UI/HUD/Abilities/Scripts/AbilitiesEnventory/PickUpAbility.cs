using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : MonoBehaviour
{
    public AbilityScript Ability;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null )
        {
            if (!AbilitiesPanelController.Instance.Abilities.Contains(Ability))
            {
                PickUp();
            }
            else return;
        }
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
    }
    public void PickUp()
    {
        AbilitiesEnventoryController.Instance.Add(Ability);
        Destroy(gameObject);
    }
}
