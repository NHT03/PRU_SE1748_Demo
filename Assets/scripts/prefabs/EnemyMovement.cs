using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float forceX=1;
    Rigidbody2D rb;

    private EnemySpawn inputScript;

    public EnemySpawn InputScript
    {
        get { return inputScript; }
        set { inputScript = value; }
    }

    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        forceX = Random.Range(forceX, 5);
        facingRight = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(forceX * Vector2.right);
        rb.velocity = Vector3.right * -forceX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBoundary") || collision.gameObject.CompareTag("EnemyType1"))
        {
            forceX = -forceX;
            Flip();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            InputScript.CurrentCount = InputScript.CurrentCount - 1;
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
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
