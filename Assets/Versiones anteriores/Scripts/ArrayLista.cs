using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayLista : MonoBehaviour
{
	public GameObject[] AllGameObjects;

	void Start ()
	{
		//Éste código lo que hace es poner todos los GameObjects en el GameObject vacío en el que está puesto el script
		ArrayList aList = new ArrayList();
		Object[] AllObjects =
			GameObject.FindObjectsOfType (typeof(Object)) as Object[];

		foreach(Object o in AllObjects)
		{
		  GameObject go = o as GameObject;
			if(go != null)
			{
				aList.Add(go);
			}
		}

		AllGameObjects = new GameObject[aList.Count];
		aList.CopyTo(AllGameObjects);
	}
}
