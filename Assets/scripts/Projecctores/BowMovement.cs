using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeedZ=1.0f;

    private float max = 0.1736473f, min = -0.3420185f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.localRotation.z);
        //rotationDirection = gameObject.GetComponentInParent<GameObject>().transform.localScale.x;
        
            if (Input.GetKey(KeyCode.W) && gameObject.transform.localRotation.z < max)
            {
                gameObject.transform.Rotate(0, 0, rotationSpeedZ);
            }
            if (Input.GetKey(KeyCode.S) && gameObject.transform.localRotation.z > min)
            {
                gameObject.transform.Rotate(0, 0, -rotationSpeedZ);
            }
       
        
        
    }
}
