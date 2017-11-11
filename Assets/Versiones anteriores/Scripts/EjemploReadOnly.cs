using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ejemploSebas;

public class EjemploReadOnly : MonoBehaviour
{
	public readonly int MaxHitPoints = 50;
	public EjemploReadOnly(int hp)
	{
		this.MaxHitPoints = hp;
	} 

	void Start()
	{

		MyClass loquesea = new MyClass ();
			loquesea.MyFunction();
	}

}
