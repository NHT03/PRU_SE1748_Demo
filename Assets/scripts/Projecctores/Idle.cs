using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;  
        if (health <= 0)
        {
            Die();  
        }
    }
    public void Die()
    {
        Destroy(gameObject);  
    }
}
