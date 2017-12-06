using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Ésta clase tiene como funcion controlar las diferentes "ventanas" que se muestran en la interfaz de menú.
/// </summary>
public class InterfazMenu : MonoBehaviour
{
    //Variable interna que futuramente se usará para arreglar el bug de la bala que se dispara al momento de dar click en pausa.
    public static bool InputHabilitado = true;
    [Header("<OPCIONES DE CANVAS>")]
    [Space(10)]

    [Tooltip("Canvas del menú principal")]
    public GameObject CanvasMenu;
    [Tooltip("Canvas de las instrucciones")]
    public GameObject CanvasInstrucciones;
    [Tooltip("Canvas de las opciones")]
    public GameObject CanvasOpciones;
    [Tooltip("Canvas de los créditos")]
    public GameObject CanvasCreditos;
    [Tooltip("Canvas de la sección resetear progreso")]
    public GameObject CanvasResetearProgreso;
    [Tooltip("Objeto usado como leaderboard")]
    public GameObject CanvasLeaderBoard;
    [Tooltip("Objeto usado como boton pausa")]
    public GameObject BotonPausa;
    [Tooltip("Objeto usado como boton continuar")]
    public GameObject BotonContinuar;
    [Header("<OPCIONES DE AUDIO>")]
    [Space(10)]
    [Tooltip("Slider usado para controlar el volumen de la música")]
    public Slider Musicas;
    [Tooltip("Slider usado para controlar el volumen de los efectos")]
    public Slider Volumen;
    //Para poder controlar la música y los efectos por separado, es necesario que la música esté en un audiosource
    //completamente independiente y exclusivo.
    [Tooltip("Audiosource de la música.")]
    public AudioSource asmusica;
    //Se convierten en estático los valores para poder modificarlos desde afuera
    public static AudioSource as2musica;
    public static float VolumenEfectos;
    public static float VolumenMusica;

    //Variable interna usada para el control checkbox de musica y efectos encendidos.
    private bool alternarmusica = true;
    private bool alternarsonido = true;


    public void Start()
    {
        //Se inicializa el Audiosource estático de la música con el audiosource público.
        as2musica = asmusica;
        //Se le indica al listener global que debe ignorar el volumen de la música; ésto se hace para poder modificarla independientemente
        //de los demás sonidos.
        as2musica.ignoreListenerVolume = true;
        
        //Se asignan los valores correspondientes de los sliders.
        VolumenEfectos = Volumen.value;
        VolumenMusica = Musicas.value;

        //Por defecto el boton pausa está activo y continuar desactivado.
        //Estos dos botones comparten el mismo espacio/tiempo por lo cual es necesario que no estén los dos activos simultaneamente.
        BotonPausa.SetActive(true);
        BotonContinuar.SetActive(false);
    }

    public void Update()
    {
        //Se asigna el DontDestroyOnLoad para la música; ésto se hace con el fin de que la música no deje de sonar en caso de cambio
        //de escena.
        DontDestroyOnLoad(as2musica);

        //Se le informa al audiolistener global que el volumen que debe tomar es el del slider del volumen de los efectos.
        AudioListener.volume = VolumenEfectos;

        //Se le informa al audiosource estatico de la música que el volumen que debe tomar es
        //el del slider del volumen de la musica.
        as2musica.volume = VolumenMusica;

    }


    //La función volumen alfa se llama cuando se modifica el slider para modificar el volumen de los efectos.
    public void Volumenalfa()
    {
        VolumenEfectos = Volumen.value;
    }

    //La función volumen beta se llama cuando se modifica el slider para modificar el volumen de la música.

    public void Volumenbeta()
    {
        VolumenMusica = Musicas.value;
    }

    //La funcion pausa se llama desde el boton pausa y el boton continuar.
    public void Pausa()
    {
        /*Si el juego NO está en pausa entonces se debe poner en pausa, se debería deshabilitar el input
         * Se activa el canvas menu; se desactiva el boton pausa y se activa el boton continuar.*/
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            InputHabilitado = false;
            CanvasMenu.gameObject.SetActive(true);
            BotonPausa.SetActive(false);
            BotonContinuar.SetActive(true);
        }
        /*Si el juego está en pausa entonces se debe reanudar, se debería habilitar el input
        * Se desactiva el canvas menu; se activa el boton pausa y se desactiva el boton continuar.*/
        else
        {
            Time.timeScale = 1.0f;
            InputHabilitado = true;
            CanvasMenu.gameObject.SetActive(false);
            //En éste punto el botón pausa se desactiva y se activa para corregir un bug en el que el botón permanece
            //seleccionado constantemente.
            BotonContinuar.GetComponent<Button>().enabled = false;
            BotonContinuar.GetComponent<Button>().enabled = true;
            BotonPausa.SetActive(true);
            //Se asegura que no hallan ventanas abiertas luego de continuar el juego.
            BotonContinuar.SetActive(false);
            CanvasInstrucciones.SetActive(false);
            CanvasOpciones.SetActive(false);
            CanvasResetearProgreso.SetActive(false);
            CanvasCreditos.SetActive(false);
        }

    }

    //La función activar instrucciones se llama desde el boton instrucciones, su funcion es ocultar el canvas menú y mostrar
    //el canvas instrucciones.
    public void ActivarInstrucciones()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasInstrucciones.gameObject.SetActive(true);
    }

    //La función activar opciones se llama desde el boton opciones, su funcion es ocultar el canvas menú y mostrar
    //el canvas opciones.
    public void ActivarOpciones()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasOpciones.gameObject.SetActive(true);
    }

    //La función activar creditos se llama desde el boton creditos, su funcion es ocultar el canvas menú y mostrar
    //el canvas creditos.
    public void ActivarCreditos()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasCreditos.gameObject.SetActive(true);
    }

    //La función activar leaderboard se llama desde el boton leaderboard, su funcion es mostrar el canvas leaderboard.
    public void ActivarLeaderBoard()
    {
        CanvasLeaderBoard.gameObject.SetActive(false);
        CanvasLeaderBoard.gameObject.SetActive(true);
    }



    //La función activar resetearprogreso se llama desde el boton resetearprogreso, su funcion es mostrar
    //el canvas resetearprogreso.
    public void ActivarResetearProgreso()
    {
        CanvasResetearProgreso.gameObject.SetActive(true);
    }

    //La función volver se llama desde el volver, su funcion es mostrar el canvas menu y deshabilitar todos los demas
    //(instrucciones,opciones,creditos y resetearprogreso)
    public void Volver()
    {
        CanvasMenu.gameObject.SetActive(true);
        CanvasInstrucciones.gameObject.SetActive(false);
        CanvasOpciones.gameObject.SetActive(false);
        CanvasCreditos.gameObject.SetActive(false);
        CanvasResetearProgreso.gameObject.SetActive(false);

    }

    //La función volver2 se llama exclusivamente desde el volver del leaderboard, su funcion es ÚNICAMENTE ocultar el leaderboard.
    public void Volver2()
    {

        CanvasLeaderBoard.gameObject.SetActive(false);

    }

    //Cargar escena nos permite movernos entre escenas se le asignó al boton Jugar y Menú principal, al momento de invocarla
    //Se destruye el audiosource estático que tenía la música de fondo y el juego se reanuda, ésto es para que al jugar, el juego 
    //no inicie pausado.
    public void CargarEscena(string nombreEscena)
    {
        Destroy(as2musica);
        SceneManager.LoadScene(nombreEscena);
        Time.timeScale = 1.0f;
        
    }

    //La funcion salir se llama desde el boton salir, ésta funcion solo se puede apreciar en la build, en el editor no tiene uso.
    public void Salir()
    {
        Application.Quit();
    }

    //La funcion alternar volumen musica se llama desde el checkbox que controla la música.
    public void Alternarvolumenmusica()
    {
        //Si el volumen de la musica es diferente de 0, entonces se debe silenciar por completo; y el slider debe desactivarse.
        if (VolumenMusica != 0)
        {
            VolumenMusica = 0;

            Musicas.interactable = false;

        }
        else
        {
            //de lo contrario; se activará el slider y el volumen de la música recuperará su valor.
            VolumenMusica = Volumen.value;
            Musicas.interactable = true;
        }


    }

    //Esta funcion se llama desde el checkbox del volumen de los efectos y sigue la misma lógica que la función anterior.
    public void Alternarvolumenefectos()
    {

        if (VolumenEfectos != 0)
        {
            VolumenEfectos = 0;

            Volumen.interactable = false;

        }
        else
        {
            VolumenEfectos = Volumen.value;
            Volumen.interactable = true;
        }
    }

    //La función resetear se llama desde el boton SI que se encuentra dentro del canvas resetear progreso; ésta función borra por
    //completo todas las variables locales generadas por el juego, en éste caso en particular la puntuación máxima registrada.
    public void resetear()
    {

        PlayerPrefs.DeleteAll();
        Volver();
    }

}