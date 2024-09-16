using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 8f;

    private bool isGrounded;
    private bool isDoubleJump;
    private Rigidbody2D body;

    public Transform groundCheck;  // Position where the ground check will be done
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle
    public LayerMask groundLayer;  // Layer mask to define what is considered ground
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is pressing the jump key (spacebar)
        if ((Input.GetKeyDown(KeyCode.W) && isGrounded))
        {
            Jump();
        } else 
        if (Input.GetKeyDown(KeyCode.W) && isDoubleJump)
        {
            Jump();
            isDoubleJump = false;
        }

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            isDoubleJump=true;
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
