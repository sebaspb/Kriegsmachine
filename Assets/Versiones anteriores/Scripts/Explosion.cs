using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public Rigidbody particleExplosion;
	public int tiempoDestruccion;

	void Start()
	{
		Destroy(gameObject, tiempoDestruccion);
	}


	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Enemy")
		{
			Rigidbody clone;
			clone = Instantiate(particleExplosion, collision.transform.position, collision.transform.rotation) as Rigidbody;
			Destroy(gameObject);
		}


	}
}

