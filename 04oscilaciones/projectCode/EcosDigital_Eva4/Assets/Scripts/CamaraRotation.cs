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

        float horizontalRotation = horizontalInput * rotationSpeed * Time.deltaTime;
        float verticalRotation = verticalInput * rotationSpeed * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        transform.Rotate(-verticalRotation, horizontalRotation, 0);
    }
}
