using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemiesScript : MonoBehaviour
{
    public GameObject[] enemies;

    void Start()
    {
        Destroy(gameObject, 20);
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        if (GetComponent<TriggerAttacking>().IsAttacking)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            while (true)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(10);
            }
        }
    }
}
