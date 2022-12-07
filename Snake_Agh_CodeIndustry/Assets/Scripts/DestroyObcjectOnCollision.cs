using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObcjectOnCollision : MonoBehaviour
{
    
    private RandomObjectSpawner _randomObjectSpawner;
    private RandomObjectSpawner _randomObjectSpawnerMystery;

    public GameObject prefab;

    private void Awake()
    {
        _randomObjectSpawner = GameObject.Find("Food Spawner").GetComponent<RandomObjectSpawner>();
        _randomObjectSpawnerMystery = GameObject.Find("Mystery Spawner").GetComponent<RandomObjectSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (gameObject.tag == "Food")
            {
                _randomObjectSpawner.RandomObjectSpawn();
                Destroy(prefab);
            }
            else
            {
                _randomObjectSpawnerMystery.RandomObjectSpawn();
                Destroy(prefab);
            }
        }
        if (collision.collider.tag == "Snake")
        {
            Destroy(prefab);
        }
    }
}
