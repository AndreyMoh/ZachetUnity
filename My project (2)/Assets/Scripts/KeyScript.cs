using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Stats.Keys += 1;
            Destroy(gameObject);
        }
    }
}
