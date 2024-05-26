using UnityEngine;

public class CamaraRaycast : MonoBehaviour
{
    private Camera mainCamara;
    private MeshRenderer selectedRenderer;
    private Color originalColor;
    private float colorChangeTime;

    private bool isDamaging = false;
    private float damageStartTime;
    private float damageDuration = 0.1f; // Duración del efecto de daño
    private Vector3 originalScale;

    private void Start()
    {
        mainCamara = GetComponent <Camera>();
    }

    private void Update()
    {
        if (isDamaging && Time.time - damageStartTime >= damageDuration)
        {
            isDamaging = false;
            selectedRenderer.material.color = Color.white;
            selectedRenderer.transform.localScale = originalScale;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamara.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                selectedRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                originalColor = selectedRenderer.material.color;
                selectedRenderer.material.color = Color.red;
                colorChangeTime = Time.time;
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);

                // Reducir temporalmente la escala del objeto para simular daño
                isDamaging = true;
                damageStartTime = Time.time;
                originalScale = selectedRenderer.transform.localScale;
                selectedRenderer.transform.localScale *= 0.8f;
            }
        }

        if (selectedRenderer != null && Time.time - colorChangeTime >= 1.0f)
        {
            selectedRenderer.material.color = Color.white;
            selectedRenderer = null;
        }
    }
}

