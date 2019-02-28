using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    GameOver
}
[RequireComponent(typeof(Spawner))]
public class GamestateManager : MonoBehaviour {

    public GameObject Player;

    public UIManager uIManager;
    public Spawner spawner;

    public GameState CurrentGameState { get; set; }

    private void Start()
    {
        spawner = GetComponent<Spawner>();
        CurrentGameState = GameState.Playing;
        spawner.InitialSpawn();
        Player = spawner.GetPlayer();
        Restart();
        
    }

    // Update is called once per frame
    void Update () {

        if (Player) { 
            if(Player.activeSelf != true)
            {
                CurrentGameState = GameState.GameOver;
                GameOver();
            }
            else
            {
                CurrentGameState = GameState.Playing;
            }
        }
		
	}

    void GameOver()
    {
        uIManager.GameOver();

    }

    public void Restart()
    {
        spawner.ResetObjects();
    }
}
