using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigosant : MonoBehaviour {

	[Header("<OPCIONES DE OBJETIVO>")]
	[Tooltip("El objetivo al cual seguirá éste enemigo")]
	Transform Jugador;
	[Tooltip("Velocidad a la cual se moverá el enemigo, valor por defecto 4")]
	public float VelocidadEnemigo = 4f;
	[Tooltip("Distancia minima a la cual puede estar el enemigo de el objetivo, valor por defecto 2")]
	public float DistanciaMinima = 2f;


	// Use this for initialization
	void Start () {

		Jugador = GameObject.Find ("Jugador").transform;

	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (Jugador);

		float Distancia = Vector3.Distance (Jugador.position, transform.position);

		if (Distancia > DistanciaMinima) {

			float Movimiento = VelocidadEnemigo * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, Jugador.position, Movimiento);

		}

	}
}
