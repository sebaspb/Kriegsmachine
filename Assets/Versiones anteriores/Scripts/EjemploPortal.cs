using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploPortal : MonoBehaviour 
{

	public Transform spawnPoint;

	void OnTriggerEnter(Collider other)
	{

		other.gameObject.transform.position = spawnPoint.position;


	}
}

