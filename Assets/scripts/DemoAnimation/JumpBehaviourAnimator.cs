using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviourAnimator : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 8f;

    public bool isGrounded;
    private bool isDoubleJump;
    private bool isFalling;
    private Rigidbody2D body;

    public Transform groundCheck;  // Position where the ground check will be done
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle
    public LayerMask groundLayer;  // Layer mask to define what is considered ground
    // Start is called before the first frame update

    //Animator
    private Animator animator;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning("isGrounded:" + isGrounded);
        isFalling = body.velocity.y < 0;
        // Check if the player is pressing the jump key (spacebar)
        if ((Input.GetKeyDown(KeyCode.W) && isGrounded))
        {
            animator.SetInteger("StateIndex", 2);
            Jump();
            
        } else 
        if (Input.GetKeyDown(KeyCode.W) && isDoubleJump)
        {
            if (isFalling) isFalling = false;
            animator.SetInteger("StateIndex", 3);
            Jump();
            isDoubleJump = false;
        }

        // Check if the player is on the ground
        if (!isGrounded && Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            animator.SetInteger("StateIndex", 0);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            isDoubleJump=true;
            isFalling = false;
        }
        if (isFalling)
        {
            animator.SetInteger("StateIndex", 4);
        }
    }
    
    void Jump()
    {
        // Apply an upward force to the player to make them jump
        //body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        // Draw the ground check area in the editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
