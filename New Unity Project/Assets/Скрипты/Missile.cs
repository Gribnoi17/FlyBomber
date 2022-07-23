using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public float rotationspeed = 200f;
    private GameObject target;
    
    Rigidbody2D rb;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        Vector2 pointtoTarget = (Vector2)transform.position - (Vector2)target.transform.position;
        pointtoTarget.Normalize();
        float value = Vector3.Cross(pointtoTarget, transform.right).z;
        

        /* if (value > 0)
        {
            rb.angularVelocity = rotationspeed;
        }
        else if (value < 0)
        {
            rb.angularVelocity = -rotationspeed;
        }
        else
         { rotationspeed = 0; } */

        rb.angularVelocity = rotationspeed * value;
        rb.velocity = transform.right * speed;
    }
    public float GetSpeed()
    {
        return speed;
    }
   
        
       
    
}   

