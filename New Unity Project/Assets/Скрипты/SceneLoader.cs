using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    public void LoadGameOver() 
    {
        SceneManager.LoadScene("Death");
    }
    public void LoadMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame() 
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadGameStart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOverVictory()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadSplashScreen()
    {
        SceneManager.LoadScene("Splash Screen");
    }
}
 
