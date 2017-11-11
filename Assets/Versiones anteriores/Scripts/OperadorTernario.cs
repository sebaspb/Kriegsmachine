using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperadorTernario : MonoBehaviour 
{

	void Start () 
	{

		int health = 10;
		string message;


		message = health > 0 ? "Player está vivo" : "Player está muerto";
		message = health > 0 ? "Player está vivo" : health == 0 ? "Player es raro" : "Player está muerto";
		//Lo de arriba es lo mismo que lo de abajo
		if (health > 0)
		{

			message = ("PLayer está vivo");
		}
		else
		{

			message = ("Player está muerto");

		}
			
		if (health > 0) {
			message = ("PLayer está vivo");
		} else if (health == 0) {

			message = "Player es raro";

		} else 
		{

			message = ("Player está muerto");

		}




	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
