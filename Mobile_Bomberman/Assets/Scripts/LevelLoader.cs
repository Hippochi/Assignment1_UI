//LevelLoader by Alex Dine
//101264627 on Sept 26th
//Scene loader, basic logic
//v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //takes player back to main menu screen
    public void StartMenu()
    {
        StartCoroutine(MMenuDelay());
    }

    //takes player to the how to play screen
    public void HowToScreen()
    {
        StartCoroutine(HowToDelay());
    }

    //starts a new game session and loads game scene
    public void LoadGame()
    {
        StartCoroutine(PlayDelay());
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

    private IEnumerator MMenuDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MenuScreen");
    }

    private IEnumerator HowToDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("HowToScreen");
    }

    private IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PlayScene");
        if (FindObjectsOfType<GameSession>().Length > 0)
        {
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
    }
}
