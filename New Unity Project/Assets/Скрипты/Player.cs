using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed; 
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    [SerializeField] public static int health = 200;
    SceneLoader gameover;
    public Joystick joystick;
    private AudioSource hitsound;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = 200;
        hitsound = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        // Перемещение игрока
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput * speed;

        anim.SetInteger("State", Anim());
        
        if (health <= 0)
        { 
            
            Die(); 
        
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        HitProcess(damageDealer);
    }
    // death
    private void HitProcess(DamageDealer damageDealer)
    {
        hitsound.Play();
        
        StartCoroutine(ChangeColorOnHit());
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();

        }
    }
    private IEnumerator ChangeColorOnHit()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 95, 76, 255);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void Die()
    {

        Destroy(gameObject);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }
    public int GetHealth()
    {
        return health;
    }

    private void MovePlayer()
    {
        if (joystick.Horizontal >= 0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }

        if (joystick.Horizontal <= -0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }

        if (joystick.Vertical <= -0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }

        if (joystick.Vertical >= 0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
        //

        if (joystick.Horizontal >= 0.2f && joystick.Vertical >= 0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }

        if (joystick.Horizontal <= -0.2f && joystick.Vertical >= 0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }

        if (joystick.Horizontal >= 0.2f && joystick.Vertical <= -0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
        if (joystick.Horizontal <= -0.2f && joystick.Vertical <= -0.2f)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
    }
    public int Anim()
    {
        int k = 5;
        if (joystick.Horizontal <= -0.2f)
            k = 1;

        if (joystick.Horizontal >= 0.2f)
            k = 2;

        if (joystick.Vertical <= -0.2f)
            k = 3;

        if (joystick.Vertical >= 0.2f)
            k = 4;

        if (joystick.Horizontal <= -0.2f && joystick.Vertical >= 0.2f)
            k = 6;

        if (joystick.Horizontal >= 0.2f && joystick.Vertical >= 0.2f)
            k = 7;

        if (joystick.Horizontal <= -0.2f && joystick.Vertical <= -0.2f)
            k = 8;

        if (joystick.Horizontal >= 0.2f && joystick.Vertical <= -0.2f)
            k = 9;
        return k;

    }

}

