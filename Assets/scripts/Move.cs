using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int speedX;
    // Start is called before the first frame update
    float x;
    void Start()
    {
        speedX = 10;
        x = Camera.main.orthographicSize * Camera.main.aspect;
        float spritesWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x /2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.transform.position.x > x || gameObject.transform.position.x < -x)
        {
            speedX = -speedX;
            gameObject.transform.localScale = new Vector3
                (
                    -gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );
        }
        gameObject.transform.position = new Vector3
        (
            gameObject.transform.position.x + speedX * Time.deltaTime,
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );


    }
}
