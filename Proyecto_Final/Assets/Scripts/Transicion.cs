using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour {

    private float tiempoStart = 0.0f;
    private float tiempoFinal = 16.0f;

    void Update () {
        tiempoStart += Time.deltaTime;
        if (tiempoStart >= tiempoFinal)
        {
            Application.LoadLevel("Juego");
        }
    }
}
