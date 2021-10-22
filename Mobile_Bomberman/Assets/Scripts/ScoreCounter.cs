//ScoreCounter by Alex Dine
//101264627 on Sept 26th
//moves the score through scenes
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCounter : MonoBehaviour
{


    private Text scoreText;
    public int curScore;
    public static ScoreCounter instance;

    // Start is called before the first frame update
    void Awake()
    {
        curScore = 0;
        instance = this;
        int sessionCount = FindObjectsOfType<ScoreCounter>().Length;
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
}
