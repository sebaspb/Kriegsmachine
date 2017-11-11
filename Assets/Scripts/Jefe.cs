using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// La clase Jefe se usa para controlar parámetros exclusivos de la pelea final.
/// </summary>
public class Jefe : MonoBehaviour
{
    
    [Header("<OPCIONES DEL ASCENSOR>")]
    [Tooltip("Objeto que se usará como ascensor")]
    public Transform Ascensor;
    //Cuidado con los puntos arriba y abajo, no son puntos centrados con el ascensor sino con el trigger que desencadena la accion.
    [Tooltip("Punto de transformación para indicar que el ascensor está arriba")]
    public Transform arriba;
    [Tooltip("Punto de transformación para indicar que el ascensor está abajo")]
    public Transform abajo;
    //Variable interna que registra si el ascensor debe bajar, por defecto está en falso.
    bool baja = false;

    [Space(10)]
    [Header("<OPCIONES DE JEFE>")]
    [Tooltip("Transform usado para mover el Jefe")]
    public Transform Boss;
    //variable interna para desactivar el disparo del jugador, por defecto es verdadera.
    public static bool jugadoractivo = true;
    //variable interna para saber si el enemigo con el que el jugador pelea es el jefe, se usa en la clase enemigo para que al morir
    //desencadene la victoria.
    public static bool esjefe = false;
    

    // Use this for initialization
    void Start()
    {
        //Inicialmente se usa getcomponent para deshabilitar el script enemigos del jefe, así no se moverá ni atacará ni tendrá ningun
        //valor hasta que se active.
       Boss.GetComponent<Enemigos>().enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Se confirma se el ascensor puede bajar.
        if (baja)
        {
            //De ser así se le asigna una velocidad de movimiento de 5 y se mueve hasta el target abajo
            //Mientras ésto sucede se desactiva el jugador.
            float velocidad = 5f;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, abajo.position, movimiento);
            jugadoractivo = false;

        }

        //Si no puede bajar; se le asigna una velocidad de 7 y el ascensor se mueve al target arriba
        //Siempre se esta moviendo, incluso en el inicio del juego, pero al estar siempre en la misma posicion no se nota.
        if (!baja)
        {
            float velocidad = 7f;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, arriba.position, movimiento);


        }

    }


    IEnumerator Comienzo(float time)
    {
        
        //Se espera durante 0 segundos para que al ascensor pueda bajar
        yield return new WaitForSeconds(time);
        baja = true;
        //Se espera 6 segundos y se habilita el script del enemigo
        yield return new WaitForSeconds(6);
        Boss.GetComponent<Enemigos>().enabled = true;
        //Se espera 5 segundos para que el ascensor suba de nuevo.
        yield return new WaitForSeconds(5);
        baja = false;
        //Se le quita el parent del ascensor al jefe.
        Boss.transform.parent = null;
        //Se activa el jugador
        jugadoractivo = true;
        //Se activa la variable es jefe.
        esjefe = true;
        
        
    }

    //En caso de trigger con el objeto y que sea el objeto con el tag jugador.
    void OnTriggerEnter(Collider col)
    {
        if (!esjefe) { 
        if (col.gameObject.tag == "Jugador")
        {
           
            Destroy(GetComponent<BoxCollider>());
         
                //Se inicia la corutina Comienzo luego de 4 segundos.
                StartCoroutine(Comienzo(4));
            }
        }
    }
}