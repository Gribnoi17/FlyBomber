using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLaser : MonoBehaviour
{
    
    int x = 61;
    bool right = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localRotation =  Quaternion.Euler(0, 0, RotateLaser());
    }
    private int RotateLaser()
    { 
        if (x < 63 && right)
        {
            
            if (x==-46)
            {
                
                right = false;
            }
           return --x;
        }
        else if (x >= -47 && right==false)
        {
            
            if (x>60)
            {
                right = true;
            }
            return ++x;

        }
        return x;
    }
}
