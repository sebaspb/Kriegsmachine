using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploEstructura : MonoBehaviour
{

	public int valorUno;

	struct MyStruct
	{

		public int a;

	}

	class MyClass
	{

		public int a;

	}

	void Start ()
	{
		MyClass mClass = new MyClass ();
		MyStruct mStruct = new MyStruct ();
		mClass.a = 1;
		mStruct.a = 1;
		MyStruct ms = mStruct;
	
		ms.a = 3;
		Debug.Log ("Éste es el de los struct" + ms.a + "and" + mStruct.a);
		MyClass mc = mClass; 
		mc.a = 3;
		Debug.Log("Éste es el de la clase" + mc.a + "and" + mClass.a);

	}

	const int velocidadMaxima = 100;
	public static int VelocidadMaxima
	{
		get
		{
			return velocidadMaxima;
		}
	}

}
