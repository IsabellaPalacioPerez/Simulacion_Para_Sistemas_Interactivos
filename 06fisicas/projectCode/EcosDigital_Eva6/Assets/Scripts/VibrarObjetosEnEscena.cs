using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VibrarObjetosEnEscena : MonoBehaviour
{
    public float velocidadMovimiento = 1.0f;
    public float duracionMovimiento = 5.0f;
    public float amplitudVibracion = 1f;
    private float timer = 0.0f;
    private float waitTime = 5f;

    public Transform posicionBoton;
    private bool movimientoActivo = false;
    private float tiempoInicioMovimiento;

    void Update()
    {
        float distanciaBoton = Vector3.Distance(transform.position, posicionBoton.transform.position);      
        if (distanciaBoton <= 5)
        {
            Debug.Log("Entro");
            movimientoActivo=true;
            timer += Time.deltaTime;
        }
        if (movimientoActivo)
        {
            Rigidbody[] rigibodies = FindObjectsOfType<Rigidbody>();

            foreach (Rigidbody rb in rigibodies)
            {
                if (rb.CompareTag("BotonSismo")) continue;
                Vector3 randomVibration = UnityEngine.Random.insideUnitSphere * amplitudVibracion;
                rb.AddForce(randomVibration, ForceMode.Impulse); 
            }
            if (timer >= waitTime)
            {
                movimientoActivo = false;
                ResetVelocity();
                timer -= waitTime;
            }
        }
    }
    void ResetVelocity()
    {
        Rigidbody[] rigibodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in rigibodies)
        {
            if (!rb.CompareTag("BotonSismo"))
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
