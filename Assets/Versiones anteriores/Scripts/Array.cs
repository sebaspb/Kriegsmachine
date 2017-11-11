using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour 
{

	public int vOne;
	public int vTwo;
	public int vThree;


	public int arraySize;

	public int [] variables = new int[20];

	public float variableDos;

	public float [] segundaPrueba;

	public GameObject [] ejemploDos;

	void Start ()
	{
		Debug.Log ("Yo estoy en el Start");
		segundaPrueba = new float[arraySize];
		Debug.Log (variables.Length);

		for(int i = 0; i < ejemploDos.Length;i++)
		{
			ejemploDos[i].name = i.ToString();
		}

		foreach (GameObject Hola in ejemploDos)
		{
		
			Debug.Log (Hola.name);

		}
	}

	void Update()
	{
	
	}
}			
			