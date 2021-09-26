//GameSession by Alex Dine
//101264627 on Sept 26th
//Score tracking and making sure only 1 score is being kept
//v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //game session is for tracking score for one playthrough
    int score = 0;

    //makes sure there is only one session at a time
    private void Awake()
    {
        int sessionCount = FindObjectsOfType<GameSession>().Length;
        if (sessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //new session makes sure score is set to 0
    private void Start()
    {
        score = 0;
    }

    //adding points
    public void AddtoScore(int points)
    {
        score += points;
        //FindObjectOfType<ScoreDisplay>().UpdateScore();
    }

    //get current score
    public int GetScore() { return score; }
}
