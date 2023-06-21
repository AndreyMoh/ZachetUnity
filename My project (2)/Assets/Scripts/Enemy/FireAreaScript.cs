using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class FireAreaScript : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerFeatures Stats;

    private int Damage;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }

    void Update()
    {
        //if (stats.isBurn)
        //    stats.getDamage(Damage);
    }
    IEnumerator damage(int damage)
    {
        while (true)
        {
            if (Stats.isBurn)
            {
                playerController.getDamage(damage);
                yield return new WaitForSeconds(1);
            }
            else
                yield return null;
        }
    }
    IEnumerator AfterFire(int damage)
    {
        for (int i = 0; i < 1; i++)
        {
            if (Stats.isBurn)
            {
                playerController.getDamage(damage);
                yield return new WaitForSeconds(2);
            }
            else break;
        }
        Stats.isBurn = false;
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            Damage = 10;
            Stats.isBurn = true;
            StartCoroutine(damage(Damage));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            //stats.isBurn = false;
            Damage = 5;
            StartCoroutine(AfterFire(Damage));
        }
    }
}
