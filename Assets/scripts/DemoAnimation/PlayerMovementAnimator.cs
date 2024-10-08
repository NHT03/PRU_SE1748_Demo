using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimator : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    public bool facingRight = false;

    Rigidbody2D rigidbody2;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Console.WriteLine(rigidbody2.velocity);

        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        float moveHorizontal = Input.GetAxis("Horizontal");
        int currentState = animator.GetInteger("StateIndex");
        if (moveHorizontal != 0 && (currentState==0 || currentState==1))
        {
            animator.SetInteger("StateIndex", 1);
        }
        if (currentState == 1 && moveHorizontal ==0)
        {
            animator.SetInteger("StateIndex", 0);
        }
        //else
        //{
        //    animator.SetInteger("StateIndex", 0);
        //}

        //taoj vector di chuyển
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,  0.0f);

        transform.Translate(movement * speed*Time.deltaTime);
        //rigidbody2.velocity = movement * speed;

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip(); 
        }
        
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()// Lật lại nhân vật
    {
        
        facingRight = !facingRight; 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; 
        transform.localScale = theScale;
    }
}
