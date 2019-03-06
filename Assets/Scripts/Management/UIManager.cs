using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject GameOverPanel;
    public GameObject MainMenu;
    public GameObject hud;  
    public GamestateManager manager;
    public Slider healthBar;

    private ShipBuilderUI shipbuilder;

	// Use this for initialization
	void Start () {

        GameOverPanel.SetActive(false);
        MainMenu.SetActive(true);
        hud.SetActive(false);
        shipbuilder = GetComponent<ShipBuilderUI>();
    }

    public void TurnOnShipBuilder()
    {
        MainMenu.SetActive(false);
        shipbuilder.TurnOnMenu();


    }
	
	public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    //for the button 
    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        manager.Restart();

    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        shipbuilder.TurnOffMenu();
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
