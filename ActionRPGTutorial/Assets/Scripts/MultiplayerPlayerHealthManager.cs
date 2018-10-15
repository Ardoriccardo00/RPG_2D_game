using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MultiplayerPlayerHealthManager : NetworkBehaviour {

	public const int maxHealth = 100;
	[SyncVar (hook = "OnChangeHealth")] public int currenthealth = maxHealth;
	public RectTransform healthbar;
	public bool destroyOnDeath;
	private NetworkStartPosition[] spawnPoints;

	// Use this for initialization
	void Start () {
		spawnPoints = FindObjectsOfType<NetworkStartPosition>();
	}

	public void takeDamage(int amount)
	{
		if(!isServer)
		{
			return;
		}

		currenthealth -= amount;

		if(currenthealth <=0)
		{
			if(destroyOnDeath)
			{
				Destroy (gameObject);
			}

			else
			{
				currenthealth = maxHealth;
				RpcRespawn();
			}
		}
	}

	void OnChangeHealth(int health)
	{
		healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			Vector3 spawnPoint = Vector3.zero;

			if(spawnPoints != null && spawnPoints.Length > 0)
			{
				spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
			}

			transform.position = spawnPoint;
		}
	}
}
