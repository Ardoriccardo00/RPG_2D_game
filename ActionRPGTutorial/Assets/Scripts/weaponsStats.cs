using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsStats : MonoBehaviour {

	public int Damage; 
	public WeaponPickup weaponName;

	// Use this for initialization
	void Start () {
		weaponName = FindObjectOfType<WeaponPickup>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void weaponsDamage()
	{
		if (weaponName.name == "Sword")
		{
			Damage = 5;
		}
	}
}
