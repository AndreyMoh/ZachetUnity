using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Rooms templates;

    public static Room Instance;

    private bool IsBoss = false;
    private bool IsSpawned = false;

    public List<GameObject> Enemies;

    void Start()
    {
        Instance = this;

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Rooms>();
        templates.rooms.Add(this.gameObject);
    }

    public void SpawnBoss()
    {
        IsBoss = true;
        Instantiate(templates.bossPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnEnemies()
    {
        int count = Random.Range(0, 10);
        for (int i = 0; i < count; i++)
        {
            Vector3 point = (Random.insideUnitSphere * 15) + gameObject.transform.position;
            GameObject enemy = Instantiate(templates.Enemies[Random.Range(0, templates.Enemies.Length)], point, Quaternion.identity);
            Enemies.Add(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!IsBoss && !IsSpawned) 
            {
                IsSpawned = true;
                Invoke("SpawnEnemies", 1);
            }

            if (!IsBoss)
            {
                EnemyAttackingOn();
            }
            else
            {
                BossScript.instance.IsAttacking = true;
                Debug.Log(BossScript.instance.IsAttacking);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!IsBoss)
            {
                EnemyAttackingOff();
            }
            else
            {
                Debug.Log(BossScript.instance.IsAttacking);
                BossScript.instance.IsAttacking = false;
            }
        }
    }

    public void EnemyAttackingOn()
    {
        foreach (var enemy in Enemies)
        {
            enemy.GetComponent<TriggerAttacking>().IsAttacking = true;
        }
    }
    
    public void EnemyAttackingOff()
    {
        foreach (var enemy in Enemies)
        {
            enemy.GetComponent<TriggerAttacking>().IsAttacking = false;
        }
    }
}
