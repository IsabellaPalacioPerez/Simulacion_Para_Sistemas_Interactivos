using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMover : MonoBehaviour
{
 public float velocidadMovimiento = 10.0f; // Velocidad de movimiento de la cámara


void Update()
    {
        // Movimiento horizontal y vertical con las teclas
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoverDerecha();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoverIzquierda();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoverArriba();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoverAbajo();
        }

        // Zoom con la rueda del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scroll);
    }

    void MoverDerecha()
    {
        Vector3 movimiento = Vector3.right * velocidadMovimiento * Time.deltaTime;
        MoverConLimites(movimiento);
    }

    void MoverIzquierda()
    {
        Vector3 movimiento = Vector3.left * velocidadMovimiento * Time.deltaTime;
        MoverConLimites(movimiento);
    }

    void MoverArriba()
    {
        Vector3 movimiento = Vector3.up * velocidadMovimiento * Time.deltaTime;
        MoverConLimites(movimiento);
    }

    void MoverAbajo()
    {
        Vector3 movimiento = Vector3.down * velocidadMovimiento * Time.deltaTime;
        MoverConLimites(movimiento);
    }

    void Zoom(float scroll)
    {
        Vector3 newPosition = transform.position + transform.forward * scroll * 10f;
        newPosition.z = Mathf.Clamp(newPosition.z, -6, 20);
        transform.position = newPosition;
    }

    void MoverConLimites(Vector3 movimiento)
    {
        // Calcula la nueva posición de la cámara
        Vector3 nuevaPosicion = transform.position + movimiento;

        // Aplica los límites del área
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, -20, 20);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, -10, 10);

        // Actualiza la posición de la cámara
        transform.position = nuevaPosicion;
    }
}