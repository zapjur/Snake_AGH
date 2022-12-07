using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    public GameObject cubePrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 4f, 4f);
    }

    void Update()
    {

    }

    void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
    }
    
}
