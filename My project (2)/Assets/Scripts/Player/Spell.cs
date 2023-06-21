using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerFeatures Stats;

    Camera cam;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;

        cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Stats.mana > 0)
            {
                Stats.mana -= Stats.manaCost;

                GameObject spell = Instantiate(Stats.BulletPrefab, transform.position, Quaternion.identity);
                Vector2 mPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPosition = transform.position;
                Vector2 direction = mPosition - myPosition;
                spell.GetComponent<Rigidbody2D>().velocity = direction * Stats.attackSpeed;
                Destroy(spell, 6);
            }
            
        }
    }
}
