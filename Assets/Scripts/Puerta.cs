using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase controla la animacion de la puerta
public class Puerta : MonoBehaviour {

    //Se asigna el componente animator
    [Tooltip("Animator de la puerta")]
    Animator animator;
    //Variable interna para controlar el estado de la puerta
    bool PuertaAbierta;
 






    void Start()
    {
        //A todas las puertas se les obtiene el animator, se marcan como cerradas y se deshabilita el collider
        //Esto garantiza que no se pueden abrir hasta que se cumpla la condicion del nivel.
        animator = GetComponent<Animator>();
        PuertaAbierta = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }


    void Update()
    {
        //Si la puntuacion es diferente de 0, no hay enemigos y el spawn esta apagado entonces, el control piso, la variable puedepasar y puedeinvocar
        //cambian
        if (Jugador.PuntuacionStatic != 0)
        {
            if (Enemigos.contadorenemigos == 0)
            {
                if (!IAEnemiga.spawnactivo)
                {

                    Enemigos.controlpiso = false;
                    Enemigos.puedepasar = true;
                    IAEnemiga.puedeinvocar = true;

                }
            }

        }

        //Si puede pasar se activa el collider, de lo contrario se desactiva (este collider es el trigger que activa la animacion);
        if (Enemigos.puedepasar)
        {
            this.GetComponent<CapsuleCollider>().enabled = true;
           }
        else
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
        }

    }
   



    void OnTriggerEnter(Collider col)
    {
        //si el jugador entra en colision la puerta se abre
        if (col.gameObject.tag == "Jugador")
        {
            ControlPuerta("Abierta");
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            //si el jugador sale de colision la puerta se cierra
            ControlPuerta("Cerrada");
        }

    }

    //aqui se llama el componente del animator a traves del string dado arriba.
    void ControlPuerta(string direction) 
    {
        animator.SetTrigger(direction);
    }

}
