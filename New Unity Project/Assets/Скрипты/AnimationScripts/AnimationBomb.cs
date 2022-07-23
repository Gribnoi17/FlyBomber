using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBomb : MonoBehaviour
{
    private Animator anim;
    bool Yes = false;
    public float TimeToAn;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(An());
        StartCoroutine(AnF());

    }

    // Update is called once per frame
    void Update()
    {
        if (Yes == true)
            anim.SetBool("Boom", true);
        else
            anim.SetBool("Boom", false);
    }
    IEnumerator An()
    {
        yield return new WaitForSeconds(TimeToAn);
        Yes = true;


    }
    IEnumerator AnF()
    {
        yield return new WaitForSeconds(TimeToAn + 0.25f);
        Yes = false;

    }
}
