using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHpBoss : MonoBehaviour
{
    public Image bar;
    public float fill;
    void Start()
    {
        fill = 1f;
    }

    void Update()
    {
        bar.fillAmount = fill;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fill == 0)
            Destroy(gameObject);
        if (collision.gameObject.tag == "Bomb")
        {
            fill -= 0.02f;
        }
        
    }
}
