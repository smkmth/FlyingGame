using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject GameOverPanel;
    public GameObject MainMenu;
    public GamestateManager manager;
    public Slider healthBar;

	// Use this for initialization
	void Start () {

        GameOverPanel.SetActive(false);
        MainMenu.SetActive(true);
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

        manager.StartGame();
    }
    public void SetHealthBar(float maxhealth)
    {
        Debug.Log("Health set to " + maxhealth);
        healthBar.maxValue = maxhealth;
        healthBar.value = maxhealth;
    }

    public void UpdateHealthBar(float val)
    {
        
        healthBar.value = val;
    }
}
