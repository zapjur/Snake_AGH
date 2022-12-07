using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{

    public GameObject[] prefabs;
    public float spawnDelay = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomObjectSpawn", spawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomObjectSpawn()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-90, 91), 3, Random.Range(-90, 91));
        Instantiate(prefabs[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}
