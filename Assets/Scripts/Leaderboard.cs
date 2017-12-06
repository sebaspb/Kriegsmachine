using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


//Esta clase se encarga de crear/controlar la leaderboard.

public class Leaderboard : MonoBehaviour {
    //Se crea un array que contendrá el objeto que mostrará la puntuación más alta
    public Text[] PuntuacionMasAlta;

    //Se crea un array que contendrá los valores de la puntuación para cada objeto
    int[] ValoresPuntuacionMasAlta;

    string[] Nombres;

    // Use this for initialization
    void Start() {
        //Se asigna un elemento al array de los valores a partir del array principal.
        ValoresPuntuacionMasAlta = new int[PuntuacionMasAlta.Length];
        Nombres = new string[PuntuacionMasAlta.Length];

        //Se hace un para con la variable X la cual aumenta de a 1 cada vez que se cumple la regla.
        for (int x = 0; x < PuntuacionMasAlta.Length; x++) {
            //La regla consiste en obtener la información almacenada en  playerprefs con el nombre de la variable y el índice correspondiente al valor actual de la X.
            ValoresPuntuacionMasAlta[x] = PlayerPrefs.GetInt("ValoresPuntuacionMasAlta" + x);
            Nombres[x] = PlayerPrefs.GetString("Nombres" + x);

        }

        MostrarPuntuacion();
    }

    

    //Esta función se encarga de guardar la puntuación actual en la leaderboard y en playerprefs
    void GuardarPuntuacion()
    {

        //Se hace un para con la variable X la cual aumenta de a 1 cada vez que se cumple la regla.
        for (int x = 0; x < PuntuacionMasAlta.Length; x++)
        {
            //La regla consiste en guardar la información actual en  playerprefs con el nombre de la variable y el índice correspondiente al valor actual de la X.
            PlayerPrefs.SetInt("ValoresPuntuacionMasAlta" + x, ValoresPuntuacionMasAlta[x]);
            PlayerPrefs.SetString("Nombres" + x, Nombres[x]);
        }


    }

    public void RevisarParaAltaPuntuacion(int _value, string _username)
    {



        for (int x = 0; x < PuntuacionMasAlta.Length; x++){

            if ( _value > ValoresPuntuacionMasAlta[x]) {

                for (int y = PuntuacionMasAlta.Length - 1; y > x; y--)
                {
                    ValoresPuntuacionMasAlta[y] = ValoresPuntuacionMasAlta[y - 1];
                    Nombres[y] = Nombres[y - 1];
                }
                ValoresPuntuacionMasAlta[x] = _value;
                Nombres[x] = _username;
                MostrarPuntuacion();
                GuardarPuntuacion();
                break;
            }

        }



        }


    void MostrarPuntuacion()
    {
        for (int x = 0; x < PuntuacionMasAlta.Length; x++)
        {
            PuntuacionMasAlta[x].text = Nombres[x] + ":" + ValoresPuntuacionMasAlta[x].ToString();
           
}

    }

	// Update is called once per frame
	void Update () {
		
	}
}
