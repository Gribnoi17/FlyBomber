using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("State", Anim());
    }
    public int Anim()
    {
        int k = 5;
        if (Input.GetKey(KeyCode.A))
            k = 1;

        if (Input.GetKey(KeyCode.D))
            k = 2;

        if (Input.GetKey(KeyCode.S))
            k = 3;

        if (Input.GetKey(KeyCode.W))
            k = 4;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            k = 6;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        k = 7;

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        k = 8;

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        k = 9; 
        return k;

    }

}