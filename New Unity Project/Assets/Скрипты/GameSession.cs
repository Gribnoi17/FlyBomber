using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;
    SceneLoader sceneloader;
    [SerializeField] int pointsfornextlevel;
    [SerializeField] string levelforload;
    [SerializeField] bool checkforlevelload = true;


    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
       int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
        } 
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (checkforlevelload == true)
        {
            if (GetScore() >= pointsfornextlevel)
            {
                SceneManager.LoadScene(levelforload);
            }
        }
        
    }
}
