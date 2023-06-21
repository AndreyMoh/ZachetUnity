using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloser : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerFeatures Stats;

    GameObject player;
    Rigidbody2D rigidBody2D;

    public float speed;
    public int bodyDamage;
    private bool IsTouch = false;

    float horizontal, vertical;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;

        player = GameObject.FindWithTag("Player");
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 plPos = player.transform.position;
        Vector2 myPos = transform.position;
        Debug.DrawLine(plPos, myPos);
        Vector2 wrongDistance = plPos - myPos;
        if (Math.Abs(wrongDistance.x) < 10 && Math.Abs(wrongDistance.y) < 10 && GetComponent<TriggerAttacking>().IsAttacking)
        {
            //rigidBody2D.velocity = new Vector2(horizontal * speed * plPos.x, vertical * speed * plPos.y);
            rigidBody2D.velocity = (plPos - myPos) * speed;
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0, 0);
        }
    }
    IEnumerator MakeDamage(int damage)
    {
        if (IsTouch)
        {
            playerController.getDamage(bodyDamage);
            yield return new WaitForSeconds(1);
        }
        else yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouch = true;
        StartCoroutine(MakeDamage(bodyDamage));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouch = false;
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}
