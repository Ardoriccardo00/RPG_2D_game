using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	public bool isWeapon;
	private PlayerController weaponExists;
	public WeaponPickup weaponName;
	public int Damage;

	// Use this for initialization
	void Start () {

		weaponExists = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			if(isWeapon == true)
			{
			Destroy (gameObject);
			weaponExists.hasSword = true;
			}
		}
	}
}
