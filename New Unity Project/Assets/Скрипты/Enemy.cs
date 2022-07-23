using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //configuration

    [Header("Enemy Stats")]
    [SerializeField] float health = 10;
    [SerializeField] int scoreValue = 10;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] GameObject projectile, laserSpawn;
    [SerializeField] float projectileSpeed = 0.3f;
    private Animator anim;
    bool die = false;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();    
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = 100f;
            StartCoroutine(WaitforRandom());

        }
   
    }

    private void Fire()
    {
        
            anim.SetInteger("Fire", 1);
            StartCoroutine(WaitforAnimFire());
            StartCoroutine(WaitforAnimFire2());
       
    }
    // trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        HitProcess(damageDealer);

        
    }
    // death
    private void HitProcess(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        
        anim.SetInteger("Fire", 2);
        Destroy(gameObject,0.45f);
        


    }
    private IEnumerator WaitforAnimFire()
    {   
        yield return new WaitForSeconds(0.46f);
        GameObject laser = Instantiate(projectile, laserSpawn.transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

    }
    private IEnumerator WaitforAnimFire2()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetInteger("Fire", 0);

    }
    private IEnumerator WaitforRandom()
    {   
        yield return new WaitForSeconds(1f);
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
       
    }
}

