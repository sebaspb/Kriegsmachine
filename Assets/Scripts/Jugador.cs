using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Esta clase se encarga de controlar todas las características del jugador
/// </summary>

//INICIO CLASE JUGADOR
public class Jugador : MonoBehaviour {

    /// <summary>
    /// Se crearán todas las variables privadas y las públicas que se verán reflejadas en el inspector; también se crearán variables estáticas.
    /// Se usarán HEADERS y TOOLTIPS y SPACES para organizar todo dentro del inspector de unity.
    /// Las opciones de formato como [space] y [range] se colocan antes del objeto que se quiere modificar.
    /// </summary>
    /// 

 
    [Header("<OPCIONES DE JUGADOR>")]
        [Space(10)]


        [Header("<OPCIONES DE MOVIMIENTO>")]
        [Tooltip("Velocidad con la cual se moverá el jugador hacia los lados, adelante y atras; valor por defecto 30")]
        public float VelocidadMovimiento = 30f;
       
        
        [Tooltip("Velocidad con la cual el jugador girará sobre si mismo; valor por defecto 100")]
        public float VelocidadRotacion = 100f;
        

        [Tooltip("Comprueba constantemente si el jugador está en contacto con el piso, valor por defecto true")]
        public bool EstaEnElPiso = true;
   

        [Tooltip("Impulso con el cual saltará el jugador; 0 para desactivar el salto, valor por defecto 5; 0 para desactivar el salto")]
        public float Impulso = 5f;
    
         
        [Tooltip("Asigna el rigidbody del jugador que se usa para la función salto")]
        public Rigidbody CuerpoRigidoJugador;
        

        [Tooltip("Asigna el renderer correspondiente a las orugas del jugador")]
        public Renderer OrugasJugador;
        

        [Tooltip("Asigna la velocidad con la cual se moverán las orugas del jugador, valor por defecto 2")]
        public float VelocidadOrugasJugador = 2F;
        

        [Space(10)]
        [Header("<OPCIONES DE SALUD Y BARRA DE VIDA>")]
        [Tooltip("Salud del jugador, por defecto 500")]
        public float SaludJugador = 500f;
        public static float SaludJugadorStatic;

        [Tooltip("Slider barra de vida jugador ")]
        public Slider BarraDeVida;
        public static Slider BarraDeVidaStatic;
        [Tooltip("Variable interna para controlar que la funcion gameover solo se ejecute una vez")]
        bool derrotado = false;

        [Space(10)]
        [Header("<OPCIONES DE DISPARO>")]
        [Header("Cañon")]        
        [Tooltip("El prefab que se asignará como bala")]
        public GameObject Bala;
        
        [Tooltip("El objeto que se usará como emisor de balas")]
        public GameObject EmisorDeBalas;
        
        [Tooltip("La fuerza de ésta bala")]
        public float FuerzaBala;

        [Tooltip("El daño que causa ésta bala en los enemigos")]
        public float DañoBala;
        public static float DañoBalaStatic;

        [Tooltip("Sonido del disparo del cañon")]
        public AudioClip SonidoCañon;
        //El elemento [range] se usa para mostrar el control de la siguiente variable como un slider con un número mínimo y máximo.
        [Range(0, 1)]
        [Tooltip("Volumen del sonido del cañón")]
        public float VolumenSonidoCañon;

        //esta variable es interna y es para controlar si la bala del cañón existe y de ser así denegar el disparo.
        public static bool BalaCañonExiste = false;

        [Header("Minigun")]
        [Tooltip("El prefab que se asignará como bala")]
        public GameObject Bala2;
        
        [Tooltip("El objeto que se usará como emisor de balas")]
        public GameObject EmisorDeBalas2;
        
        [Tooltip("La fuerza de ésta bala")]
        public float FuerzaBala2;

        [Tooltip("El daño que causa ésta bala en los enemigos")]
        public float DañoBala2;
        public static float DañoBala2Static;


        [Tooltip("El valor que se usará para la cadencia de disparo de ésta bala, valor por defecto 0.05")]
        public float FireDelta = 0.05f;

        //Las dos variables que siguen son privadas y se usarán para calcular internamente el siguiente disparo de la minigun del jugador.
        private float Cadencia = 0.5F;
        private float MiTiempo = 0.0F;
        [Tooltip("Sonido del disparo del cañon")]
        public AudioClip SonidoMinigun;
        //Para poder controlar el audioclip anterior se usara un audiosource privado constante que se asignará más adelante.
        private AudioSource AudioSourceConstanteSonidoMinigun;
        //El siguiente bool se usa para impedir la creación de más de un audiosource al momento de llamar el código
        private bool AudioSourceSonidoMinigunCreado = false;
        [Tooltip("Volumen del sonido de la minigun")]
        [Range(0, 1)]
        public float VolumenSonidoMinigun;


        [Header("Lanzallamas")]
        [Tooltip("El sistema de partículas que usará el lanzallamas")]
        public ParticleSystem Lanzallamas;
        [Tooltip("El daño que causa éste elemento en los enemigos")]
        //se le asignará un rango mínimo de 1 y máximo de 10 a éste elemento
        [Range(1, 10)]
        public float DañoLanzallamas;
        public static float DañoLanzallamasStatic;

        [Tooltip("Sonido del disparo del cañon")]
        public AudioClip SonidoLanzallamas;
        private AudioSource AudioSourceConstanteLanzallamas;
        //El siguiente bool se usa para impedir la creación de más de un audiosource al momento de llamar el código
        private bool AudioSourceSonidoLanzallamasCreado = false;
        [Tooltip("Volumen del sonido del lanzallamas")]
        [Range(0, 1)]
        public float VolumenSonidoLanzallamas;

        [Tooltip("Slider barra de poder ")]
        public Slider BarraDePoder;
        public static Slider BarraDePoderStatic;
        //Variable interna con el poder que inicia el jugador, por defecto es 0.

        public static float Poder = 0;
    
        //Variable estática que nos informa si el jugador puede usar el lanzallamas o no
        public static bool PuedeUsarLanzallamas = false;


        [Space(10)]
        [Header("<OPCIONES DE PUNTUACIÓN>")]
        [Tooltip("Valor inicial de la puntuación, valor por defecto 0")]
        public float Puntuacion = 0;
        public static float PuntuacionStatic;
        [Tooltip("El texto que mostrará la puntuación actual en la pantalla.")]
        public Transform TextoPuntuacion;      
        public static Transform TextoPuntuacionStatic;
        [Tooltip("Variable que guarda la puntuación más alta registrada.")]
        public static int PuntuacionMasAlta;

        [Space(10)]
        [Header("<OPCIONES DE SONIDO>")]
        [Tooltip("Sonido del Inicio del motor del tanque")]
        public AudioClip InicioMotor;
        [Tooltip("Sonido en reposo del motor del tanque")]
        public AudioClip ReposoMotor;
        //Para poder controlar el audioclip anterior se usara un audiosource privado constante que se asignará más adelante.
        private AudioSource AudioSourceConstanteReposoMotor;
        //El siguiente bool se usa para impedir la creación de más de un audiosource al momento de llamar el código
        private bool AudioSourceReposoMotorCreado = false;
        [Tooltip("Volumen del sonido del reposo del motor")]
        [Range(0, 1)]
        public float VolumenReposoMotor;

        //La siguiente variable es privada, se usará para saber si el motor del tanque se está iniciando, así el jugador no puede moverse durante éste lapso de tiempo.
        private bool EstaIniciandoElMotor = true;

        //Objeto que se usará como Pantalla de GameOver
        public GameObject CanvasGameover;
        //Sistema de partículas usado en caso de muerte
        public ParticleSystem Destruccion;
        //Audiosource que tiene la música de fondo.
        public AudioSource Musica;

    //INICIO DE LA FUNCION START
    // Start sólo se ejecuta una vez.
    void Start ()
        {
        //La siguiente variable se usa para que el jugador se pueda mover (se usa en caso de que se de click en el botón jugar o volver a jugar).
        CanvasPantallaFinal.Termino = false;
       
        //Se le indica al listener que debe ignorar el volumen de la música, ésto se explica mejor en la clase
        //Interfaz Menu.
        Musica.ignoreListenerVolume = true;
          
        //Se hace que la musica sea permamente.
        DontDestroyOnLoad(Musica);

        

            //Se asignarán a la barra de vida los valores correspondientes asignados en el inspector.
            BarraDeVida.maxValue = SaludJugador;
            BarraDeVida.value = SaludJugador;
            BarraDeVidaStatic = BarraDeVida;

            //Se asignarán a la barra de poder los valores correspondientes asignados
            BarraDePoder.maxValue = 100;
            BarraDePoder.value = Poder;
            BarraDePoderStatic = BarraDePoder;
            // Se inicializarán las variables estáticas con el valor asignado en el inspector.
            SaludJugadorStatic = SaludJugador;
            PuntuacionStatic = Puntuacion;
            

            //Se llama la función IniciarMotor;
            //Descomentar la siguiente linea para iniciar la funcion iniciar motor, recordar que también se debe modificar la linea que asigna la variable en el update.
            //IniciarMotor();

        }
        //FINAL DE LA FUNCION START

        //INICIO DE LA FUNCION UPDATE
        // Update se llama una vez por cuadro
        void Update ()
        {

        print(CanvasPantallaFinal.Termino);

            //Se ajusta el valor actual de la barra de poder.
            BarraDePoder.value = Poder;

            //Si el poder es = a 0 se debe activar el ganar poder y desactivar el lanzallamas
            if (BarraDePoderStatic.value == 0)
            {
                Enemigos.ganarpoder = true;
                PuedeUsarLanzallamas = false;
            }

            //Si el poder es > 98 se debe desactivar el ganar poder y sactivar el lanzallamas
            //El 98 es por que al ser una funcion en update el número siempre dá con decimales 99.8878912 por ejemplo.

            if (BarraDePoderStatic.value > 98)
            {
                Enemigos.ganarpoder = false;
                PuedeUsarLanzallamas = true;
            }
        
           // BarraDePoderStatic.value = BarraDePoder.value;

            //Se ajsuta el volumen de la música al ajustado en la interfaz.
            Musica.volume = InterfazMenu.VolumenMusica;
        

            //Se inicializan algunas variables estáticas en el update para poderlas modificar libremente en el inspector en tiempo real.
            DañoBalaStatic = DañoBala;
            DañoBala2Static = DañoBala2;
            DañoLanzallamasStatic = DañoLanzallamas;

            //Se inicia la funcion reposo motor
            FuncionReposoMotor();

            //comentar la siguiente linea si la función iniciar motor se ha activado en la función start
            EstaIniciandoElMotor = false;
        
            //Inicialmente se comprueba si el motor NO se está iniciando; en caso de que sea así se llamarán las funciones que asignan la interactividad al jugador.  
            if (!EstaIniciandoElMotor)

            {

                //Si la pantalla termino no está activada se activan todas las funciones.
                if (!CanvasPantallaFinal.Termino)
                { 
                        MovimientoJugador();
                        DisparoJugador();
                        ActualizarPuntuacion();
                }

                //Se inicia la funcion Gameover.
                GameOver();
            }
        }
        //FINAL DE LA FUNCION UPDATE

        //INICIO DE LA FUNCION INICIAR MOTOR
        public void IniciarMotor()
        {
            
            //Se iniciará creando un nuevo AudioSource, al cual se le asignará el AudioClip correspondiente seleccionado en el inspector; luego se reproducirá este AudioSource.
            //El Audiosource creado se destruirá después de la duración del AudioClip
            AudioSource AudioSourceInicioMotor = gameObject.AddComponent<AudioSource>();
            AudioSourceInicioMotor.clip = InicioMotor as AudioClip;
            AudioSourceInicioMotor.Play();
            Destroy(AudioSourceInicioMotor, AudioSourceInicioMotor.clip.length);
            
            //Se inicia la corutina que cambia el estado de la variable EstaIniciandoMotor, la cual se ejecutará luego de la duración del AudioClip anterior.
            StartCoroutine(CambiarEstaIniciandoMotor(AudioSourceInicioMotor.clip.length));

        }
        //FINAL DE LA FUNCION INICIAR MOTOR

        //INICIO CORRUTINA CambiarEstaIniciandoMotor
        //Esta corrutina tiene como única función informar el momento en el cual el sonido de inicio de motor a dejado de reproducirse, una vez finalizada
        //Éste cambio desencadenará el inicio de la interactividad del jugador.
        IEnumerator CambiarEstaIniciandoMotor(float Time)
            {

                yield return new WaitForSeconds(Time);
                EstaIniciandoElMotor = false;

            }
        //FINAL CORRUTINA CambiarEstaIniciandoMotor 

        //INICIO FUNCION REPOSO MOTOR
        //Ésta función se encarga de controlar el estado de reposo de motor y el sonido asignado a él.
        public void FuncionReposoMotor()
        {
            //Se revisa que el audiosource no exista
            if (!AudioSourceReposoMotorCreado)
            { 
                //Aquí se asignará el sonido del motor en reposo
                //Se creará un AudioSource, al cual se le asignará el AudioClip correspondiente seleccionado en el inspector; luego se reproducirá este AudioSource.
                //Éste AudioSource, no se destruirá.
                AudioSource AudioSourceReposoMotor = gameObject.AddComponent<AudioSource>();
                AudioSourceReposoMotor.clip = ReposoMotor as AudioClip;
        
                //una vez creado se cambia la variable que controla la existencia del audiosource
                AudioSourceReposoMotorCreado = true;
                
                //Se revisa que NO se esté reproduciendo; y en caso afirmativo se reproduce
                if (!AudioSourceReposoMotor.isPlaying)
                { 

                    AudioSourceReposoMotor.Play();

                //El audiosource creado anteriormente es exlusivo de éste condicional, para poderlo modificar desde el inspector en tiempo real;
                //se debe convertir a un audisource diferente y extraer el clip de audio asignado.
                //Ésto se hace asignando ese audio source a una variable privada que sea llamada luego del condicional de si existe o no.
                    AudioSourceConstanteReposoMotor = AudioSourceReposoMotor;
    
                }

            }

                //Se asigna el volumen correspondiente al audiosource en el inspector y se le asigna el loop al audio.
                AudioSourceConstanteReposoMotor.loop = true;
                AudioSourceConstanteReposoMotor.volume = VolumenReposoMotor;
        
    }
            //FINAL FUNCION REPOSO MOTOR



    //INICIO FUNCIÓN MOVIMIENTOJUGADOR
    public void MovimientoJugador()
        {
            /*En ésta función se revisarán los ejes verticales y horizontales del input
             * dependiendo de su valor se asignará un movimiento de traslación hacia adelante y atrás
             * o el jugador girará sobre su propio eje*/

            float Movimiento = Input.GetAxis("Vertical") * VelocidadMovimiento;
            Movimiento *= Time.deltaTime;
            transform.Translate(0, 0, Movimiento);

            float Rotacion = Input.GetAxis("Horizontal") * VelocidadRotacion;
            Rotacion *= Time.deltaTime;
            transform.Rotate(0, Rotacion, 0);
            
            //Se llama la función MovimientoOrugasJugador
            MovimientoOrugasJugador();

        }
        //FINAL FUNCIÓN MOVIMIENTOJUGADOR

        //INICIO FUNCIÓN MOVIMIENTOORUGASJUGADOR
        /*Esta función tiene como propósito desplazar la textura asignada a las orugas del tanque del jugador hacia el lado correspondiente mientras se está en movimiento.
         * Para ello se comprobará si el movimiento es hacia adelante o hacia atrás y según sea el caso se le asignará el valor del movimiento a la textura del componente orugasjugador*/
        public void MovimientoOrugasJugador()
            {
            float Offset = Time.time * VelocidadOrugasJugador;

            if (Input.GetAxis("Vertical") > 0)
            {

                OrugasJugador.material.SetTextureOffset("_MainTex", new Vector2(0, Offset));

            }

            if (Input.GetAxis("Vertical") < 0)
            {

                OrugasJugador.material.SetTextureOffset("_MainTex", new Vector2(0, -Offset));

            }

        }
        //FINAL FUNCIÓN MOVIMIENTOORUGASJUGADOR

        //INICIO FUNCION DISPARO JUGADOR
        public void DisparoJugador()
        {
        //Primero se revisa si el jugador está activo, de ser así puede atacar, ésto se usa para no poder atacar al jefe durante
        //su entrada.
        if (Jefe.jugadoractivo) { 
        //En caso de usar el click izquierdo
        if (Input.GetButtonDown("Fire1"))
        {
           

            //Se comprueba que la bala del cañon no exista
            if (!BalaCañonExiste) { 

                /*Se creará una instancia del objeto bala, que tomará la posición y rotación del emisor de balas.
                 *Al cuerpo rígido de éste objeto se le asignará una fuerza hacia adelante y posteriormente se destruirá luego de 3 segundos
                 *Se aclara que la destrucción de la bala por medio de ésta función se aplica sí y sólo sí la bala no se ha destruido anteriormente mediante una colisión*/

                GameObject ControladorBala;
                ControladorBala = Instantiate(Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;
                ControladorBala.transform.Rotate(Vector3.left * 90);
                BalaCañonExiste = true;
                Rigidbody CuerpoRigidoTemporal;
                CuerpoRigidoTemporal = ControladorBala.GetComponent<Rigidbody>();
                CuerpoRigidoTemporal.AddForce(transform.forward * FuerzaBala);
                //Se llama la corrutina cambiar existencia bala cañon
                StartCoroutine(CambiarExistenciaBalaCañon(2));
                Destroy(ControladorBala, 3f);

                //Aquí se asignará el sonido del disparo del cañón
                //Se creará un AudioSource, al cual se le asignará el AudioClip correspondiente seleccionado en el inspector; luego se reproducirá este AudioSource.
                //Éste AudioSource, se destruirá de manera automática una vez que el audioclip correspondiente ha finalizado.
                AudioSource AudioSourceSonidoCañon = gameObject.AddComponent<AudioSource>();
                AudioSourceSonidoCañon.clip = SonidoCañon as AudioClip;
                AudioSourceSonidoCañon.volume = VolumenSonidoCañon;
                AudioSourceSonidoCañon.Play();
                Destroy(AudioSourceSonidoCañon, SonidoCañon.length);
            }
        }
          

            //La variable Mitiempo se usa únicamente para el cálculo interno del siguiente disparo de la minigun
            MiTiempo += Time.deltaTime;
            
            //En caso de dar click con el botón derecho y que se cumpla la condicion para el siguiente disparo
            if (Input.GetButton("Fire2") && MiTiempo > Cadencia)
            {
            
            //Se confirma que el audiosource correspondiente NO esté creado
            if (!AudioSourceSonidoMinigunCreado)
                { 
                    //si NO está creado se procede a crearlo y asignarle el sonido correspondiente.
                    AudioSource AudioSourceSonidoMinigun = gameObject.AddComponent<AudioSource>();
                    AudioSourceSonidoMinigun.clip = SonidoMinigun as AudioClip;

                    //Se le asigna el audiosource anterior al audiosource estático y privado creado anteriormente
                    AudioSourceConstanteSonidoMinigun = AudioSourceSonidoMinigun;
                
                    //se cambia el bool para indicar que el audiosource ya se ha creado y no crear más.
                    AudioSourceSonidoMinigunCreado = true;
                }

            //se le asigna el volumen al audiosource debe estar fuera del condicinal para editarlo en el inspector constante.
            AudioSourceConstanteSonidoMinigun.volume = VolumenSonidoMinigun;
                      
            //Se calcula la cadencia, la cual depende exclusivamente del valor FireDelta que se asigna dentro del inspector.
            Cadencia = MiTiempo + FireDelta;


            /*Se creará una instancia del objeto bala2, que tomará la posición y rotación del emisor de balas2.
            *Al cuerpo rígido de éste objeto se le asignará una fuerza hacia adelante y posteriormente se destruirá luego de 2 segundos
            * Se aclara que la destrucción de la bala por medio de ésta función se aplica sí y sólo sí la bala no se ha destruido anteriormente mediante una colisión*/
                
            GameObject ControladorBala2;
            ControladorBala2 = Instantiate(Bala2, EmisorDeBalas2.transform.position, EmisorDeBalas2.transform.rotation) as GameObject;
            ControladorBala2.transform.Rotate(Vector3.left * 90);
                
            Rigidbody CuerpoRigidoTemporal2;
            CuerpoRigidoTemporal2 = ControladorBala2.GetComponent<Rigidbody>();
            CuerpoRigidoTemporal2.AddForce(transform.forward * FuerzaBala);

            Destroy(ControladorBala2, 2f);
                
            //Una vez creada la bala se reproducirá el sonido de la minigun siempre y cuando no se esté reproduciendo ya
           
            if (!AudioSourceConstanteSonidoMinigun.isPlaying)
            {

                AudioSourceConstanteSonidoMinigun.Play();

            }

            //Se resetea la variable cadencia y mi tiempo; y se espera al siguiente cálculo interno.
            Cadencia = Cadencia - MiTiempo;
                MiTiempo = 0.0f;
          

             
            }

            //Se controla el momento en el cual se deja de dar click en el botón derecho del mouse para detener el sonido de la minigun.
            if (Input.GetButtonUp("Fire2"))
            {

                AudioSourceConstanteSonidoMinigun.Stop();

            }

            //En caso de dar click con el Scroll
            if (Input.GetButton("Fire3"))
            {
         
           
            //Si el poder es <= 0 el lanzallamas debe detenerse; se debe cancelar el uso del lanzallamas y se llama a la corutina
            //que detiene su sonido.
            if (Poder <= 0)
            {
                Lanzallamas.Stop();
                PuedeUsarLanzallamas = false;
                StartCoroutine(DetenerSonidoLanzallamas(1.5f));
            }

            //Si puede usar el lanzallamas se disminuirá en 0.4f.
            if (PuedeUsarLanzallamas)
            {
                Poder = Poder - 0.4f;

                //Se confirma que el audiosource correspondiente NO esté creado
                if (!AudioSourceSonidoLanzallamasCreado)
                {
                    //Aquí se asignará el sonido del lanzallamas
                    //Se creará un AudioSource, al cual se le asignará el AudioClip correspondiente seleccionado en el inspector; luego se reproducirá este AudioSource.
                    //Éste AudioSource, no se destruirá
                    AudioSource AudioSourceSonidoLanzallamas = gameObject.AddComponent<AudioSource>();
                    AudioSourceSonidoLanzallamas.clip = SonidoLanzallamas as AudioClip;
                    AudioSourceSonidoLanzallamasCreado = true;
                    AudioSourceSonidoLanzallamas.Play();
                    AudioSourceConstanteLanzallamas = AudioSourceSonidoLanzallamas;

                }
                //se le asigna el volumen al audiosource debe estar fuera del condicinal para editarlo en el inspector constante.
                AudioSourceConstanteLanzallamas.volume = VolumenSonidoLanzallamas;

                //Se inicia el sistema de particulas del lanzallamas
                Lanzallamas.Play();

                //Se comprueba que el sonido del lanzallamas no se esté reproduciendo y de ser así se inicia.
                if (!AudioSourceConstanteLanzallamas.isPlaying)
                {
                    AudioSourceConstanteLanzallamas.Play();
                }
            }
            }   

            //En caso de dejar de dar click con el Scroll
            if (Input.GetButtonUp("Fire3"))
            {
                //Se detiene el sistema de particulas del lanzallamas
                Lanzallamas.Stop();
                //Se llama la corutina que detiene el sonido del lanzallamas.
                StartCoroutine(DetenerSonidoLanzallamas(1.5f));
           
             }

        }
    }
    //FINAL FUNCION DISPARO JUGADOR

    //INICIO CORUTINA CambiarExistenciaBalaCañon
    //Esta corrutina se usa para cambiar la existencia de la bala del cañón y poder disparar de nuevo cuando la bala se ha destruido.
    IEnumerator CambiarExistenciaBalaCañon(float time)
    {

        yield return new WaitForSeconds(time);
        BalaCañonExiste = false;

    }
    //FINAL CORUTINA CambiarExistenciaBalaCañon

    //INICIO CORUTINA DETENER SONIDO LANZALLAMAS
    //Esta corrutina es para detener el sonido del lanzallamas una vez se desaparece el fuego del escenario.
    IEnumerator DetenerSonidoLanzallamas(float time)
    {

        yield return new WaitForSeconds(time);
        AudioSourceConstanteLanzallamas.Stop();

    }
    //FINAL CORUTINA DETENER SONIDO LANZALLAMAS

    

    //INICIO FUNCION ACTUALIZAR PUNTUACIÓN
    public void ActualizarPuntuacion()

            {
            //Inicialmente se toma el componente texto del texto puntuación y se le dice que sera igual al contenido de la variable estática puntuación convertido en String.
            TextoPuntuacion.GetComponent<Text>().text = PuntuacionStatic.ToString();

            //Se creará una nueva variable interna, la cual será igual a la variable guardada en playerprefs "PuntuacionDelJugador";
            float PuntuacionDelJugador;
            PuntuacionDelJugador = PlayerPrefs.GetFloat("PuntuacionDelJugador");
            print("EL RECORD ACTUAL ES DE: "+ PuntuacionDelJugador);


            /*Se revisará si la puntuación actual es mayor a la puntuación guardada en playerprefs
             * En caso de que así sea, la variable de playerprefs se sobrescribirá con el valor actual de la puntuación 
             * y quedará registrada como la puntuación más alta; hacerlo de ésta manera garantiza que la puntuación más alta no se reinicia,
             * cada vez que el jeugo se ejecuta*/
            if (PuntuacionStatic > PuntuacionDelJugador)

            {

                PlayerPrefs.SetFloat("PuntuacionDelJugador", PuntuacionStatic);
               // print("HAS REGISTRADO UN NUEVO RECORD");
                

            }
        
        }

    //Funcion GameOver
    void GameOver()
    {
        //Si la salud del jugador es = o menor que 0 quiere decir que ha muerto.
        

        if (SaludJugadorStatic <= 0)
        {
            //La siguiente variable se usa para que el jugador no se pueda mover
            CanvasPantallaFinal.Termino = true;
            if (!derrotado){ 
            //Se instancia el sistema de particulas correspondiente en la posición y rotacion del jugador y se reproduce
            ParticleSystem explosion = Instantiate(Destruccion, transform.position, Quaternion.identity) as ParticleSystem;
            print("hola");
            explosion.tag="particula";
            explosion.loop = false;
            explosion.Play();
                
            //Las particulas se detruyen luego de la duracion de las mismas.
            Destroy(explosion.gameObject, explosion.duration);
            }
            //Se informa que el juego terminó y debe llamarse la pantalla final.
            
            //Se llama la corutina gameover luego de 3 segundos.
            StartCoroutine(MenuGameOver(3));

        }


    }


    IEnumerator MenuGameOver(float time)
    {
        //se informa que se debe activar el canvas game over y el juego debe pausarse.
        yield return new WaitForSeconds(time);
        derrotado = true;
        //Se crea un array para controlar la destruccion de las particulas de la derrota.
        GameObject[] particulas = GameObject.FindGameObjectsWithTag("particula");
        foreach (GameObject particula in particulas)
            Destroy(particula.gameObject);
        CanvasGameover.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }


    //FINAL FUNCION ACTUALIZAR PUNTUACIÓN


    //INICIO FUNCION ON COLLISION
    //void OnCollisionEnter(Collision collisionbala)
    //{
    //    //Se revida que la colision sea con la bala del enemigo
    //    if (collisionbala.gameObject.name == "Misil Enemigo(Clone)")
    //    {

    //        SaludJugadorStatic -= Enemigos.DañoCausadoStatic;
    //        BarraDeVida.value = SaludJugadorStatic;

    //        //if (!impactobala.isPlaying)
    //        //{
    //        //    impactobala.Play();
    //        //}

           


    //    }
    //}
    //FINAL FUNCION ON COLLISION
}
//FINAL CLASE JUGADOR
