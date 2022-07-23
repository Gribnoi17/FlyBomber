using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileRocket;
    [SerializeField] Transform[] laserSpawn;
    [SerializeField] private float speedBullet = 0.3f;
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShotsBullet;
    [SerializeField] private float maxTimeBetweenShotsBullet;
    [SerializeField] private float minTimeBetweenShotsRocket;
    [SerializeField] private float maxTimeBetweenShotsRocket;
    [SerializeField] public static float health = 100;
    private float timer = 5f;
    private Animator anim;
    public Transform[] points;
    public float waitTime;
    private bool canGo = true;
    public float speedMain;
    private float speed2;
    public Image bar;
    public float fill;
    public float sensitiveTime;
    private int i = 1;
    private bool _damage = false;
    

    
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].transform.position.x, points[0].transform.position.y, transform.position.z);
        anim = GetComponent<Animator>();
        fill = 1f;
        speed2 = speedMain;
        
    }

    
    void Update()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speedMain * Time.deltaTime);


        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            anim.SetInteger("Boss", 2);
            StartCoroutine(Sensitive());
            timer = 100f;
            canGo = false;
        }


         CheckforGun();


       

        if (transform.position == points[i].position)
        {
            if (i < points.Length - 1)
                i++;
            else
                i = 0;
            canGo = false;
            StartCoroutine(WaitWalk());
        }

        bar.fillAmount = fill;
        
        
        if(health <= 0)
        {
            Destroy(gameObject, 0.1f);
            FindObjectOfType<SceneLoader>().LoadGameOverVictory();
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            if (_damage)
            {
                StartCoroutine(ChangeColorOnHit());
                health -= 5;
                fill -= 0.05f;
                
            }
        }

    }

    private IEnumerator ChangeColorOnHit()
    {
        GetComponent<SpriteRenderer>().color = new Color32(125, 117, 217, 255);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void CheckforGun()
    {
        if (health == 100)
        { CountDownAndShootBullet(); }
        else if (health >= 40 && health < 90)
        { bool trigger = true; CountDownAndShootRocket(trigger); }
        
        
    }
    private IEnumerator WaitWalk()
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;

    }
    //Уязвимость
    private IEnumerator Sensitive()
    {
       
        
        canGo = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("Boss", 3);
        
        _damage = true;
        yield return new WaitForSeconds(sensitiveTime);
        
        _damage = false;
        anim.SetInteger("Boss", 4);
        
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("Boss", 1);
        
        canGo = true;
        speedMain = speed2;
        timer = 10f;
    }
    private void FireBullet()
    {
        
        GameObject laser = Instantiate(projectile, laserSpawn[Random.Range(0,4)].transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedBullet);

    }
    private void FireRocket()
    {

        GameObject rocket = Instantiate(projectileRocket, laserSpawn[Random.Range(0, 4)].transform.position, Quaternion.identity) as GameObject;
        rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedBullet);

    }

    private void CountDownAndShootBullet()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            FireBullet();
            shotCounter = 100f;
            StartCoroutine(WaitforRandomBullet());

        }

    }
    private IEnumerator WaitforRandomBullet()
    {
        yield return new WaitForSeconds(1f);
        shotCounter = Random.Range(minTimeBetweenShotsBullet, maxTimeBetweenShotsBullet);

    }
    private IEnumerator WaitforRandomRocket()
    {
        yield return new WaitForSeconds(1f);
        shotCounter = Random.Range(minTimeBetweenShotsRocket, maxTimeBetweenShotsRocket);

    }
    private void CountDownAndShootRocket(bool trigger)
    {
        if (trigger)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                FireRocket();
                shotCounter = 100f;
                StartCoroutine(WaitforRandomRocket());

            }
        }
        

    }

    
}
