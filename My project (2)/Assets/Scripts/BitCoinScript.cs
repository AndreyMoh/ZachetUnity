using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCoinScript : MonoBehaviour
{
    public int denomination;
    private PlayerController playerController;
    private PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.name == "Player" )
        {
            Stats.BitCoins += denomination;
            Destroy( gameObject );
        }
    }
}
