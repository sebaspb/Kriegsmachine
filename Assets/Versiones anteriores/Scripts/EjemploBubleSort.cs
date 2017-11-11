using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploBubleSort : MonoBehaviour {

	public GameObject[] GameObjectArray;

	//Ésto lo que hace es asignar un objetivo y un emisor, ese emisor debe llamarse Sphere
	void Start () 
	{
		ArrayList aList = new ArrayList();
		GameObject[] gameObjects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
		foreach(GameObject go in gameObjects)
		{
			if(go.name == "Sphere")
			{
				aList.Add(go);
			}
		}

		GameObjectArray = aList.ToArray(typeof(GameObject)) as GameObject[];
	}

	void Update()
	{
		sortObjects(GameObjectArray, out GameObjectArray);

		for(int i = 0; i < GameObjectArray.Length; i++)
		{
			
			Vector3 PositionA = GameObjectArray[i].transform.position;

			Debug.DrawRay(PositionA, new Vector3(0, i*2f, 0), Color.red);
		}

	}

	void sortObjects(GameObject[] objects, out GameObject[] sortedObjects)
	{	
		//Ésto lo que hace es que cuando llegue a 5 no lo cuente, lo que hace en sí es comparar si i es menor a 5 y sí lo es que continue
		//.lenght -1
		for(int i = 0; i  < objects.Length - 1; i++)
		{
			Vector3 PositionA = objects[i].transform.position;
			//i+1
			Vector3 PositionB = objects[i + 1].transform.position;
			Vector3 VectorToA = PositionA - transform.position;
			Vector3 VectorToB = PositionB - transform.position;
			float DistanceToA = VectorToA.magnitude;
			float DistanceToB = VectorToB.magnitude;

			if(DistanceToA > DistanceToB)
			{
				GameObject temp = objects[i];
				objects[i] = objects[i + 1];
				objects[i + 1] = temp;
			}
		}

		sortedObjects = objects;
	}
}