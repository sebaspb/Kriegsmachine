using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase se encarga de definir el comportamiento de las balas al momento de ser destruidas.
public class DestruirBala : MonoBehaviour {

    //variable pública para el sistema de particulas usado al momento de destruir la bala
    [Tooltip("Efecto de explosión para ésta bala")]
    public ParticleSystem SistemaParticulasBala;
    [Tooltip("Sonido que se usará cuando ésta bala sea destruida")]
    public AudioClip SonidoDestruirBala;
    [Range(0, 1)]
    [Tooltip("Volumen del sonido de la destrucción del misil del jugador")]
    public float VolumenSonidoDestruirBala;
    //En la siguiente variable se asigna la distancia máxima a la cual el audio comienza a desvanecerse, para ello el audiosource debe estar en 3d y en modo lineal.
    [Tooltip("Distancia máxima a a cual se escuchará éste sonido.")]
    [Range(0, 500)]
    public float DistanciaMaxima;
    //Audiosource usado para el sonido de la bala.
    [Tooltip("Audiosource que contiene el sonido de la destrucción de la bala")]
    public AudioSource AudioSourceDestruirBala;





// Update is called once per frame
    void Update () {
        //En update se controlan las características del audiosource, se hace aquí para poder editarlas en el inspector.
        AudioSourceDestruirBala.volume = VolumenSonidoDestruirBala;
        AudioSourceDestruirBala.clip = SonidoDestruirBala;
        AudioSourceDestruirBala.maxDistance = DistanciaMaxima;
    }

    void OnCollisionEnter(Collision colision)
    {
       
        //Cuando hay colisión, se instancia el audiosource y se reproduc en el lugar de impacto..
        AudioSource sonido = Instantiate(AudioSourceDestruirBala, transform.position, Quaternion.identity) as AudioSource;
        sonido.Play();


        //se instancia el sistema de particulas sin loop y se reproduce en el lugar de impacto.
        ParticleSystem explosion = Instantiate(SistemaParticulasBala, transform.position, Quaternion.identity) as ParticleSystem;
        explosion.loop = false;
        

        //se destruye el objeto explosión y el sonido luego de la duración del sistema de partículas.
        Destroy(explosion.gameObject, explosion.duration);
        Destroy(sonido.gameObject, explosion.duration);
        
        //Se destruye la bala.
        Destroy(gameObject);
       
    }
}
