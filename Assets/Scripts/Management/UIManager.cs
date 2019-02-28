using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject GameOverPanel;
    public GamestateManager manager;
    public Slider healthBar;

	// Use this for initialization
	void Start () {

        GameOverPanel.SetActive(false);
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
    public void SetHealthBar(float maxhealth)
    {
        healthBar.maxValue = maxhealth;
        healthBar.value = maxhealth;
    }

    public void UpdateHealthBar(float val)
    {
        
        healthBar.value = val;
    }
}
