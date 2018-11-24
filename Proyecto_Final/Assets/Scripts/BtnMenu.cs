using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMenu : MonoBehaviour {



    private float tiempoStart = 0.0f;
    private float tiempoFinal = 15.0f;

    void Update()
    {
        tiempoStart += Time.deltaTime;
        if (tiempoStart >= tiempoFinal)
        {
            jugar();
        }
    }

   public void jugar()
    {
        Application.LoadLevel("Introduccion");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void creditos()
    {
        Application.LoadLevel("creditos");
    }
}
