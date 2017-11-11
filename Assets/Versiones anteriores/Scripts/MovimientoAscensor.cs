using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MovimientoAscensor : MonoBehaviour
{
    public Transform Ascensor;
    public Button[] botonarray;
    public Transform[] target;
    public float velocidad = 1f;
    public static int nrotarget;
    public GameObject jugador;
    public Transform caja;
    public bool quieto = true;
    bool estadentro = false;
    float pisoactual;
    public Button btnpedir;
    public GameObject textopedir;
    void Start()
    {

        botonarray[0].onClick.AddListener(piso1);
        botonarray[1].onClick.AddListener(piso2);
        botonarray[2].onClick.AddListener(piso3);
        botonarray[3].onClick.AddListener(piso4);
        botonarray[4].onClick.AddListener(piso5);
        botonarray[5].onClick.AddListener(piso6);
        botonarray[6].onClick.AddListener(piso7);
        botonarray[7].onClick.AddListener(piso8);
        botonarray[8].onClick.AddListener(piso9);
        botonarray[9].onClick.AddListener(piso10);

    }

    void Update()
    {

        print("esta quieto" + quieto);

        if (!quieto){
            btnpedir.interactable = false;
          
        }

        

         

            if (estadentro) {
            if (quieto)
            {


                botonarray[0].interactable = true;
            botonarray[0].enabled = false;
            botonarray[0].enabled = true;
            botonarray[1].interactable = true;
            botonarray[1].enabled = false;
            botonarray[1].enabled = true;
            botonarray[2].interactable = true;
            botonarray[2].enabled = false;
            botonarray[2].enabled = true;
            botonarray[3].interactable = true;
            botonarray[3].enabled = false;
            botonarray[3].enabled = true;
            botonarray[4].interactable = true;
            botonarray[4].enabled = false;
            botonarray[4].enabled = true;
            botonarray[5].interactable = true;
            botonarray[5].enabled = false;
            botonarray[5].enabled = true;
            botonarray[6].interactable = true;
            botonarray[6].enabled = false;
            botonarray[6].enabled = true;
            botonarray[7].interactable = true;
            botonarray[7].enabled = false;
            botonarray[7].enabled = true;
            botonarray[8].interactable = true;
            botonarray[8].enabled = false;
            botonarray[8].enabled = true;
            botonarray[9].interactable = true;
            botonarray[9].enabled = false;
            botonarray[9].enabled = true;


        }

        if (!quieto)
        {
                
            
            botonarray[0].interactable = false;
            botonarray[1].interactable = false;
            botonarray[2].interactable = false;
            botonarray[3].interactable = false;
            botonarray[4].interactable = false;
            botonarray[5].interactable = false;
            botonarray[6].interactable = false;
            botonarray[7].interactable = false;
            botonarray[8].interactable = false;
            botonarray[9].interactable = false;

        }
        }

        if (!estadentro)
        {
            botonarray[0].interactable = false;
            botonarray[1].interactable = false;
            botonarray[2].interactable = false;
            botonarray[3].interactable = false;
            botonarray[4].interactable = false;
            botonarray[5].interactable = false;
            botonarray[6].interactable = false;
            botonarray[7].interactable = false;
            botonarray[8].interactable = false;
            botonarray[9].interactable = false;
        }

        
            if (quieto)
            {

                btnpedir.interactable = true;
            btnpedir.enabled = false;
            btnpedir.enabled = true;
        }

        
    }

    void piso1()

    {
        nrotarget = 0;

    }

    void piso2()
    {
        nrotarget = 1;

    }

    void piso3()
    {
        nrotarget = 2;

    }

    void piso4()
    {
        nrotarget = 3;

    }

    void piso5()
    {
        nrotarget = 4;

    }

    void piso6()
    {
        nrotarget = 5;

    }

    void piso7()
    {
        nrotarget = 6;

    }

    void piso8()
    {
        nrotarget = 7;

    }

    void piso9()
    {
        nrotarget = 8;

    }

    void piso10()
    {
        nrotarget = 9;

    }




    public bool SeEstaEjecutando = false;
    public void Contenedor()
    {
        quieto = false;
        if (!SeEstaEjecutando)
        {
            
            StartCoroutine(CorutinaMovimiento());
        }
    }
    private IEnumerator CorutinaMovimiento()
    {
     
        
        SeEstaEjecutando = true;
       
        while (SeEstaEjecutando)
        {
           

            Vector3 antigua = Ascensor.transform.position;
        //print("antigua " + antigua);
           
            float movimiento = velocidad * Time.deltaTime;
                Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);
           

            Vector3 actual = Ascensor.transform.position;
           // print("actual " + actual);
           
              
           
            yield return null;
            
            if (antigua == actual) { quieto = true;
                // StopCoroutine(CorutinaMovimiento());
                }
            if (antigua != actual) { quieto = false; }
        }
           
 SeEstaEjecutando = false;
        }


public void pedir()
    {

                  if (Jugadorant.pisoactualstatic == 1)
        {
            nrotarget = 0;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }

        if (Jugadorant.pisoactualstatic == 2)
        {
            nrotarget = 1;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }

        if (Jugadorant.pisoactualstatic == 3)
        {
            nrotarget = 2;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 4)
        {
            nrotarget = 3;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 5)
        {
            nrotarget = 4;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 6)
        {
            nrotarget = 5;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 7)
        {
            nrotarget = 6;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 8)
        {
            nrotarget = 7;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 9)
        {
            nrotarget = 8;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);


        }
        if (Jugadorant.pisoactualstatic == 10)
        {
            nrotarget = 9;
            float movimiento = velocidad * Time.deltaTime;
            Ascensor.transform.position = Vector3.MoveTowards(Ascensor.transform.position, target[nrotarget].position, movimiento);

            }
        }

       // Vector3 actual = Ascensor.transform.position;
        // print("actual " + actual);





        //if (antigua == actual)
        //{
        //    btnpedir.interactable = true;
        //    btnpedir.enabled = false;
        //    btnpedir.enabled = true;
        //    textopedir.GetComponent<Text>().text = "PEDIR";

        //}
        //if (antigua != actual) {
        //    textopedir.GetComponent<Text>().text = "EN MOVIMIENTO";
        //    btnpedir.interactable = false;
        //    btnpedir.enabled = false;
        //    btnpedir.enabled = true;
        //}

    


    private void OnCollisionStay(Collision collision)
    {
        jugador.transform.SetParent(caja, true);
        caja.transform.SetParent(Ascensor, true);
        estadentro = true;



       
    }

    private void OnCollisionExit(Collision collision)
    {
        jugador.transform.parent = null;
        estadentro = false;

    }



}