using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Esta clase se encarga de controlar el comportamiento de la pantalla final del juego
/// bien sea victoria o derrota
/// </summary>
public class CanvasPantallaFinal : MonoBehaviour {

    //Se asignan dos componentes de texto correspondientes a la puntuacion actual del jugador y a la
    // puntúación mas alta registrada en playerprefs.
    [Header("<TEXTOS DE PUNTUACIÓN>")]
    //La siguiente variable se crea como privada ya que sólo hay un objetivo, el cual se asignará en start.
    [Tooltip("El texto de la puntuación final")]
    public Text TextoPuntuacion;
    [Tooltip("El texto de la puntuación máxima registrada.")]
    public Text TextoRecord;
  

    //Se usa una variable privada que controla si el juego ya llegó a su final para usarla como desencadenante en las corutinas.
    //se inicializa como falsa.
    public static bool Termino = false;

   
    // Update is called once per frame
    void Update () {


        //Se asigna la variable actual de cada uno de los componentes como texto para mostrarla en pantalla.
        TextoPuntuacion.GetComponent<Text>().text = Jugador.PuntuacionStatic.ToString();
        TextoRecord.GetComponent<Text>().text = PlayerPrefs.GetFloat("PuntuacionDelJugador").ToString();

        
    }
}
