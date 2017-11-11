using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase reactiva el spawn
public class ReactivarSpawn : MonoBehaviour {


    //En caso de trigger por parte del jugador, se alteran las variables que permiten el spawn, también se aprovecha éste momento para reducir
    //el tiempo de spawn segun el nivel actual, de inmediato se destruye el gameobject para evitar comportamientos no deseados.
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        { 
            IAEnemiga.spawnactivo = true;
            Enemigos.puedepasar = false;
            Enemigos.controlpiso = true;

        if (NivelDeDificultad.NivelActual == 2) {
            IAEnemiga.TiempoEntreSpawn = 5;
        }
        if (NivelDeDificultad.NivelActual == 3)
        {
            IAEnemiga.TiempoEntreSpawn = 4;
        }
        if (NivelDeDificultad.NivelActual == 4)
        {
            IAEnemiga.TiempoEntreSpawn = 3;
        }
        if (NivelDeDificultad.NivelActual == 5)
        {
            IAEnemiga.TiempoEntreSpawn = 2;
        }
        Destroy(gameObject);
    }
    }
}


