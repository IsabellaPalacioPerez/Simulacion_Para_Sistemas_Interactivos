using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisPart_Plantas : MonoBehaviour
{
    public string targetPez = "peces"; // Cambia esto al tag que quieras usar
    public ParticleSystem particleSystem;

    private void Update()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetPez);

        bool shouldActivate = false;

        foreach (var targetObject in targetObjects)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);
           
            if (distance <= 1)
            {
                shouldActivate = true;
                break;
            }
        }        
        if (particleSystem != null)
        {
            if (shouldActivate)
            {
                if (!particleSystem.isPlaying)
                {                   
                    particleSystem.Play(true);
                }
                particleSystem.transform.position = transform.position;
            }
            else
            {
                if (particleSystem.isPlaying)
                {
                    particleSystem.Stop();
                }
            }
        }
    }
}
