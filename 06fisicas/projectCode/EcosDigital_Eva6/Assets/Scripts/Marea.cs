using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marea : MonoBehaviour
{
    public float amplitud = 0.50f; 
    public float velocidad = 1.0f; 
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {        
        float desplazamientoHorizontal = amplitud * Mathf.Sin(velocidad * Time.time);               
        Vector3 nuevaPosicion = posicionInicial + new Vector3(desplazamientoHorizontal, 0, 0);
        transform.position = nuevaPosicion;
    }
}
