using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bomb;
    bool shoot = true;

    public void Shoot()
    {
        Instantiate(bomb, firePoint.position, firePoint.rotation);
    }
    
    private IEnumerator ShootOff()
    {
        shoot = false;
        yield return new WaitForSeconds(0.5f);
        shoot = true;

    }
    public void OnMouseDown()
    {
        if (shoot)
        {
            Shoot();
            StartCoroutine(ShootOff());
        }
    }
}
