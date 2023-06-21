using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    
    float horizontal, vertical;
    Vector2 direction;
    Animator animator;
    Rigidbody2D rigidBody2D;
    void Start()
    {
        Instance = this;

        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void AnimatorMovement(float x, float y)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("DirectionX", x);
        animator.SetFloat("DirectionY", y);
    }
    private void FixedUpdate()
    {
        if (horizontal != 0 || vertical != 0)
        {
            AnimatorMovement(horizontal, vertical);

        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        rigidBody2D.velocity = new Vector2(horizontal * PlayerStats.plStats.speed, vertical * PlayerStats.plStats.speed);
    }
}
