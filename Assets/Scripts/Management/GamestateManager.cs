using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    GameOver
}

public class GamestateManager : MonoBehaviour {

    public GameObject Player { get; set; }

    public GameState CurrentGameState { get; set; }

    private void Start()
    {
        CurrentGameState = GameState.Playing;   
    }

    // Update is called once per frame
    void Update () {

        if (Player) { 
            if(Player.activeSelf != true)
            {
                CurrentGameState = GameState.GameOver;
            }
            else
            {
                CurrentGameState = GameState.Playing;
            }
        }
		
	}
}
