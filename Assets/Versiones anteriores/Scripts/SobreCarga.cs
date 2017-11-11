using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobreCarga : MonoBehaviour {

	public int Sumanro(int numeroUno, int numeroDos)
	{
    print("numero 1 antes = " + numeroUno);

        numeroUno = numeroDos;

        print("numero 1 despues = " + numeroUno);


        return numeroUno;

       

    }

	public string Suma(string letraUno, string letraDos)
	{

		return letraUno + "+" + letraDos;

	}
}
