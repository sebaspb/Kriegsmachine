using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{

	public AudioManager activadorAudio;

 void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Jugador")) {
			activadorAudio.activandoAudioSalud ();

		}
		 
	}
}


