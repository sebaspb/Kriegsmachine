using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// En ésta clase se controlarán todas las variables y características de los enemigos.
/// Excepto el Spawn de los mismos que se controla en el script IAEnemiga.
/// </summary>
/// 
//INICIO CLASE ENEMIGOS
public class Enemigos : MonoBehaviour
{

    /// <summary>
    /// Se crearán todas las variables privadas y las públicas que se verán reflejadas en el inspector; también se crearán variables estáticas.
    /// Se usarán HEADERS y TOOLTIPS y SPACES para organizar todo dentro del inspector de unity.
    /// Las opciones de formato como [space] y [range] se colocan antes del objeto que se quiere modificar.
    /// </summary>
    /// 

    [Header("<OPCIONES DE ENEMIGO>")]
    [Space(10)]

    [Header("<OPCIONES DE OBJETIVO>")]
    //La siguiente variable se crea como privada ya que sólo hay un objetivo, el cual se asignará en start.
    [Tooltip("El objetivo al cual seguirá éste enemigo")]
    public Transform Objetivo;

    [Space(10)]
    [Header("<OPCIONES DE MOVIMIENTO>")]
    [Tooltip("Velocidad a la cual se moverá el enemigo, valor por defecto 10")]
    public float VelocidadEnemigo = 10f;

    [Tooltip("Distancia minima a la cual puede estar el enemigo de el objetivo, valor por defecto 10")]
    public float DistanciaMinima = 10f;

    [Tooltip("Renderer de las orugas al cual se le asignará el movimiento de la textura")]
    public Renderer orugas;
    [Tooltip("Velocidad a la cual se desplazará la textura de las orugas del tanque.")]
    public float velocidadscrollorugas;

    [Space(10)]
    [Header("<OPCIONES DE SALUD>")]
    [Tooltip("Salud del enemigo, valor por defecto 150")]
    public float SaludEnemigo = 150f;
    [Tooltip("Barra de vida asigna al enemigo")]
    public Slider BarraDeVidaEnemigo;
    


    [Space(10)]
    [Header("<OPCIONES DE Disparo>")]

    [Tooltip("Tiempo que transcurre hasta el siguiente disparo valor por defecto 1")]
    public float SiguienteDisparo = 1f;

    //Esta variable interna controla si elenemigo puede atacar o no según la distancia.
    bool PuedeAtacar;



    [Tooltip("Cadencia de disparo, se usa para controlar el tiempo entre disparo y disparo")]
    public float Cadencia;

    [Tooltip("Prefab usado como bala por el enemigo")]
    public GameObject Bala;

    [Tooltip("Emisor de Bala")]
    public GameObject EmisorDeBalas;

    [Tooltip("Fuerza de bala enemiga")]
    public float FuerzaBala;

    [Tooltip("Sonido de la bala")]
    public AudioClip SonidoBala;
    //La siguiente variable se usa para poder actualizar el audiosource anterior en tiempo real en el inspector.
    private AudioSource AudioSourceSonidoBalaConstante;
    //Variable interna para controlar que solo se cree una instancia de éste audiosource.
    bool AudioSourceSonidoBalaCreado = false;
    [Tooltip("Volumen del sonido de la bala")]
    [Range(0, 1)]
    public float VolumenSonidoBala;

    //[Tooltip("El daño ocasionado por la bala enemiga")]
    //public float DañoCausado;
    ////Se convierte en estática para poderla llamar desde otros scripts.
    //public static float DañoCausadoStatic;
    //La siguiente variable estática se usa para saber si el jugador puede pasar por la siguiente puerta o se encuentra bloqueada.
    public static bool puedepasar = false;


    //Las siguientes 2 variables son para indicar si el enemigo ya salió de la zona de spawn o no, si se quiere modificar en el inspector
    //se deben descomentar las dos lineas siguientes y volver pública las variables.
    //[Space(10)]
    //[Header("<OPCIONES DE SPAWN>")]
    public bool EstaEnSpawn = true;
    public bool EstaGirando = true;

    [Space(10)]
    [Header("<OPCIONES DE PUNTUACION>")]
    [Tooltip("Los puntos que dará éste enemigo al morir")]
    public float Puntos;

    [Space(10)]
    [Header("<OPCIONES DE SONIDO>")]
    [Tooltip("Sonido que se usará como motor del tanque")]
    public AudioClip SonidoMotor;
    //La siguiente variable se usa para poder actualizar el audiosource anterior en tiempo real en el inspector.
    private AudioSource AudioSourceSonidoMotorConstante;
    //Variable interna para controlar que solo se cree una instancia de éste audiosource.
    bool AudioSourceSonidoMotorCreado = false;
    [Tooltip("Volumen del sonido del motor")]
    [Range(0, 1)]
    public float VolumenSonidoMotor;
    [Tooltip("Pitch del sonido del motor")]
    [Range(-3, 3)]
    public float PitchSonidoMotor = 1;

    [Header("<OPCIONES DE DESTRUCCIÓN>")]
    [Tooltip("Sistema de partículas usado para la destrucción del enemigo")]
    public ParticleSystem Destruccion;

    //La siguiente variable es para indicar si el jugador puede rellenar su barra de poder o no.
    public static bool ganarpoder = false;
    //Una variable interna para llevar la cuenta de los enemigos instanciados y así poder saber cuando han muerto todos ellos.
    public static float contadorenemigos = 0;
    //La variable control piso se usa para mover el objeto de reparación.
    //Si el jugador no toma la llave en el piso uno por ejemplo, al momento de pasar las zonas de colisión de paso obligado en el
    //segundo piso, la llave se moverá a los respectivos puntos de spawn.
    public static bool controlpiso = true;

    [Header("<OPCIONES DE INTERFAZ>")]
    [Tooltip("Canvas que se mostrará en caso de victoria")]
    public GameObject CanvasVictoria;
    //INICIO FUNCION START
    void Start()
    {
        //Se asigna el objetivo, al ser sólo el jugador es igual para todos los enemigos.
        Objetivo = GameObject.Find("Jugador").transform;

        //Se inicializa la barra de vida con los valores de la salud del enemigo.
        BarraDeVidaEnemigo.maxValue = SaludEnemigo;
        BarraDeVidaEnemigo.value = SaludEnemigo;
        

    }



    //FINAL FUNCION START

    //INICIO FUNCION UPDATE
    void Update()
    {

        //Se inicializan las variables estáticas para poderlas modificar en el inspector en tiempo real
        //DañoCausadoStatic = DañoCausado;

        //se inicializan las demas funciones
        IniciarMotor();
        MovimientoEnemigo();
        Ataque();
        Muerte();
    }
    //FINAL FUNCION UPDATE

    //INICIO FUNCION INICIAR MOTOR
    public void IniciarMotor()
    {
        if (!AudioSourceSonidoMotorCreado)
        {
            //Se iniciará creando un nuevo AudioSource, al cual se le asignará el AudioClip correspondiente seleccionado en el inspector; luego se reproducirá este AudioSource.
            //Este audiosurce no se destruirá y tiene loop activo
            AudioSource AudioSourceMotor = gameObject.AddComponent<AudioSource>();
            AudioSourceMotor.clip = SonidoMotor as AudioClip;
            AudioSourceMotor.pitch = 1;
            AudioSourceMotor.loop = true;
            AudioSourceSonidoMotorCreado = true;
            AudioSourceSonidoMotorConstante = AudioSourceMotor;
            //Se comprueba que no se esté reproduciendo.
            if (!AudioSourceMotor.isPlaying)
            {
                AudioSourceMotor.Play();
            }


        }
        //Codigo usado para modificar el audio en el inspector en tiempo real.
        AudioSourceSonidoMotorConstante.volume = VolumenSonidoMotor;
        AudioSourceSonidoMotorConstante.pitch = PitchSonidoMotor;

    }
    //FINAL FUNCION INICIAR MOTOR

    //INICIO FUNCION MovimientoEnemigo
    //Esta función controla el movimiento del enemigo.
    public void MovimientoEnemigo()
    {
        //Se revisa si el enemigo está en la zona de spawn; de ser así
        //se le asigna un movimiento hacia el frente y se llama la función movimientoorugas.
        if (EstaEnSpawn)
        {
            float Movimiento = VelocidadEnemigo * Time.deltaTime;
            transform.Translate(new Vector3(0f, 0f, VelocidadEnemigo) * Time.deltaTime);
            MovimientoOrugas();

        }

        //Se revisa si el enemigo ya salió de la zona de spawn, de ser así se girará hacia el objetivo.
        if (!EstaEnSpawn)
        {
            //Se usa la rotación Quaternion y Slerp para que al momento de salir de la zona de spawn el giro sea
            //paulatino y no sea un brinco instantáneo, la velocidad de rotacion 2.7f está directamente ligada al tiempo de llamado
            //de la corutina está girando, se deben modificar los dos valores hasta lograr que el giro sea lento y fluido.
            //así se evitarán inclinicaciones extrañas debido al objetivo del enemigo.
            var targetRotation = Quaternion.LookRotation(Objetivo.gameObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2.7f * Time.deltaTime);

            //Se crea una nueva variable privada llamada distancia, la cual compara la posición entre el enemigo y el objetivo.
            float Distancia = Vector3.Distance(Objetivo.position, transform.position);

            //Si distancia es mayor que la distancia minima significa que el enemigo debe acercarse al objetivo
            if (Distancia > DistanciaMinima)
            {

                MovimientoOrugas();

            }

            //Se comprueba si la distancia es menor o igual a la distancia mínima, en éste caso el tanque podrá atacar, pero debe quedarse quieto.
            if (Distancia <= DistanciaMinima)
            {
                //Se crea un nuevo vector con la posición del objetivo en el eje x y z pero el eje Y del enemigo, ésto es para evitar
                //que el enemigo se incline de maneras no deseadas dada la diferencia de tamaños.
                Vector3 PosicionTarget = new Vector3(Objetivo.position.x, this.transform.position.y, Objetivo.position.z);
                //Se le dice al enemigo que debe mirar a la posicion creada anteriormente.
                transform.LookAt(PosicionTarget);
                //Posteriormente se activa el ataque.
                PuedeAtacar = true;
            }

            else
            {
                //En caso de no cumplirse las condiciones el ataque no está permitido.
                PuedeAtacar = false;

            }

        }
    }
    //FINAL FUNCION MovimientoEnemigo

    //INICIO FUNCION MovimientoOrugas
    //Esta función controla el movimiento del enemigo y de las orugas del enemigo.
    //Como el enemigo solo se mueve hacia adelante sólo necesita un valor para el offset.
    public void MovimientoOrugas()
    {
        //Para el movimiento de las texturas se debe comprobar el tag del gameobject, para así animarla en el eje adecuado.
        float offset = Time.time * velocidadscrollorugas;

        //Si el tag es jefe se anima en el eje X
        if (gameObject.tag == "Jefe")
        { 

         orugas.material.SetTextureOffset("_MainTex", new Vector2(offset , 0 ));

        }

        //De lo contrario se anima en el eje Y
        else
        { 

            //Se genera el movimiento de las orugas
            orugas.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

        }

        //Se confirma que no esté en spawn ni girando antes de ejecutar el movimiento del tanque.
        if (!EstaEnSpawn)
        {
            if (!EstaGirando) { 
                //Se crea un nuevo vector con la posición del objetivo en el eje x y z pero el eje Y del enemigo, ésto es para evitar
                //que el enemigo se incline de maneras no deseadas dada la diferencia de tamaños.
                Vector3 PosicionTarget = new Vector3(Objetivo.position.x, this.transform.position.y, Objetivo.position.z);

                //Se crea una variable movimiento usada para mover el enemigo hacia el objetivo.
                float Movimiento = VelocidadEnemigo * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Objetivo.position, Movimiento);

                //Se le dice al enemigo que debe mirar a la posicion creada anteriormente.
                transform.LookAt(PosicionTarget);
            }
        }
    }
    //FINAL FUNCION MovimientoOrugas

    //INICIO FUNCION ATAQUE
    //Esta función controla el ataque del enemigo
    public void Ataque()
    {
        //Primero se confirma si el enemigo puede atacar
        if (PuedeAtacar)
        {
            //Se analiza según la cadencia si el enemigo puede disparar.
            if (Time.time > SiguienteDisparo)
            {

                SiguienteDisparo = Time.time + Cadencia;

                /*Se creará una instancia del objeto bala, que tomará la posición y rotación del emisor de balas.
               *Al cuerpo rígido de éste objeto se le asignará una fuerza hacia adelante y posteriormente se destruirá luego de 3 segundos
               * Se aclara que la destrucción de la bala por medio de ésta función se aplica sí y sólo sí la bala no se ha destruido anteriormente mediante una colisión*/
                GameObject ControladorBalas;
                ControladorBalas = Instantiate(Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;
                ControladorBalas.transform.Rotate(Vector3.left * 90);

                //Si no existe un audiosource se creará y se le asignara el audio correspondiente, luego se indicara que ya ha sido creado y éste componente se pasará al elemento
                //constante para poder editarlo en tiempo real, éste audiosource no se eliminará.
                if (!AudioSourceSonidoBalaCreado)
                {
                    AudioSource AudioSourceSonidoBala = gameObject.AddComponent<AudioSource>();
                    AudioSourceSonidoBala.clip = SonidoBala as AudioClip;
                    AudioSourceSonidoBalaCreado = true;
                    AudioSourceSonidoBalaConstante = AudioSourceSonidoBala;
                }

                //Se le agrega la fuerza de la bala al componente rígido de la bala.
                Rigidbody CuerpoRigidoTemporal;
                CuerpoRigidoTemporal = ControladorBalas.GetComponent<Rigidbody>();

                CuerpoRigidoTemporal.AddForce(transform.forward * FuerzaBala);

                //Codigo usado para modificar el audio en el inspector en tiempo real.
                AudioSourceSonidoBalaConstante.volume = VolumenSonidoBala;
                AudioSourceSonidoBalaConstante.Play();

                //Destruir la instancia de la bala luego de 3 segundos.
                Destroy(ControladorBalas, 3f);

            }


        }

    }
    //FINAL FUNCION ATAQUE

    //INICIO FUNCION MUERTE
    void Muerte()
    {
        //Si la vida del enemigo es = a 0, o menor que 0 el enemigo debe morir.
        if (SaludEnemigo <= 0)
        {
            //Se le suman los puntos del enemigo a la puntuación actual del jugador.
            Jugador.PuntuacionStatic += Puntos;
            
            /*Se instancia el sistema de particulas en la posición del enemigo, luego se reproduce
             * Éste objeto se destruye luego de que termine la animación.
             * El objeto (enemigo) se destruye*/

            ParticleSystem explosion = Instantiate(Destruccion, transform.position, Quaternion.identity) as ParticleSystem;
            explosion.Play();
            Destroy(explosion.gameObject, explosion.duration);
            Destroy(gameObject);

            //Se confirma que la puntuación sea diferente de 0; ésto es para saber que el jugador ya mató un enemigo y poder realizar
            //la resta necesaria.
            if (Jugador.PuntuacionStatic != 0) { 
               
            Enemigos.contadorenemigos -= 1;

                //Si el enemigo que ha perdido toda la vida es el objeto jefe
                //y ya se ha hablitado en su script, entonces se activa el canvas victoria y el juego se pausa.
             if (Jefe.esjefe)
                {


                    CanvasVictoria.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;

                }

            }

            //Si el jugador puede ganar poder, y el poder es < que 99 entonces cada enemigo muerto dará 20 puntos de poder.
            if (ganarpoder && Jugador.Poder < 99)
            {
                Jugador.Poder += 20;
                

          
            }
         



            }

        

    }
    //FINAL FUNCION MUERTE


    //INICIO FUNCION ON COLLISION
    void OnCollisionEnter(Collision collision)
    {
        //Se confirma si el objeto que colisionó fue Misil Jugador(Clone), el cual es el que se instancia cuando el jugador dispara.
        if (collision.gameObject.name == "Misil Jugador(Clone)")
        {
            //De ser así la vida del enemigo baja según el daño que hace la bala.
            SaludEnemigo -= Jugador.DañoBalaStatic;
            BarraDeVidaEnemigo.value = SaludEnemigo;
            

        }

        //Se confirma si el objeto que colisionó fue Minigun Jugador(Clone), el cual es el que se instancia cuando el jugador dispara.
        if (collision.gameObject.name == "Minigun Jugador(Clone)")
        {
            //De ser así la vida del enemigo baja según el daño que hace la bala.
            SaludEnemigo -= Jugador.DañoBala2Static;
            BarraDeVidaEnemigo.value = SaludEnemigo;
            

        }

        //Si el objeto jefe tiene colisión con el misil del jugador, el poder se aumentará en +2;
        if (gameObject.CompareTag("Jefe")) { 
        if (collision.gameObject.name == "Misil Jugador(Clone)")
        {
//De ser así la vida del enemigo baja según el daño que hace la bala.
            SaludEnemigo -= Jugador.DañoBalaStatic;
            BarraDeVidaEnemigo.value = SaludEnemigo;
                Jugador.Poder += 2;

            }
            //Si el objeto jefe tiene colisión con la minigun del jugador, el poder se aumentará en +1;
            if (collision.gameObject.name == "Minigun Jugador(Clone)")
            {
                //De ser así la vida del enemigo baja según el daño que hace la bala.
                SaludEnemigo -= Jugador.DañoBala2Static;
                BarraDeVidaEnemigo.value = SaludEnemigo;
                Jugador.Poder += 1;

            }
            


        }

    }
    //FINAL FUNCION ON COLLISION

    //INICIO FUNCION ON PARTICLE COLLISION
    //Es importante notar que para que la colision funcione, el elemento de partículas debe tener activada la opcion de colisión y enviar mensajes de colision.
    //El parametros de inicialización es el gameobject other, el cual se usa para poder comparar el tag del sistema de particulas y poder usar varios en caso de ser necesario.
    void OnParticleCollision(GameObject Other)
    {
        //Se compara si el objeto Other que es el que está colisionando tiene el tag lanzallamas, de ser así, se ejecuta la funcion.
        if (Other.gameObject.CompareTag("Lanzallamas")) { 
        SaludEnemigo -= Jugador.DañoLanzallamasStatic;
        BarraDeVidaEnemigo.value = SaludEnemigo;
        }
    }
    //FINAL FUNCION ON PARTICLE COLLISION

    //INICIO FUNCION ON TRIGGER EXIT
    //Esta función se usa para controlar si el enemigo ya salió de la zona de spawn.
    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Zona De Spawn"))
        {

            EstaEnSpawn = false;
            EstaGirando = true;
            StartCoroutine(CambiarEstaGirando(1.8f));

        }
    }
    //FINAL FUNCION ON TRIGGER EXIT

    //INICIO CORRUTINA ESTA GIRANDO
    //Esta corrutina se usa se usa para controlar si el enmigo ya salió de la zona de spawn y ya dejó de girar.
    IEnumerator CambiarEstaGirando(float time)
    {

        yield return new WaitForSeconds(time);
        EstaGirando = false;


    }
    //FINAL CORRUTINA ESTA GIRANDO

}
//FINAL CLASE ENEMIGOS