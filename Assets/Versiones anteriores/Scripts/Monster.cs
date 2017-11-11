using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public int ID;
	public int spacing;

		void Start () 
	{
	
		print ("Estoy vivo");
	}
	

	void Update () 
	{
	
		float wave = Mathf.Sin (Time.fixedTime + ID);
		transform.position = new Vector3 (ID * spacing, wave, 0.0f);

	}
}
