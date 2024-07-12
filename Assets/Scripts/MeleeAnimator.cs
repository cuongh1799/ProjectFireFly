using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    PlayerMovement playerMovement;
    Animator animator;
    public Transform melee_transform;

    public Transform target; // reference the player
    void Start()
    {
        transform.position = target.position + new Vector3(-1,0,0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();   
        animator = GetComponent<Animator>();    
        animator.SetBool("slash", false);
        melee_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(-1, 0, 0);
        if (Input.GetAxisRaw("Fire1") == 1){
            animator.SetBool("slash", true);
            Invoke("resetMelle", 1);
        }
        //LookToMouse();
    }

    void resetMelle()
    {
        animator.SetBool("slash", false );
    }

    // this function doesnt work cuz the anchor point of sprite is not in the middle
    // may need to change the sprite later
    private void LookToMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - melee_transform.position;
        float angleRotate = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angleRotate, Vector3.forward);
        melee_transform.rotation = rotation;

        // Flip the sprite based on the mouse position
        if (direction.x >= 0)
        {
            // Mouse is on the right, so ensure the sprite is not flipped
            spriteRenderer.flipY = false;
        }
        else
        {
            // Mouse is on the left, so flip the sprite
            spriteRenderer.flipY = true;
        }
    }
}
