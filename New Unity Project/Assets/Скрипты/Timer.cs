using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float timer;
    public Text time;

    void Update()
    {
        time.text = "Left: " + Mathf.Round(timer) + " sec";

        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
            SceneManager.LoadScene("Death");
    }

    public float GetTimerValue() { return timer; }
}
