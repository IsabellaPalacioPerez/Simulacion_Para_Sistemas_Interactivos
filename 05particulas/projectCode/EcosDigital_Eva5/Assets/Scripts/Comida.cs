using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Comida : MonoBehaviour
{
    private float constanteDelResorte = 0;
    private float amortiguacion = 0;
    private float velocidadEncogimiento = 0f;
    private float posicionFinal = 0f;
    private bool terminoDeCaer = false;
    private bool posicionCapturada = false;

    private Vector3 posicionInicial;
    private Vector3 velocidad;

    private void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        InvokeRepeating("EncogerDestruir", Random.Range(5f, 8f), 0.1f);
        velocidadEncogimiento = Random.Range(0.01f, 0.03f);
        amortiguacion = Random.Range(0.1f, 1f);
        constanteDelResorte = Random.Range(8f, 12f);
        posicionFinal = Random.Range(10f, 20f);      
        
    }

    private void FixedUpdate()
    {
        if (terminoDeCaer == false)
        {
            // Mueve gradualmente el objeto hacia la posición Y objetivo.
            float step = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posicionFinal, transform.position.z), step);

            // Comprueba si el objeto ha alcanzado la posición Y objetivo.
            if (transform.position.y <= posicionFinal)
            {
                terminoDeCaer = true;
                if (posicionCapturada == false)
                {
                    posicionInicial = transform.position;
                    posicionCapturada = true;
                }                
            }
        }     

        if (terminoDeCaer == true)
        {
            // Fuerza del resorte
            Vector3 desplazamiento = posicionInicial - transform.position;
            Vector3 fuerzaDelResorte = constanteDelResorte * desplazamiento;
            // Fuerza de amortiguación
            Vector3 fuerzaDeAmortiguacion = -amortiguacion * velocidad;
            // Suma las fuerzas
            Vector3 fuerzaTotal = fuerzaDelResorte + fuerzaDeAmortiguacion;
            GetComponent<Rigidbody>().AddForce(fuerzaTotal);
            // Guarda la velocidad actual
            velocidad = GetComponent<Rigidbody>().velocity;
        }        
    }

    private void EncogerDestruir()
    {
        transform.localScale -= new Vector3(velocidadEncogimiento, velocidadEncogimiento, velocidadEncogimiento);
        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
