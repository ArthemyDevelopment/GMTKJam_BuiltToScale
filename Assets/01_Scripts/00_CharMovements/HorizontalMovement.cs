using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float F_walkSpeed;
    [SerializeField] private bool B_CanMove=false;


    enum Direction
    {
        Right,
        Left,
        Fall,
    }

    [SerializeField] private Direction En_MoveDirection;
    private Direction En_PrevDir;
    
    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (!B_CanMove)
        {
            rb.velocityX = 0;
            return;
        }
        
        switch (En_MoveDirection)
        {
            case Direction.Right:
                rb.velocityX = F_walkSpeed;
                break;
            case Direction.Left:
                rb.velocityX = -F_walkSpeed;
                break;
            case Direction.Fall:
                rb.velocityX = 0 ;
                break;
        }
    }

    public void OnFall()
    {
        En_PrevDir = En_MoveDirection;
        En_MoveDirection = Direction.Fall;
    }

    public void OnLand()
    {
        En_MoveDirection = En_PrevDir;
    }

    public void ChangeMoveDirection()
    {
        En_MoveDirection = 
            En_MoveDirection == Direction.Right ? Direction.Left 
                : Direction.Right;
    }

    public void StopMovement()
    {
        B_CanMove = false;
    }

    public void StartMovement()
    {
        rb.simulated = true;
        B_CanMove = true;
    }
}
