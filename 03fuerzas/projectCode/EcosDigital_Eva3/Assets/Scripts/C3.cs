using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3 : MonoBehaviour
{
    private Rigidbody rb;

    //Comer
    public string tagToRemove = "pezbebe";
    public Transform pezbebe;
    public Vector3 direcction;

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
        InvokeRepeating("Levy", 0f, Random.Range(5f, 10f));

        //Color
        characterRenderer = GetComponent<Renderer>();
        colorOrig = characterRenderer.material.color;
        colorRep = Color.red;
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.C)) Corriente();

        float aceleracion = Random.Range(10f, 20f);
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(newDirection * aceleracion, ForceMode.Acceleration);

        if (transform.position.y < -3)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -3;
            transform.position = newPosition;
        }
        if (tocoEspinas == true)
        {
            Vector3 repelDirection = espinas.transform.position - criatura.transform.position;
            float distance = repelDirection.magnitude;
            Vector3 repelFuerza = new Vector3(repelDirection.normalized.x, 0f, 0f) * 10f * 500f / Mathf.Max(distance, 1f);
            rb.AddForce(repelFuerza, ForceMode.Impulse);
            Invoke("falseTocoEspinas", 0.01f);
        }
    }

    public void Levy()
    {
        float aceleracion = 5000f;
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(newDirection * aceleracion, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToRemove))
        {
            Destroy(collision.gameObject); 
        }

        if (collision.collider.CompareTag("Espinas"))
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