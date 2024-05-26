using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3 : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Levy", 0f, Random.Range(5f, 10f));
    }

    private void FixedUpdate()
    {
        float aceleracion = Random.Range(10f, 20f);
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(newDirection * aceleracion, ForceMode.Acceleration);

    }

    public void Levy()
    {
        float aceleracion = 5000f;
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(newDirection * aceleracion, ForceMode.Acceleration);
    }
}