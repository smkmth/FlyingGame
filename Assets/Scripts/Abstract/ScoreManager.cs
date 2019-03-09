using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentPoints;
    private ScoreManagerUI uiScoreManager;

    void Start()
    {
        uiScoreManager = GameObject.Find("UI").GetComponent<ScoreManagerUI>();

        currentPoints = 0;
        uiScoreManager.SetScoreUI(currentPoints);
    }

    public void Restart()
    {
        currentPoints = 0;
        uiScoreManager.SetScoreUI(currentPoints);

    }


    public void AddPoint(int pointValue)
    {
        currentPoints += pointValue;
        uiScoreManager.SetScoreUI(currentPoints);

    }
    
}
