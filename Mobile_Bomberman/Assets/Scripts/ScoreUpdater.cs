//ScoreUpdater by Alex Dine
//101264627 on Sept 26th
//updates score
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUpdater : MonoBehaviour
{
    public void UpdateScore()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + FindObjectOfType<ScoreCounter>().curScore.ToString();
    }

    void Update()
    {
        UpdateScore();
    }
}
