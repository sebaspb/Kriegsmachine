using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se usa para mover la llave al siguiente piso en caso de que deba hacerse.
/// </summary>
public class MoverLlave : MonoBehaviour {

    //En caso de colisión con el objeto, se cambia la variable mover llave de la clase desactivar puertas.
    void OnTriggerEnter(Collider col)
    {

        Desactivarpuertas.moverllave = true;

    }
    }
