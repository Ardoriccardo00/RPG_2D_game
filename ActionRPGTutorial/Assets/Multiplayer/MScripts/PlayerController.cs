using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis("Horiziontal")*Time.deltaTime*150.0f;
		float y = Input.GetAxis("Vertical")*Time.deltaTime*3.0f;
	
	}
}
