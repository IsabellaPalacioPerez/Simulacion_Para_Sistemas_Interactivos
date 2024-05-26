using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiburon : MonoBehaviour
{
    private Rigidbody rb;

    // Rotar
    private bool isRotating = false;

    // Movimiento Angular
    public GameObject tiburon;
    public Transform posicionTiburon;
    private Transform posicionPresa;

    // Comer
    public string presaT = "pezbebe";
    public Vector3 direcction;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Cazar();
    }
    private void Cazar()
    {
        // Buscar objetos con el tag "pezbebe"
        GameObject[] pezbebes = GameObject.FindGameObjectsWithTag(presaT);

        if (pezbebes.Length > 1)
        {
            // Encontrar el objeto más cercano
            float minDistance = Mathf.Infinity;
            foreach (GameObject pezbebe in pezbebes)
            {
                float distanciaTP = Vector3.Distance(posicionTiburon.position, pezbebe.transform.position);
                if (distanciaTP < minDistance)
                {
                    minDistance = distanciaTP;
                    posicionPresa = pezbebe.transform;
                }
            }

            // Lógica de Caza
            float distancia = Vector3.Distance(posicionTiburon.position, posicionPresa.position);
            if (distancia <= 30f)
            {
                Vector3 direccionMov = posicionPresa.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direccionMov);
                transform.Rotate(new Vector3 (0, -180, 0));
                rb.MovePosition(transform.position + direccionMov.normalized * 50f * Time.deltaTime);
                if (distancia <= 6f) rb.MovePosition(transform.position + direccionMov.normalized * 80f * Time.deltaTime);
            }
            
            if (distancia <= 2)
            {
                Destroy(posicionPresa.gameObject);
            }
        }
        else
        {
            rb.MovePosition(transform.position - transform.forward * 50f * Time.deltaTime);
            InvokeRepeating("Rotar", 0, Random.Range(3f, 10f));
        }
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
}

