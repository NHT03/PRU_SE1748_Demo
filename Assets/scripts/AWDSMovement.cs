using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWDSMovement : MonoBehaviour
{
    [SerializeField]
    float forceX = 1, forceY = 1;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3
                (
                    -gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );
            }
            rigid.velocity = forceX * Vector3.right;
            //rigid.AddForce(forceX * Vector2.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector3
                (
                    -gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );
            }
            rigid.AddForce(forceX * Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            rigid.AddForce(forceY * Vector2.up);
        }
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    
        //}
    }
}
