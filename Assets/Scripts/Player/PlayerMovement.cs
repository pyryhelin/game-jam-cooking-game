using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement variables + objects
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    [SerializeField]
    Vector2 movement;

    public Sprite frontSprite;

    public Sprite backSprite;

    public Sprite sideSprite;


    // Animator variables + objects
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    private bool facingBack = false;
    public Vector2 lastDir = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0 || lastDir.x == 0)
            {lastDir.x = 1;
            }
        else if (movement.x < 0 || lastDir.x == 0)

           { lastDir.x = -1;
           }

        if (movement.y > 0 || lastDir.y == 0)
        {
            lastDir.y = 1;
            facingBack = true;
        }
        else if (movement.y < 0 || lastDir.y == 0){
            lastDir.y = -1;
            facingBack = false;
        }
        animator.SetFloat("HorizontalFace", lastDir.x);
        animator.SetFloat("VerticalFace", lastDir.y);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    // Movement updates happen in here, so it's in sync with the physics engine
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // if(movement.y > 0)
        //     spriteRenderer.sprite = backSprite;
        // else if(movement.y < 0)
        //     spriteRenderer.sprite = frontSprite;
        // Flips character graphics when changing side direction
        if (movement.x < 0 && ((facingRight)))
        {
            Flip();
        }
        else if (movement.x > 0 && ((!facingRight)))
        {
            Flip();
        }


        if (lastDir.x < 0 && facingBack && !facingRight && movement.x == 0 )
        {

            Flip();
        }
        else if (lastDir.x > 0 && facingBack && facingRight && movement.x == 0)
        {

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
