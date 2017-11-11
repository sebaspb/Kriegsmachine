using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysDosDimensiones : MonoBehaviour
{
	public int[,] DosDimensiones = new int [2,3];

	void Start()
	{
		GameObject a = new GameObject ("A");
		GameObject b = new GameObject ("B");
		GameObject c = new GameObject ("C");
		GameObject d = new GameObject ("D");
		GameObject e = new GameObject ("E");
		GameObject f = new GameObject ("F");
		GameObject[,] dosDimensiones = 
			new GameObject[2,3] { {a,b,c},{d,e,f} };
		InspectArray(dosDimensiones);
	}
      
	void InspectArray(GameObject[,]gos)
	{
		int columns = gos.GetLength(0);
		Debug.Log("Columnas"+columns);
		int filas = gos.GetLength(1);
		Debug.Log("Filas"+ filas);
		for(int c = 0; c < columns; c++)
		{
			for(int f = 0; f < filas; f++)
			{
				Debug.Log(gos[c,f].name);
			}
		}
	}
}



