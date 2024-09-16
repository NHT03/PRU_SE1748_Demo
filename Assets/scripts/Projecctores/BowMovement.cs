using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeedZ=1.0f;

    private float max = 0.1736473f, min = -0.3420185f;

    [SerializeField]
    private float arrowSpeed = 25f;

    [SerializeField]
    private ArrowPool arrows = new ArrowPool();

    [SerializeField]
    private Transform arrowSpawn;

    [SerializeField]
    private Transform arrowFront;

    [SerializeField]
    private Transform arrowRear;
    private void ShotArrow()
    {
        GameObject arrow = arrows.getArrow();
        if (arrow == null) return;
        arrow.transform.position = arrowSpawn.position;
        arrow.transform.rotation = arrowSpawn.rotation;
        arrow.transform.localScale = arrowSpawn.localScale*4;

        //
        arrow.SetActive(true);
        Vector3 direction = arrowFront.position - arrowRear.position;
        direction.z = 0;

        //
        Rigidbody2D arrowBody = arrow.GetComponent<Rigidbody2D>();
        if (arrowBody != null)
        {
            arrowBody.velocity = direction * arrowSpeed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BowRotate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotArrow();
        }
        
        
    }
    
    private void BowRotate()
    {
        //Debug.Log(gameObject.transform.localRotation.z);
        //rotationDirection = gameObject.GetComponentInParent<GameObject>().transform.localScale.x;

        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.localRotation.z < max)
        {
            gameObject.transform.Rotate(0, 0, rotationSpeedZ);
        }
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.localRotation.z > min)
        {
            gameObject.transform.Rotate(0, 0, -rotationSpeedZ);
        }
    }
}
