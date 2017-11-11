using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugadorant : MonoBehaviour {

	//Inicializa el menu del jugador para todos los objetos que tengan asignada ésta clase.

	[Header("<OPCIONES DE MOVIMIENTO>")]
	[Tooltip("Velocidad con la cual se moverá el jugador hacia los lados, adelante y atras; valor por defecto 5")]
	public float VelocidadMovimiento = 5f;

	[Tooltip("Velocidad con la cual el jugador girará sobre si mismo; valor por defecto 100")]
	public float VelocidadRotacion = 100f;

	[Tooltip("Impulso con el cual saltará el jugador; 0 para desactivar el salto")]
	public float Impulso = 5f;

	[Tooltip("Comprueba constantemente si el jugador está en contacto con el piso")]
	public bool EstaEnElPiso = false;

	[Tooltip("Asigna el rigidbody del jugador que se usa para la función salto")]
	public Rigidbody CuerpoRigidoJugador;

	[Header("<OPCIONES DE SALUD Y BARRA DE VIDA>")]

	[Tooltip("Salud del jugador, por defecto 500")]
	public float SaludJugador = 500f;
	public static float SaludJugadorStatic;

	[Tooltip("Slider barra de vida jugador ")]
	public Slider BarraDeVida;
	public static Slider BarraDeVidaStatic;

	[Header("<OPCIONES DE DISPARO>")]
	[Tooltip("El prefab que se asignará como bala")]
	public GameObject Bala;

	[Tooltip("El objeto que se usará como emisor de balas")]
	public GameObject EmisorDeBalas;

	[Tooltip("Fuerza con la cual se disparará la bala")]
	public float FuerzaBala;

 
    public static float pisoactualstatic;
	// Use this for initialization
	void Start () {

		BarraDeVida.maxValue = SaludJugador;
		BarraDeVida.value = SaludJugador;
		SaludJugadorStatic = SaludJugador;
		BarraDeVidaStatic = BarraDeVida;
	}
	
	// Update is called once per frame
	void Update () {

		MovimientoJugador();
		DisparoJugador ();
	}

	void FixedUpdate () {

		SaltoJugador();

	}


	//Inicia la función movimiento del jugador
	public void MovimientoJugador()
	{
	
		float Movimiento = Input.GetAxis ("Vertical") * VelocidadMovimiento;
		Movimiento *= Time.deltaTime;
		transform.Translate (0, 0, Movimiento);

		float Rotacion = Input.GetAxis ("Horizontal") * VelocidadRotacion;
		Rotacion *= Time.deltaTime;
		transform.Rotate (0, Rotacion, 0);
	} 

	public void SaltoJugador()
	{

		CuerpoRigidoJugador = GetComponent<Rigidbody>();

		if (Input.GetButtonDown("Jump") && EstaEnElPiso == true)
		{

			CuerpoRigidoJugador.AddForce (0, Impulso, 0,ForceMode.Impulse);

		}
	}

	public void DisparoJugador ()
	{

		if (Input.GetButtonDown ("Fire1")) {

			GameObject ControladorBala;
			ControladorBala = Instantiate (Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;

			ControladorBala.transform.Rotate (Vector3.left * 90);

			Rigidbody CuerpoRigidoTemporal;
			CuerpoRigidoTemporal = ControladorBala.GetComponent<Rigidbody> ();

			CuerpoRigidoTemporal.AddForce (transform.forward * FuerzaBala);
		
			Destroy (ControladorBala, 3f);
		}

	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag ("piso1")) {


            pisoactualstatic = 1;
			Debug.Log ("piso actual " +1);

		}

        if (collision.collider.CompareTag("Piso2"))
        {


            pisoactualstatic = 2;
            Debug.Log("piso actual " + 2);

        }

        if (collision.collider.CompareTag("Piso3"))
        {


            pisoactualstatic = 3;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso4"))
        {


            pisoactualstatic = 4;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso5"))
        {


            pisoactualstatic = 5;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso6"))
        {


            pisoactualstatic = 6;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso7"))
        {


            pisoactualstatic = 7;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso8"))
        {


            pisoactualstatic = 8;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso9"))
        {


            pisoactualstatic = 9;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

        if (collision.collider.CompareTag("Piso10"))
        {


            pisoactualstatic = 10;
            Debug.Log("Tocando el piso =" + EstaEnElPiso);

        }

    }

	void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag ("Piso")) {


			EstaEnElPiso = false;
			Debug.Log ("Tocando el piso =" + EstaEnElPiso);
		}
	}

}
