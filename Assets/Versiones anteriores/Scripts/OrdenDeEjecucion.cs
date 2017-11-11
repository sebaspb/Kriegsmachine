using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenDeEjecucion : MonoBehaviour {

	//Ejemplo en el que se muestra el orden de ejecución de los estados principales de unity

	//Cuando una nueva instancia de MonoBehaviour es creada, llama las funciones Awake

	void Awake()
	{

		Debug.Log ("Primer Awake");

	}

	void OnEnable()
	{
	
		Debug.Log ("Primer OnEnable");
	
	}

	void Start()
	{

		Debug.Log ("Primer Start");
	
	}

	void FixedUpdate()
	{

		Debug.Log ("Primer FixedUpdate");


	}

	void Update()
	{

		Debug.Log ("Primer Update");


	}

	void LateUpdate()
	{

		Debug.Log ("Primer LateUpdate");
		Destroy(this);

		//Cuando la clase se elimina a sí misma se deshabilita y luego se destruye

	}

	void OnDisable()
	{

		Debug.Log ("Primer OnDisable");


	}

	void OnDestroy()
	{

		Debug.Log ("Primer OnDestroy");

	}


}