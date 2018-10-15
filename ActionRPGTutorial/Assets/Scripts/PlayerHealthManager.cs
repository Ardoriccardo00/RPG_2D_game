using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHelath;
	public int PlayerCurrentHealth;

	private bool flashActive;
	public float flashLenght;
	private float flashCounter;

	private SpriteRenderer playerSprite;

	private SFXManager sfxman;

	void Start () {
		
		PlayerCurrentHealth = playerMaxHelath;
		playerSprite = GetComponent<SpriteRenderer> ();
		sfxman = FindObjectOfType<SFXManager> ();
	}
	

	void Update () {

		if (PlayerCurrentHealth <= 0) 
		{
			sfxman.playerDead.Play ();
			gameObject.SetActive (false);


		}

		if (flashActive) 
		{
			if (flashCounter > flashLenght * .66f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else if (flashCounter > flashLenght * .33f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			} else if (flashCounter > 0f)
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
				else
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}

			flashCounter -= Time.deltaTime;
		}
	}

	public void HurtPlayer(int damageToGive)
	{
		PlayerCurrentHealth -= damageToGive;

		flashActive = true;
		flashCounter = flashLenght;

		sfxman.playerHurt.Play ();
	}

	public void setMaxHealth()
	{
		PlayerCurrentHealth = playerMaxHelath;
	}
}

