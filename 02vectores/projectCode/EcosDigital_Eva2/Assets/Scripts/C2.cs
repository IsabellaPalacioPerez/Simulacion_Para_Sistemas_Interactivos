using UnityEngine;

public class C2 : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CambiarDireccion", 0f, Random.Range(0.001f, 0.002f));
    }
    private void CambiarDireccion()
    {
        float aceleracion = Random.Range(15000f, 30000f);
        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        rb.AddForce(newDirection.normalized * aceleracion * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            CambiarDireccion();
        }
    }
}

