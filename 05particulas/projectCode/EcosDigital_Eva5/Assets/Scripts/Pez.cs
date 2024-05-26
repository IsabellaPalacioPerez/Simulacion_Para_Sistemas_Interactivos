using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pez : MonoBehaviour
{
    private Rigidbody rb;

    // Movimiento Angular
    public Transform posicionPez;
    private Transform posicionComida;
    private Vector3 axis = Vector3.up;
    bool comiendo = true;

    // Comer
    public string comida = "";
    public Vector3 direcction;

    public void Start()
    {        
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("SeleccionComida", 0f, Random.Range(7f, 15f));
    }

    public void Update()
    {
        movimientoAgular();
    }
    private void SeleccionComida()
    {
        int valor = Random.Range(1, 5);
        if (valor == 1) comida = "alga";
        if (valor == 2) comida = "alga1";
        if (valor == 3) comida = "alga2";
        if (valor == 4) comida = "alga3";
    }
    private void movimientoAgular()
    {
        // Buscar objetos con el tag "pezbebe"
        GameObject[] comidas = GameObject.FindGameObjectsWithTag(comida);

        if (comidas.Length > 0)
        {
            // Encontrar el objeto más cercano
            float minDistance = Mathf.Infinity;
            foreach (GameObject comida in comidas)
            {
                float distanciaPC = Vector3.Distance(posicionPez.position, comida.transform.position);
                if (distanciaPC < minDistance)
                {
                    minDistance = distanciaPC;
                    posicionComida = comida.transform;
                }
            }

            // Movimiento Angular y Comer
            float distancia = Vector3.Distance(posicionPez.position, posicionComida.position);
            if (distancia >= 1f)
            {
                Vector3 direccionMov = posicionComida.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direccionMov);
                rb.MovePosition(transform.position + direccionMov.normalized * 30f * Time.deltaTime);
                comiendo = false;
            }
            if (distancia <= 1f)
            {
                Vector3 direccionMov = posicionComida.position - transform.position;

                if (!comiendo)
                {
                    comiendo = true;
                }

                if (comiendo)
                {
                    // Rotación alrededor de la comida
                    Quaternion targetRotation = Quaternion.LookRotation(direccionMov);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 30f * Time.deltaTime);
                    Vector3 dondeRotar = posicionComida.position;
                    transform.RotateAround(dondeRotar, axis, 30f * Time.deltaTime);
                }
            }
        }
    }
}
   
