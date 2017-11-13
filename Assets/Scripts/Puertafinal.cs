using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase controla el comportamiento de la ultima puerta antes del jefe
public class Puertafinal : MonoBehaviour
{
    [Tooltip("Se asigna el componente de ésta puerta para diferenciarla de las demás")]
    public GameObject puertafinal;
    //Las siguientes transformaciones se usan para subir el mecanismo de spawn de las bombas 1 piso y que aun sea funcional.
    [Tooltip("Grupo con todos los puntos de spawn de las bombas")]
    public Transform spawnbombas;
    [Tooltip("Punto final al que se moveran las bombas")]
    public Transform finalbombas;
    [Tooltip("Posicion actual de la bomba")]
    public Transform bombaactual;
    bool realizado = false;
    //variable interna para indicar que el jugador esta en el final del juego.
    public static bool final = false;


    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Si el nivel de dificultad es = a 5 puede pasar se activa.
        if(NivelDeDificultad.NivelActual == 5)
        {

            Enemigos.puedepasar = true;

        }

    }

    //En caso de trigger con el objeto jugador, se apaga el spawn, se activa el final, el nivel de dificultad sube a 6
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            IAEnemiga.spawnactivo = false;
            final = true;
            NivelDeDificultad.NivelActual = 6;
            //Se hace una busqueda de cada objeto con el tag enemigo se ingresan en un array y luego se eliminan.
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
            foreach (GameObject enemy in enemies)
                Destroy(enemy.gameObject);
            
            //Si aun no se ha hecho se mueven las bombas un piso y se cambia el condicional para que no se repita.
            if (!realizado) { 
            spawnbombas.transform.position = Vector3.Lerp(spawnbombas.position, finalbombas.position, 2);
            bombaactual.transform.Translate(Vector3.up * 30, Space.World);
                realizado = true;
            }

        }

    }
        
    }
