using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 10;
    [SerializeField] int scoreValue = 10;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] GameObject projectile, laserSpawn;
    private bool canGo = true;
    [SerializeField] public float speed;
    
    
    private Animator anim;



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

        GameObject laser = Instantiate(projectile, laserSpawn.transform.position, Quaternion.Euler(0,0,-90)) as GameObject;
        


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
        anim.SetBool("Die1", true);
        Destroy(gameObject,0.9f);


    }
   
        

    
    private IEnumerator WaitforRandom()
    {
        yield return new WaitForSeconds(1f);
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

    }
 
}
