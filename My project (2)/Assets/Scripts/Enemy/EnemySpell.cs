using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public int damage;
    public PlayerController playerController;
    public PlayerFeatures Stats;

    Enemy elements;

    public GameObject explosion;
    void Start()
    {
        Destroy(gameObject, 3);
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
        elements = GameObject.FindObjectOfType<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            if (elements.isExplosion)
            {
                GameObject exp = Instantiate(explosion, player.transform.position, Quaternion.identity);
                elements.isExplosion = false;
                Destroy(exp, 4);
            }
            playerController.getDamage(damage);
            Destroy(gameObject);
        }
    }
}
