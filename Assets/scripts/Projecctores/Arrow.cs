using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit = false;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasHit)
        {             
            
            if (collision.gameObject.layer ==9)
            {
                Idle idle = collision.gameObject.GetComponent<Idle>();
                if (idle != null)
                {
                    idle.TakeDamage(40);
                }
            }
            hasHit = true;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.parent = collision.transform;
            //Destroy(GetComponent<Rigidbody2D>());
        }
    }
}