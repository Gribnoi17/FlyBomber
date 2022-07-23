using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDelete : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public float speed = 5f;
    Rigidbody2D rb;
    [SerializeField] float timeforliving;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyRocket());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "laserstag")
        {

            anim.SetBool("Rocket", true);
            rb.bodyType = RigidbodyType2D.Static;
            speed = 0f;
            Destroy(gameObject, 0.25f);
                

        }
        
        
        

    }
    private IEnumerator DestroyRocket()
    {
        yield return new WaitForSeconds(timeforliving);
        anim.SetBool("Rocket", true);
        Destroy(gameObject,0.25f);

    }
}
