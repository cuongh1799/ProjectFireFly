using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D player;

    [HideInInspector]
    public Vector2 moveDirection;
    

    // Use for recording last input before stop moving
    // Later on use this to decide which direction the sprite will look at
    [HideInInspector]
    public float LastHorizontalVector; 
    public float LastVerticalVector;
    bool jumping = false;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame -> frame dependant
    void Update()
    {
        getInput();
    }

    private void FixedUpdate() // not frame dependent
    {
        move();
    }

    void getInput()
    {
        // See all the Axis in Project Setting > Input Managager

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float sprint = Input.GetAxisRaw("Sprint");
        moveDirection = new Vector2 (moveX, moveY).normalized;

        if(sprint == 1)
        {
            movementSpeed = 20;
        }
        else
        {
            movementSpeed = 10;
        }

        if (moveDirection.x != 0)
        {
            LastHorizontalVector = moveDirection.x;
        }

        if (moveDirection.y != 0)
        {
            LastVerticalVector = moveDirection.y;
        }

    }

    void move()
    {
        player.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

}
