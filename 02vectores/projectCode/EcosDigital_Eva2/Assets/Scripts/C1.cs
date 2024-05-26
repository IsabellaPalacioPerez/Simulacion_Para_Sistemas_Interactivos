using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1 : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CambiarDireccion", 0f, UnityEngine.Random.Range(0.1f, 1f));
    }

    private void CambiarDireccion()
    {
        float speed = UnityEngine.Random.Range(100f, 300f);
        Vector3 newDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

        rb.AddForce(newDirection * speed, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            CambiarDireccion();
        }
    }
}
