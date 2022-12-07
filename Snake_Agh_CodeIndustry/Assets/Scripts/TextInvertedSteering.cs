using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInvertedSteering : MonoBehaviour
{

    public GameObject floatingTextPrefab;
    GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Snake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowFloatingText()
    {
        Vector3 direction = (Target.transform.position - transform.position) * -1;
        
        Instantiate(floatingTextPrefab, transform.position, Quaternion.LookRotation(direction));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Snake")
        {
            ShowFloatingText();
        }
    }
}
