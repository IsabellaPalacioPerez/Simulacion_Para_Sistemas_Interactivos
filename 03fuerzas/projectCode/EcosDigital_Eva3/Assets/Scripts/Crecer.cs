using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public Vector3 targetSize = new Vector3(2f, 2f, 2f); 
    public float resizeSpeed = 0.001f; 

    private Vector3 initialSize;
    private float t = 0f;

    private void Start()
    {
        initialSize = transform.localScale;
    }

    private void Update()
    {
        t += Time.deltaTime * resizeSpeed;
        if (t > 1f)
            t = 1f;

        Vector3 newSize = Vector3.Lerp(initialSize, targetSize, t);
        transform.localScale = newSize;
    }
}
