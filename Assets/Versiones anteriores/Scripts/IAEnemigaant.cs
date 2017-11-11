using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigaant : MonoBehaviour {

	[Header("<OPCIONES DE ENEMIGOS>")]
	[Tooltip("Arreglo que almacena la lista de enemigos")]
	public GameObject[] Enemigos;
	[Tooltip("Segundos que transcurren entre cada spawn")]
	public float TiempoDeSpawn = 3f;
	[Tooltip("Arreglo que contiene los distintos puntos de spawn")]
	public Transform[] PuntosDeSpawn;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", TiempoDeSpawn, TiempoDeSpawn);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
		int NumeroPuntoSpawn = Random.Range (0, PuntosDeSpawn.Length);
		int NumeroEnemigo = Random.Range (0, Enemigos.Length);
		Instantiate(Enemigos[NumeroEnemigo], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn [NumeroPuntoSpawn].rotation);

	}
}
