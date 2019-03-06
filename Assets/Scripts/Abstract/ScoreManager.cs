using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentPoints;
    public ScoreManagerUI uiScoreManager;

    void Start()
    {
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
