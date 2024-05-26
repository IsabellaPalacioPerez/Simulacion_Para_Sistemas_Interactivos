using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRotation : MonoBehaviour
{
    private float rotationSpeed = 40.0f;
    private float minVerticalAngle = -40.0f;
    private float maxVerticalAngle = 40.0f;

    void Update()
    {
        ApplyRotation();
    }

    void ApplyRotation()
    {
        float anguloActual = transform.localEulerAngles.z;

        if (anguloActual != 0)
        {
            transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x,
                transform.localEulerAngles.y,
                0
            );
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Cambiamos las teclas de flecha por AWSD
        float horizontalRotation = Input.GetKey(KeyCode.D) ? 1.0f : (Input.GetKey(KeyCode.A) ? -1.0f : 0.0f);
        float verticalRotation = Input.GetKey(KeyCode.W) ? 1.0f : (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f);

        horizontalRotation *= rotationSpeed * Time.deltaTime;
        verticalRotation *= rotationSpeed * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        transform.Rotate(-verticalRotation, horizontalRotation, 0);
    }
}
