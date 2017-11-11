using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumeradores : MonoBehaviour 
{
	public enum TipoDePrimitiva 
	{
		Sphere,Capsule,Cylinder,Cube,Plane
	}

	public TipoDePrimitiva tipoDePrimitiva;

	public enum tipoDeColor
	{
		red,
		blue,
		green
	}
	public tipoDeColor miColor;

	void Update()
	{
		switch(miColor)
		{
		case tipoDeColor.red:
			Debug.Log ("Color seleccionado: Rojo");
			break;
		case tipoDeColor.blue:
			Debug.Log ("Color seleccionado: Azul");
			break;	
		case tipoDeColor.green:
			Debug.Log ("Color seleccionado: Verde");
			break;
		}
	}
}
			