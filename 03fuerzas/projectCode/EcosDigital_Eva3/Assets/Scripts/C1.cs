using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class C1 : MonoBehaviour
{
    private Rigidbody rb;

    //Atracción
    public GameObject targetObject;
    public float attractionForce = 8f;
    public GameObject hijo;
    public Vector3 posicionHijos;
    public GameObject padre;

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
        CaminataAleatoria();

        //Color
        characterRenderer = GetComponent<Renderer>();
        colorOrig = characterRenderer.material.color;
        colorRep = Color.red;
    }
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) Atraccion();
        if (Input.GetKey(KeyCode.C)) Corriente();
        if (transform.position.y < -3)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -3;
            transform.position = newPosition;
        }
        if(tocoEspinas == true)
        {
            Vector3 repelDirection = espinas.transform.position - criatura.transform.position;
            float distance = repelDirection.magnitude;
            Vector3 repelFuerza = new Vector3(repelDirection.normalized.x, 0f, 0f) * 10f * -500f / Mathf.Max(distance, 1f);
            rb.AddForce(repelFuerza, ForceMode.Impulse);

            Invoke("falseTocoEspinas", 0.01f);
            CaminataAleatoria();
        }
    }
    public void CaminataAleatoria()
    {
        float speed = Random.Range(100f, 300f);
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;

        rb.AddForce(newDirection * speed, ForceMode.Acceleration);

    }
    public void Atraccion()
    {
        if (targetObject != null)
        {
            Vector3 attractionDirection = targetObject.transform.position - transform.position;
            float distance = attractionDirection.magnitude;

            Vector3 attractionForceVector = attractionDirection.normalized * attractionForce * 10 / Mathf.Max(distance, 1f);
            rb.AddForce(attractionForceVector);

            posicionHijos = attractionDirection;
            if (distance <= 2.2f)  
            {
                GameObject nuevoObjeto = Instantiate(hijo, padre.transform.position, Quaternion.identity);
            }
        } 
        
        
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
