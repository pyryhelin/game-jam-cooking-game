using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement variables + objects
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    // Animator variables + objects
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    // Movement updates happen in here, so it's in sync with the physics engine
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Flips character graphics when changing side direction
        if (movement.x < 0 && facingRight){
            Flip();
        }
        else if (movement.x > 0 && !facingRight){
            Flip();
        }
    }


    // Flips character graphics 
    void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

}
