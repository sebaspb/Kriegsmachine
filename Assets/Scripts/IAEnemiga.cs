using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de controlar el spawn de los enemigos a lo largo del juego
/// </summary>
public class IAEnemiga : MonoBehaviour
{

    [Header("<OPCIONES DE ENEMIGOS>")]
    [Tooltip("Arreglo que almacena la lista de enemigos")]
    public GameObject[] EnemigosLista;
    [Tooltip("Segundos que transcurren entre cada spawn")]
    public float TiempoDeSpawn = 10f;
    [Tooltip("Arreglo que contiene los distintos puntos de spawn")]
    public Transform[] PuntosDeSpawn;
    //Variable para comprobar si el sistema de spawn está activo o no
    public static bool spawnactivo = true;
    //Variable para comprobar si se puede invocar enemigos o no
    public static bool puedeinvocar= false;
    //Variable que guarda hace cuanto tiempo fue la última aparición.
    private float UltimaAparicion;
    //Variable que indica el tiempo inicial de spawn para los enemigos, por defecto es 7 segundos entre uno y otro para el nivel 1.
    public static float TiempoEntreSpawn = 10f;

    // Update is called once per frame
    void Update()
    {
        //Se llama la función spawn en el update
        Spawn();
    }

    void Spawn()
    {
        //Si el spawn está activo significa que el sistema de spawn puede avanzar
        if (spawnactivo)
        {
            //Si ya se cumplio la condición de tiempo necesario para el siguiente spawn entonces puede invocarse un enemigo.
            if (Time.time - UltimaAparicion > TiempoEntreSpawn)
            {
                //Se actualiza la variable de la ultima aparición.
                UltimaAparicion = Time.time;

                //Si el nivel de dificultad es uno la condición es la siguiente:
                /*Se crea una variable NumeroPuntoDeSpawn que es un número aleatorio entre 0 y 2; éste tipo de número aleatorio es
                * del modo inclusivo/exlusivo; es decir; el 0 está incluído en el aleatorio pero el 2 está exluído; ésto quiere
                * decir que el número aleatorio resultante únicamente puede ser 0 y 1*/

                if (NivelDeDificultad.NivelActual==1)
                {
                    /*Los puntos de spawn[0] y [1] se encuentran en el primer piso.
                    * //Se le indica que se invocará únicamente al elemento [0] del array de la lista de enemigos por lo cual.
                    * En éste nivel tendremos un sólo enemigo que puede salir en dos posiciones.
                    * El enemigo se ajusta ala posición y a la rotación del punto de spawn*/
                    int NumeroPuntoSpawn = Random.Range(0, 2);
                    Instantiate(EnemigosLista[0], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);
                    /*Para finalizar, se indica que el contador de enemigos se debe incrementar en 1*/
                    Enemigos.contadorenemigos += 1;

                }

                /*De aquí en adelante se usa el mismo método que en el nivel de dificultad anterior; la única diferencia es los puntos
                    * de spawn que se referencian y los enemigos que se invocan, en éste caso se invocan 2 enemigos diferentes.*/
                if (NivelDeDificultad.NivelActual == 2)
                {

                    int NumeroPuntoSpawn = Random.Range(2, 4);
                    Instantiate(EnemigosLista[Random.Range(0, 2)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);
                    Enemigos.contadorenemigos += 1;
                }

                if (NivelDeDificultad.NivelActual == 3)
                {
                    int NumeroPuntoSpawn = Random.Range(4, 6);
                    Instantiate(EnemigosLista[Random.Range(0, 3)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);
                    Enemigos.contadorenemigos += 1;

                }

                if (NivelDeDificultad.NivelActual == 4 )
                {

                    int NumeroPuntoSpawn = Random.Range(6, 8);
                    Instantiate(EnemigosLista[Random.Range(0, 4)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);
                    Enemigos.contadorenemigos += 1;

                }

                //El nivel de dificultad 5 es particular; se usan los mismos puntos de spawn que en anterior; pero a través de otra instrucción
                //se hace que éste spawn sea permanente hasta que el jugador cruce el trigger para cancelarlo.
                if (NivelDeDificultad.NivelActual == 5)
                {
                    int NumeroPuntoSpawn = Random.Range(6, 8);
                    Instantiate(EnemigosLista[Random.Range(0, 4)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);
                    Enemigos.contadorenemigos += 1;

                }

            }       
        }
    }

}
