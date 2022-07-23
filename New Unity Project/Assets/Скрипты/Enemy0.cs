using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 10;
    [SerializeField] int scoreValue = 10;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
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
        _anim.SetBool("Die", true);
        Destroy(gameObject, 0.2f);


    }
}
