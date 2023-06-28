using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : JackalMono
{
    private Rigidbody2D rig;
    private float moveSpeed = 80f; 
    private Animator animator;
    [SerializeField] private Vector2 moveDirection; 
    public Vector2 MoveDirection => moveDirection; 
    void Start()
    {
        animator = GetComponent<Animator>();    
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 0f && moveY == 0f)
        {
            rig.velocity = new Vector2(0, 0);
            return;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        rig.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("RunLeft", moveDirection.x);
        animator.SetFloat("RunRight", moveDirection.y);

    }
    public Transform GetPlayerTransform()
    {
        return transform;
    }
}
