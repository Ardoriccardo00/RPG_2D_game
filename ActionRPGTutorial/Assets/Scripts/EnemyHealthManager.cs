using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHelath;
	public int CurrentHealth;


	private PlayerStats thePlayerStats;

	public int expToGive;

	public string enemyQuestName;
	private QuestManager theQM;

	private SFXManager sfxman;

	void Start () {

		CurrentHealth = MaxHelath;
		thePlayerStats = FindObjectOfType<PlayerStats> ();
		theQM = FindObjectOfType<QuestManager> ();
		sfxman = FindObjectOfType<SFXManager> ();
	}


	void Update () {

		if (CurrentHealth <= 0) 
		{
			theQM.enemyKilled = enemyQuestName;

			Destroy (gameObject);

			thePlayerStats.AddExperience (expToGive);
		}

	}

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
		sfxman.Impact.Play ();
	}

	public void setMaxHealth()
	{
		CurrentHealth = MaxHelath;
	}
}

