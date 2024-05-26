using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1Bebe : MonoBehaviour
{
    private Rigidbody rb;

    //Cambiar color
    public Color colorRep = Color.red;
    private Color colorOrig;
    private Renderer characterRenderer;

    //Espinas
    private bool tocoEspinas = false;
    public GameObject criatura;
    public GameObject espinas;

    //Corriente
    static float corriente = 8f;
    public GameObject direccionCorriente;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CambiarDireccion", 0f, Random.Range(0.1f, 1f));

        //Color
        characterRenderer = GetComponent<Renderer>();
        colorOrig = characterRenderer.material.color;
        colorRep = Color.red;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C)) Corriente();
        
        if (tocoEspinas == true)
        {
            Vector3 repelDirection = espinas.transform.position - criatura.transform.position;
            float distance = repelDirection.magnitude;
            Vector3 repelFuerza = repelDirection.normalized * 10f * -500f / Mathf.Max(distance, 1f);
            rb.AddForce(repelFuerza, ForceMode.Impulse);
            Invoke("falseTocoEspinas", 0.01f);
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        float speed = UnityEngine.Random.Range(100f, 300f);
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;

        rb.AddForce(newDirection * speed, ForceMode.Acceleration);
    }    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Espinas"))
        {
            characterRenderer.material.color = colorRep;
            Invoke("AccionEspinas", 1f);
            tocoEspinas = true;
        }
    }
    private void AccionEspinas()
    {
        characterRenderer.material.color = colorOrig;
    }
    private void falseTocoEspinas()
    {
        tocoEspinas = false;
    }

    public void Corriente()
    {
        Vector3 vectorCorriente = direccionCorriente.transform.position - transform.position;
        float distancia = vectorCorriente.magnitude;
        Vector3 fuerzaCorriente = vectorCorriente.normalized * corriente * 400 / Mathf.Max(distancia, 1f);
        rb.AddForce(fuerzaCorriente);
    }
}
