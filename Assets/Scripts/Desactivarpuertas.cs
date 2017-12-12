using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivarpuertas : MonoBehaviour
{
    public static bool moverllave = false;
    public GameObject[] Puertas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        foreach (GameObject Puerta in Puertas)
            
            {
                
                Destroy(Puerta.GetComponent<CapsuleCollider>());
                Destroy(Puerta.GetComponent<Puerta>());
                Puerta.GetComponent<Animator>().SetTrigger("Cerrada");
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
                foreach (GameObject enemy in enemies)
                    Destroy(enemy.gameObject);

            }
    } 
    }
