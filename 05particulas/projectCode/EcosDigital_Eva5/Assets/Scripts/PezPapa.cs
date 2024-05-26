using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezPapa : MonoBehaviour
{
    private Rigidbody rb;
    public Transform posicionPez;
    public Transform posicionArea;

    // Rotar
    private bool isRotating = false;
      

    //Atracción
    public GameObject padre2;
    public GameObject hijo;
    public string comida = "pezbebe";



    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        InvokeRepeating("Atraccion", 3f, Random.Range(3f, 4f));
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.H)) Atraccion();
        if (Input.GetKey(KeyCode.H)) Atraccion();
        Nadar();
        float distanciaLejos = Vector3.Distance(posicionPez.position, posicionArea.transform.position);
        if (distanciaLejos > 30)
        {
            Vector3 direccionMov = posicionArea.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direccionMov);
            posicionPez.Rotate(new Vector3(0, 180, 0));
        }                 
    }
    private void Nadar()
    {
        rb.MovePosition(transform.position - transform.forward * 50f * Time.deltaTime);
        InvokeRepeating("Rotar", 0, Random.Range(0.5f, 1.5f));
    }
    private void Rotar()
    {
        if (!isRotating)
        {
            if (transform.rotation.x < 50 || transform.rotation.x > -50 || transform.rotation.z < 60 || transform.rotation.z > -60)
            {
                Vector3 direccion = Vector3.zero;
                int x = Random.Range(0, 5);
                switch (x)
                {
                    case 0:
                        direccion = Vector3.right;
                        break;
                    case 1:
                        direccion = Vector3.up;
                        break;
                    case 2:
                        direccion = Vector3.forward;
                        break;
                    case 3:
                        direccion = Vector3.left;
                        break;
                    case 4:
                        direccion = Vector3.down;
                        break;
                    case 5:
                        direccion = Vector3.back;
                        break;
                }
                rb.AddTorque(direccion * 1f, ForceMode.Impulse);
                isRotating = true;
                Invoke("PararRotar", Random.Range(0.5f, 1f));
            }
        }
    }
    private void PararRotar()
    {
        rb.angularVelocity = Vector3.zero;
        isRotating = false;
    }
    public void Atraccion()
    {
        if (padre2 != null)
        {
            Vector3 attractionDirection = padre2.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(attractionDirection);
            posicionPez.Rotate(new Vector3(0, 180, 0));

            float distanciaAtraccion = Vector3.Distance(posicionPez.position, padre2.transform.position);
            if (distanciaAtraccion <= 2.2f)
            {
                GameObject[] enemigos = GameObject.FindGameObjectsWithTag("pezbebe");
                int cantidadEnemigos = enemigos.Length;
                if (cantidadEnemigos < 50)
                {
                    GameObject nuevoHijo = Instantiate(hijo, transform.position, Quaternion.identity);
                }                           
            }           
        }
    }
}
