using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //takes player back to main menu screen
    public void StartMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    //takes player to the how to play screen
    public void HowToScreen()
    {
        SceneManager.LoadScene("HowToScreen");
    }

    //starts a new game sessions
    public void LoadGame()
    {
        //SceneManager.LoadScene("");
        if (FindObjectsOfType<GameSession>().Length > 0)
        {
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
    }

    public void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOverScreen");
    }
}
