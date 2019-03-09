using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class UIManager : MonoBehaviour {

    public GameObject GameOverPanel;
    public GameObject VictoryPanel; 
    public GameObject MapScreen; 
    public GameObject PausePanel; 
    public GameObject MainMenu;
    public GameObject hud;  
    public GamestateManager manager;
    public Slider healthBar;

    private ShipBuilderUI shipbuilder;

	// Use this for initialization
	void Start () {

        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        MainMenu.SetActive(true);
        PausePanel.SetActive(false);
        hud.SetActive(false);
        shipbuilder = GetComponent<ShipBuilderUI>();
        if (hud == null)
        {
            Assert.IsTrue(false, "No hud object in scene");
        }
    }

    public void TurnOnShipBuilder()
    {
        MainMenu.SetActive(false);
        shipbuilder.TurnOnMenu();


    }
	
	public void GameOver()
    {
        hud.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void Win()
    {
        hud.SetActive(false);
        VictoryPanel.SetActive(true);
    }
    //for the button 
    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        PausePanel.SetActive(false);

        manager.Restart();

    }
    public void TogglePauseMenu(bool paused)
    {
        if (paused)
        {
            hud.SetActive(false);
            PausePanel.SetActive(true);
        }
        else
        {
            hud.SetActive(true);
            PausePanel.SetActive(false);

        }
    }

    public void GoToMapScreen()
    {
        MapScreen.SetActive(true);

    }


    public void ResumeGame()
    {
        TogglePauseMenu(false);
        manager.Pause(false);
    }

    public void QuitGame()
    {
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        PausePanel.SetActive(false);
        hud.SetActive(false);

        manager.QuitToMainMenu();
        MainMenu.SetActive(true);

    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        shipbuilder.TurnOffMenu();
        VictoryPanel.SetActive(false);
        MapScreen.SetActive(false);

        hud.SetActive(true);

        manager.InitGame();
    }
    public void SetHealthBar(float maxhealth)
    {
       // Debug.Log("Health set to " + maxhealth);
        healthBar.maxValue = maxhealth;
        healthBar.value = maxhealth;
    }

    public void UpdateHealthBar(float val)
    {
        
        healthBar.value = val;
    }

 
}
