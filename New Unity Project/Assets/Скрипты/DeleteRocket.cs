using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRocket : MonoBehaviour
{
    public float speed = 7f;

    public float TimeToAn;
    private Animator anim;

    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Anima());


    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    

    IEnumerator Anima()
    {

        yield return new WaitForSeconds(TimeToAn);
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bombstag")
        {
            StartCoroutine(Anima());
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Anima());
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(gameObject);
        }
    }

}
