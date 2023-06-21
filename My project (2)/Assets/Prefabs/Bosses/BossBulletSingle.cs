using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSingle : MonoBehaviour
{
    public float damage;
    
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            playerController.getDamage(damage);
            Destroy(gameObject);
        }
    }
}
