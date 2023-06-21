using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class VempireSpell : MonoBehaviour
{
    private int Damage;
    public PlayerController playerController;
    public PlayerFeatures Stats;

    //private bool isVenom = false;
    void Start()
    {
        Damage = 10;
        Destroy(gameObject, 3);
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
        if (player != null)
        {
            playerController.getDamage(Damage);
            //StartCoroutine(StartCoroutine(stats.Poison(5, 3, 1)));
            Destroy(gameObject);
        }
    }
}
