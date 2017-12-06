using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{

    public Text puntuacion;
    
    public InputField UserName;

    int totalClicks = 0;
    int tiemporestante = 10;
    bool gameinplay = true;
    bool hecho = false;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame

    IEnumerator UnSegundo()
    {
        while (1 == 1)
        {

            yield return new WaitForSeconds(1.0f);
            tiemporestante--;
     
            if (tiemporestante <= 0)
            {

                endgame();
                break;

            }

        }





    }

    void endgame()
    {


    }


    public void IngresoNombre()
    {
        
        if (!hecho && CanvasPantallaFinal.Termino)
        {
            totalClicks = (int)Jugador.PuntuacionStatic;

            GetComponent<Leaderboard>().RevisarParaAltaPuntuacion(totalClicks, UserName.text);
            hecho = true;
            

        }
    }
}
