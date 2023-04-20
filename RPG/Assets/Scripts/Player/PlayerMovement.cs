using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private FixedJoystick _joystick;
    private Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Instance = this; нигде не используем тут
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = movement.normalized;
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        
        movement.x = _joystick.Horizontal;
        movement.y = _joystick.Vertical;
        

        animator.SetFloat("Horizontal", movement.x); //run walk animation
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", Mathf.Abs(movement.sqrMagnitude));
        
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            
            spriteRenderer.flipX = true;
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }*/

        if (_joystick.Vertical < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public void SpeedUp(int value) //баф скорости от зелья в инвентаре
    {
        movementSpeed += value;
    }
}