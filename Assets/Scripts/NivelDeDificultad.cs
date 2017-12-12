using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se usa para controlar el nivel de dificultad del juego y poder controlar el spawn enemigo.
/// </summary>
public class NivelDeDificultad : MonoBehaviour {

    //Se crea una variable estatica que guarda el nivel actual
    public static float NivelActual;

    [Tooltip("Puntos necesarios para el nivel 2")]
    public float PuntosNivel2;
    [Tooltip("Puntos necesarios para el nivel 3")]
    public float PuntosNivel3;
    [Tooltip("Puntos necesarios para el nivel 4")]
    public float PuntosNivel4;
    [Tooltip("Puntos necesarios para el nivel 5")]
    public float PuntosNivel5;

    [Tooltip("Texto puerta desbloqueada")]
    public GameObject TextoPuertaDesbloqueada;
    [Tooltip("Texto puerta final desbloqueada")]
    public GameObject TextoPuertaFinalDesbloqueada;
    //Ua variable interna que guarda el requisito para el siguiente nivel
    public float requisito;
    //Ina variable interna que guarda los puntos para el nivel 6.
    private float PuntosNivel6;
    bool realizado = false;
    // Use this for initialization
    void Start () {

        //El nivel actual se inicializa en 1 y el requisito en los puntos necesarios para el nivel 2.
        NivelActual = 1;
        requisito = PuntosNivel2;
       
    }
	
	// Update is called once per frame
	void Update () {


        //Si la puntuacion del jugador es mayor o igual a los puntos del nivel 2 el nivel actual se cambia a 2.
        if (Jugador.PuntuacionStatic >= PuntosNivel2)
        {
            NivelActual = 2;
            
        }

        //Si la puntuacion del jugador es mayor o igual a los puntos del nivel 3 el nivel actual se cambia a 3.
        if (Jugador.PuntuacionStatic >= PuntosNivel3)
        {
            NivelActual = 3;
        }

        //Si la puntuacion del jugador es mayor o igual a los puntos del nivel 4 el nivel actual se cambia a 4.
        if (Jugador.PuntuacionStatic >= PuntosNivel4)
        {
            NivelActual = 4;
        }

        //Si la puntuacion del jugador es mayor o igual a los puntos del nivel 5 el nivel actual se cambia a 5.
        if (Jugador.PuntuacionStatic >= PuntosNivel5)
        {
            NivelActual = 5;
        }

        //Si la puntuacion del jugador es mayor o igual a los puntos del nivel 5 Y la variable final de la clase puerta final
        //es verdadera el nivel se actualiza al 6.
        if (Jugador.PuntuacionStatic >= PuntosNivel5 && Puertafinal.final)
        {
            NivelActual = 6;
        }


        //Si la puntuacion del jugador = requisito se desactiva el spawn y se ejecutan las condiciones.        
        if (Jugador.PuntuacionStatic >= requisito)
        { IAEnemiga.spawnactivo = false;

            //Si el nivel actual es 2, el requisito se actualiza a los puntos para el nivel 3
            if (NivelActual >= 2 && NivelActual < 3)
            {
                //if (Enemigos.puedepasar)
                //{
                requisito = PuntosNivel3;
                
                  TextoPuertaDesbloqueada.SetActive(true);
                    StartCoroutine(OcultarMensajePuerta(3));
                //}
            }

            //Si el nivel actual es 3, el requisito se actualiza a los puntos para el nivel 4
            if (NivelActual >= 3 && NivelActual < 4)
            {
                //if (Enemigos.puedepasar)
                //{
                requisito = PuntosNivel4;
                
                   TextoPuertaDesbloqueada.SetActive(true);
                    StartCoroutine(OcultarMensajePuerta(3));
                //}
            }

            //Si el nivel actual es 4, el requisito se actualiza a los puntos para el nivel 5
            if (NivelActual >= 4 && NivelActual < 5)
            {
                //if (Enemigos.puedepasar)
                //{
                requisito = PuntosNivel5;
               
                    TextoPuertaDesbloqueada.SetActive(true);
                    StartCoroutine(OcultarMensajePuerta(3));
                //}
            }

            //Si el nivel actual es 5, el requisito se actualiza a 0, se actualiza el spawn a activo y se cambia el tiempo de spawn a 1.
            
            if (NivelActual >= 5)
            {
                IAEnemiga.spawnactivo = true;
                IAEnemiga.TiempoEntreSpawn = 2.2f;
                //if (Enemigos.puedepasar) { 
                requisito = 0;
                
                if (!realizado) { 
                TextoPuertaFinalDesbloqueada.SetActive(true);
                    realizado = true;
                    StartCoroutine(OcultarMensajePuerta(3));
                 
                }
                //}
            }
        
        
        }

      


    }
    IEnumerator OcultarMensajePuerta(float time)
    {
        yield return new WaitForSeconds(time);
        TextoPuertaDesbloqueada.SetActive(false);
        TextoPuertaFinalDesbloqueada.SetActive(false);

    }

}
 

