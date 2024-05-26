using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasBurbujas : MonoBehaviour
{
    public GameObject particleSystemPrefab; // Asigna el prefab de tu sistema de partículas en el Inspector

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CreateParticleSystem(mousePosition);
        }
    }

    void CreateParticleSystem(Vector3 position)
    {
        GameObject particleSystemInstance = Instantiate(particleSystemPrefab, position, Quaternion.identity);       
        // Destruye el sistema de partículas y la estela después de tres segundos
        Destroy(particleSystemInstance, 3f);
    }
}
