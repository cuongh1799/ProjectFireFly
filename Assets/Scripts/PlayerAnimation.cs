using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If move, value is -1 or 1
        // Else value is 0

        if(playerMovement.moveDirection.x != 0)
        {
            animator.SetBool("Move", true);
        }
        else if(playerMovement.moveDirection.x == 0)
        {
            animator.SetBool("Move", false);
        }

        SpriteDirectionCheck();
    }

    void SpriteDirectionCheck()
    {
        if(playerMovement.LastHorizontalVector > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
