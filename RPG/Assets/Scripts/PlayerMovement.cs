using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movementSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    void Update()
    {
ProcessInputs();
    }
    
  void FixedUpdate()
  {
  Move();
  }
  
  void ProcessInputs()
  {
      float moveX = Input.GetAxisRaw("Horizontal");
      float moveY = Input.GetAxisRaw("Vertical");
      moveDirection = new Vector2(moveX, moveY).normalized;
  }

  void Move()
  {
      rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
  }
}
