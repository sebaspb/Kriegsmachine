using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacionProperties : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

		var myProperties = new EjemploProperties ();

		myProperties.Experience = 10;
		int x = myProperties.Experience;
		myProperties.level = 10;
        int y = myProperties.level;
    }
	// Update is called once per frame
	void Update () 
	{
		
	}
}
