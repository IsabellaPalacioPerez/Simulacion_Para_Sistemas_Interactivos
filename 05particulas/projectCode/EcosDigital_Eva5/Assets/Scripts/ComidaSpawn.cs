using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaSpawn : MonoBehaviour
{
    public GameObject comida;
    private float nextSpawnTime; 

    private void Start()
    {        
        nextSpawnTime = Time.time + Random.Range(1f,5f);
    }
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(comida, RandomSpawnPosition(), Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(1f, 5f);
        }
    }
    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(-50f, 40f);  
        float y = 150f;  
        float z = Random.Range(20f, 30f);  
        return new Vector3(x, y, z);
    }
}
