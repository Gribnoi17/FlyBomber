using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// класс отвечающий за процесс дамага от бомбы
public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage;
    
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
