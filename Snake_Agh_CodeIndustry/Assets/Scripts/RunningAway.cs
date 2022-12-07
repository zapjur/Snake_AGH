using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningAway : MonoBehaviour
{
    [Header("References")]
    private NavMeshAgent _agent;
    public List<GameObject> runningList = new List<GameObject>();
    public GameObject player;

    [Header("Variables")]
    public float EnemyDistanceRun;

    void Start()
    {
        runningList.Add(player);

        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if(obstacle.name == "House")
            {
                runningList.Add(obstacle);
            }
        }

        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        foreach(GameObject obs in runningList)
        {
            float distance = Vector3.Distance(transform.position, obs.transform.position);

            if (distance < EnemyDistanceRun)
            {
                Vector3 dirToPlayer = transform.position - obs.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                _agent.SetDestination(newPos);
            }
        }
    }
    
}
