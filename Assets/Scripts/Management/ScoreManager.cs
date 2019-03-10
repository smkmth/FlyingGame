using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentPoints;
    private ScoreManagerUI uiScoreManager;
    private EnemyWaveSpawner spawner;

    void Start()
    {
        uiScoreManager = GameObject.Find("UI").GetComponent<ScoreManagerUI>();
        spawner = GameObject.Find("GameManager").GetComponent<EnemyWaveSpawner>();

        currentPoints = 0;
        uiScoreManager.SetScoreUI(currentPoints);
    }

    public void Restart()
    {
        currentPoints = 0;
        spawner.DeadEnemies = 0; 
        uiScoreManager.SetScoreUI(currentPoints);

    }


    public void AddPoint(int pointValue)
    {
        currentPoints += pointValue;
        uiScoreManager.SetScoreUI(currentPoints);
        spawner.DeadEnemies += 1;
        spawner.DeadEnemiesTotal += 1;
        

    }
    
}
