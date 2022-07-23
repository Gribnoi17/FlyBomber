using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public float speed = 7f;
    
    public float TimeToAn;
    private Animator anim;

    private Rigidbody2D rb;
    private AudioSource explosionSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        explosionSound = GetComponent<AudioSource>();

    }

    private void Update()
    {     
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bombstag") {

            explosionSound.Play();
            anim.SetBool("Boom", true);
            rb.bodyType = RigidbodyType2D.Static;
            speed = 0f;
            StartCoroutine(Anima());
            
        }

    }

    IEnumerator Anima() {

        yield return new WaitForSeconds(TimeToAn);
        Destroy(gameObject);
        
    }
   
   

   

}
