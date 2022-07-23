using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laserstag")
        {
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
