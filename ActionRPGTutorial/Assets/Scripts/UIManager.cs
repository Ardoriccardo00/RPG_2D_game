using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	private PlayerStats thePS;
	public Text levelText;

	private static bool UIExists;

	void Start () {
		if (!UIExists)
		{
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else { 
			Destroy(gameObject);
		}

		thePS = GetComponent<PlayerStats>();
	}
	

	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHelath;
		healthBar.value = playerHealth.PlayerCurrentHealth;
		HPText.text = "HP: " + playerHealth.PlayerCurrentHealth + "/" + playerHealth.playerMaxHelath;
		levelText.text = "Lvl: " + thePS.currentLevel;
	}
}
