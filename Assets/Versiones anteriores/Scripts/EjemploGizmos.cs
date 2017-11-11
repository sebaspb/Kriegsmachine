using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGizmos : MonoBehaviour 
{

	public Transform target;
	void OnDrawGizmosSelected() {
		
		if (target != null)
		{
			Gizmos.color = Color.grey;
			Gizmos.DrawLine(transform.position, target.position);
		}
	}
	void OnDrawGizmos() 
	{
		Gizmos.color = new Color(1, 0, 0, 0.5F);
		Gizmos.DrawCube(transform.position, new Vector3(10, 10, 10));
	}
}
