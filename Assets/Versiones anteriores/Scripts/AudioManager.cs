using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip SaludActiva;
	public AudioClip VenenoActivo;
	AudioSource reproductorAudio;

	public void activandoAudio(string nombreAudio)
	{
		string nombreCancion = nombreAudio;

		switch(nombreCancion)
			{
			  case "SaludActiva":
				reproductorAudio.PlayOneShot(SaludActiva);
				break;
			  case "VenenoActivo":
				reproductorAudio.PlayOneShot(VenenoActivo);
				break;
			  default:
				Debug.Log("El nombre es incorrecto");
				break;

			}

			Debug.Log("Activando el audio");
			}

	void Start ()
	{
		reproductorAudio = GetComponent<AudioSource> ();	
	
		for (int i = 0; i < 20; i++) {
			Debug.Log ("Hola grupo de la tarde");
			if (i == 5) {
				Debug.Log ("Encontré el número 5");
				continue;

			}
		}
	}
	void Update ()
	{
	}

	public void activandoAudioSalud ()
	{
		reproductorAudio.PlayOneShot(SaludActiva);
		Debug.Log("Activando audio");
			}
	public void activandoAudioVeneno ()
	{
		reproductorAudio.PlayOneShot(VenenoActivo);
		Debug.Log("Activando audio Veneno");
	}
}

					
    