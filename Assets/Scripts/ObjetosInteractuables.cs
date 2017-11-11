using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase controla el comportamiento de los elementos interactuables bombas y reparacion
public class ObjetosInteractuables : MonoBehaviour
{
    [Header("<OPCIONES DE OBJETO>")]
    [Space(10)]

    [Tooltip("Objeto que se usará")]
    public Transform Objeto;
    [Tooltip("Array con los diferentes puntsos de spawn para el objeto")]
    public Transform[] PuntosDeSpawn;
    [Tooltip("Cantidad de Bonus + o - que da el objeto")]
    public float CantidadDeBonus;
    [Tooltip("Sonido Asignado al objeto")]
    public AudioClip SonidoObjeto;
    private AudioSource SonidoObjetoConstante;
    [Tooltip("Volumen del sonido")]
    [Range(0, 1)]
    public float VolumenSonidoObjeto;
    [Tooltip("Distancia maxima del sonido")]
    [Range(0, 500)]
    public float DistanciaMaximaSonido;
    [Tooltip("Sistema de particulas para la explosion de la bomba")]
    public ParticleSystem ParticulasExplosion;
    [Tooltip("Sonido de la explosion de la bomba")]
    public AudioClip SonidoExplosion;
    private AudioSource SonidoExplosionConstante;
    [Tooltip("Volumen del sonido de la explosion de la bomba")]
    [Range(0, 1)]
    public float VolumenSonidoExplosion;
    [Tooltip("Rango máximo del sonido de la explosion de la bomba")]
    [Range(0, 500)]
    public float DistanciaMaximaSonidoExplosion;
    
    //Variable interna para controlar el movimiento de la llave bajo ciertas circunstancias
    public static float controlnivel = 1;

    [Tooltip("Objeto de la llave")]
    public GameObject llave;

    //Variable para controlar la existencia de la bomba
    private bool BombaExiste = true;
    //Variables internas para controla la existencia del elemento e impedir varios spawn simultaneos
    bool Existe = false;
    bool ExisteB = false;

    // Use this for initialization
    void Start()
    {

        //Se crea un nuevo audiosource y se le asigna el audio del objeto y se vuelve 3d.  
        //Este codigo se explica mejor en la clase jugador.
        AudioSource AudioSourceSonidoObjeto = gameObject.AddComponent<AudioSource>();
        AudioSourceSonidoObjeto.clip = SonidoObjeto as AudioClip;
        AudioSourceSonidoObjeto.spatialBlend = 1.0f;
        AudioSourceSonidoObjeto.rolloffMode = AudioRolloffMode.Linear;
        SonidoObjetoConstante = AudioSourceSonidoObjeto;

        //Si el objeto es una bomba
        if (Objeto.CompareTag("Bomba"))
        {
            //Se crea un nuevo audiosource para el sonido de la explosion
            AudioSource AudioSourceSonidoExplosion = gameObject.AddComponent<AudioSource>();
            AudioSourceSonidoExplosion.clip = SonidoExplosion as AudioClip;
            AudioSourceSonidoExplosion.spatialBlend = 1.0f;
            AudioSourceSonidoExplosion.rolloffMode = AudioRolloffMode.Linear;
            AudioSourceSonidoExplosion.minDistance = 0f;
            SonidoExplosionConstante = AudioSourceSonidoExplosion;

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Se ajusta el volumen y la distancia máxima a valores actuales.
        SonidoObjetoConstante.volume = VolumenSonidoObjeto;
        SonidoObjetoConstante.maxDistance = DistanciaMaximaSonido;

        //Lo mismo se aplica para la bomba;
        if (Objeto.CompareTag("Bomba")){ 
        SonidoExplosionConstante.volume = VolumenSonidoExplosion;
        SonidoExplosionConstante.maxDistance = DistanciaMaximaSonidoExplosion;

            //Si el nivel es superior o igual a 4 y la bomba no existe se llama la funcion spawn bomba.
            if (NivelDeDificultad.NivelActual >= 4) {

                if (!ExisteB) { 
                   FuncionSpawnBomba();
            }

        }


        }

        //Se llama la funcion movimiento objetos la cual se encarga de que giren
        MovimientoObjetos();

        //Si no existe se llama la funcion spawn;
        if (!Existe) { 
        FuncionSpawn();
        }

        //Si el controlnivel es diferente al nivel actual, y la variable mover llave de desacticar puertas es facil se debe
        //modificar el comportamiento de la llave al nivel correspondiente y cancelar la replica cambiando de nuevo mover llave.
        //Esto se controla desde el trigger ubicado en el descanso de la rampa de cada piso.
        if (controlnivel != NivelDeDificultad.NivelActual) {

            if (Desactivarpuertas.moverllave) { 

        if (NivelDeDificultad.NivelActual == 1)
        {
            llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(0, 4)].position, 2);
                controlnivel = NivelDeDificultad.NivelActual;
                Desactivarpuertas.moverllave = false;
        }

        if (NivelDeDificultad.NivelActual == 2)
        {
                llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(5, 9)].position, 2);
                controlnivel = NivelDeDificultad.NivelActual;
                Desactivarpuertas.moverllave = false;
            }

        if (NivelDeDificultad.NivelActual == 3)
        {
                llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(10, 14)].position, 2);
                controlnivel = NivelDeDificultad.NivelActual;
                Desactivarpuertas.moverllave = false;
            }

        if (NivelDeDificultad.NivelActual == 4)
        {
                llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(15, 19)].position, 2);
                controlnivel = NivelDeDificultad.NivelActual;
                Desactivarpuertas.moverllave = false;
            }

        if (NivelDeDificultad.NivelActual == 5)
        {
                llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(20, 24)].position, 2);
                controlnivel = NivelDeDificultad.NivelActual;
                Desactivarpuertas.moverllave = false;
            }}
                if (NivelDeDificultad.NivelActual == 6)
                {
                    llave.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(20, 24)].position, 2);
                    controlnivel = NivelDeDificultad.NivelActual;
                    Desactivarpuertas.moverllave = false;
                
            }
        }
    }

    //Esta funcion solo hace que la llave gire sobre si misma.
    void MovimientoObjetos()
    {

        if (Objeto.CompareTag("Reparacion"))
        {

            transform.Rotate(new Vector3(0f, 45f, 45f) * Time.deltaTime);



            

        }
    }

    //Funcion spawm
    void FuncionSpawn()
    {
        //Se ajusta el volumen
       
        SonidoObjetoConstante.volume = VolumenSonidoObjeto;
        
        //la llave aparece en el primer piso y se cambia su existencia a true.
        if (Objeto.CompareTag("Reparacion")) { 
            Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(0, 5)].position, 2);
   
        }
      
        Existe = true;

    }


    //Funcion spawm bomba
    void FuncionSpawnBomba()
{

    if (Objeto.CompareTag("Bomba"))
    {
            //Se selecciona un numero al azar entre los 64 puntos posibles de spawn.
            var indice = PuntosDeSpawn[Random.Range(0, PuntosDeSpawn.Length)];
           //se mueve a éste lugar en especifico tomando su rotacion final
            Objeto.transform.position = Vector3.Lerp(Objeto.position, indice.position, 2);
            Objeto.transform.rotation = (indice.transform.rotation);
            SonidoObjetoConstante.transform.position = Vector3.Lerp(Objeto.position, indice.position, 2);
            //Se ajusta el loop (este sonido es el bip)
            SonidoObjetoConstante.loop = true;
            SonidoObjetoConstante.spatialBlend = 1f;
            SonidoObjetoConstante.dopplerLevel = 0;
            SonidoObjetoConstante.rolloffMode = AudioRolloffMode.Linear;
            SonidoObjetoConstante.Play();
            //Se cambia la existencia de la bala
            ExisteB = true;
        }
}


    //En caso de trigger y que la colision se dada por el jugador para el objeto se ejecutan las condiciones de movimiento del objeto.
    void OnTriggerEnter(Collider colision)
    {

        if (Objeto.CompareTag("Reparacion"))
        {
            //En este caso se compara el nivel actual para asignar los nuevos puntos de spawn.
            if (colision.CompareTag("Jugador"))
            {
                if (NivelDeDificultad.NivelActual == 1)
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(0, 4)].position, 2);
                }

                if (NivelDeDificultad.NivelActual == 2)
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(5, 9)].position, 2);
                }

                if (NivelDeDificultad.NivelActual == 3)
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(10, 14)].position, 2);
                }

                if (NivelDeDificultad.NivelActual == 4)
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(15, 19)].position, 2);
                }

                if (NivelDeDificultad.NivelActual == 5 )
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(15, 19)].position, 2);

                }
                if (NivelDeDificultad.NivelActual == 6)
                {
                    Objeto.transform.position = Vector3.Lerp(Objeto.position, PuntosDeSpawn[Random.Range(20, 24)].position, 2);

                }

                SonidoObjetoConstante.transform.position = Vector3.Lerp(Objeto.position, Objeto.position, 2);

                SonidoObjetoConstante.loop = false;
                SonidoObjetoConstante.dopplerLevel = 0;
                
                SonidoObjetoConstante.Play();

                //Este condicional permite recuperar vida solo si no la tiene al máximo.
                if (Jugador.SaludJugadorStatic < Jugador.BarraDeVidaStatic.maxValue)
                {
                    Jugador.SaludJugadorStatic += CantidadDeBonus;
                    Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
                }
               
                //Una vez la llave se toca se deshabilita el render y el collider y se llama la reaparacion.
                GetComponent<Renderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(SpawnReparacion(0));

            }

        }

        if (Objeto.CompareTag("Bomba"))
        {
            //En caso de que las balas de jugador hagan trigger con la bomba
            if (colision.CompareTag("Balas Jugador"))
            {

               //Se reproduce el sonido de explosión
                SonidoExplosionConstante.transform.position = Vector3.Lerp(Objeto.position, Objeto.position, 2);
                SonidoExplosionConstante.loop = false;
                SonidoExplosionConstante.Play();

                
                //se instancia la explosion en éste lugar sin loop y se reproduce, se destruye una vez termina 
                ParticleSystem explosion = Instantiate(ParticulasExplosion, transform.position, Quaternion.identity) as ParticleSystem;
                explosion.transform.Rotate(new Vector3(-40f, 20f, 45));
                explosion.loop = false;
                explosion.Play();
                Destroy(explosion.gameObject, explosion.duration);

                //Se obtiene un nuevo punto de spawn se mueve la bomba y se oculta y todo comienza de nuevo gracias a la corutina
                var indice = PuntosDeSpawn[Random.Range(0, PuntosDeSpawn.Length)];

                Objeto.transform.position = Vector3.Lerp(Objeto.position, indice.position, 2);
                Objeto.transform.rotation = (indice.transform.rotation);
                SonidoObjetoConstante.transform.position = Vector3.Lerp(Objeto.position, indice.position, 2);

                SonidoObjetoConstante.loop = true;
                SonidoObjetoConstante.spatialBlend = 1f;
                SonidoObjetoConstante.dopplerLevel = 0;

                SonidoObjetoConstante.rolloffMode = AudioRolloffMode.Linear;
                SonidoObjetoConstante.Play();

                GetComponent<Renderer>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                StartCoroutine(ReaparecerBomba(4f));
                }

            //Si es el jugador quien toca la bomba se repite casi lo mismo; la diferencia es que el jugador pierde vida
            // ys e activa la pantalla final por ser muerte instanea
            if (colision.CompareTag("Jugador"))
            {

                //print("jugador");
                SonidoExplosionConstante.transform.position = Vector3.Lerp(Objeto.position, Objeto.position, 2);
                SonidoExplosionConstante.loop = false;
                SonidoExplosionConstante.Play();
            

                Jugador.SaludJugadorStatic -= Jugador.SaludJugadorStatic;
                Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
                //print(Jugador.SaludJugadorStatic);
                CanvasPantallaFinal.Termino = true;
                ParticleSystem explosion2 = Instantiate(ParticulasExplosion, transform.position, Quaternion.identity) as ParticleSystem;
                explosion2.transform.Rotate(new Vector3(-40f, 20f, 45));
                explosion2.loop = false;
                explosion2.Play();
                SonidoObjetoConstante.Stop();
                Destroy(explosion2.gameObject, explosion2.duration);
            }

        }
    }


    //La reaparacion de la llave es inmediata y activa de nuevo los dos componentes.
    IEnumerator SpawnReparacion(float time)
    {

        yield return new WaitForSeconds(time);
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        
    }

    //La reaparacion de la bomba depende del tiempo dado arriba.
    IEnumerator ReaparecerBomba(float time)
    {
        
        yield return new WaitForSeconds(time);
        GetComponent<Renderer>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
       
    }

}