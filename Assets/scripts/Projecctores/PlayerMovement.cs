using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //taoj vector di chuyển
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,  0.0f);

        transform.Translate(movement * speed*Time.deltaTime);

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip(); // Lật lại nhân vật
        }
        // Kiểm tra nếu nhân vật di chuyển sang trái và đang quay về bên phải
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        // Đổi hướng của nhân vật bằng cách thay đổi giá trị scale trên trục X
        facingRight = !facingRight; // Đổi trạng thái hướng
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Lật trục X
        transform.localScale = theScale; // Áp dụng scale mới cho nhân vật
    }
}
