using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.UI;

public class SnakeController : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 20f;
    public float steerSpeed = 180f;
    public int inverted = 1;
    public bool isDead = false;

    [Header("Body")] 
    public GameObject bodyPrefab;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionsHistory = new List<Vector3>();
    public int gap;
    public AudioSource dieSound;

    [Header("Dash")] 
    public float dashCooldown = 10f;
    private float nextDashTime = 0f;
    
    public int cubeCounter = 0;
    public float steerDirection;

    private Score_1 _score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score_1>();
        _score.highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            moveSpeed = 0f;
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        
        steerDirection = Input.GetAxis("Horizontal") * inverted; 
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
        
        positionsHistory.Insert(0, transform.position);

        gap = Math.Abs((int)Math.Round(500/moveSpeed));
        
        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = positionsHistory[Mathf.Min(index * gap, positionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

        if (Input.GetKeyDown(KeyCode.W) && Time.time > nextDashTime)
        {
            StartCoroutine(Dash());
            nextDashTime = Time.time + dashCooldown;
        }
        if(Input.GetKeyDown(KeyCode.Space)) DriftEnter();
        if(Input.GetKeyUp(KeyCode.Space)) DriftExit();
        
        
    }

    public void growSnake()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
        cubeCounter++;
        moveSpeed += 0.10f;
        if (cubeCounter > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", cubeCounter);
            _score.highscore.text = "HIGHSCORE: " + cubeCounter.ToString();
        }
    }

    public IEnumerator Dash()
    {
        moveSpeed *= 5;
        yield return new WaitForSeconds(0.2f);
        moveSpeed /= 5;
    }

    public void DriftEnter()
    {
        steerSpeed *= 2;
    }

    public void DriftExit()
    {
        steerSpeed /= 2;
    }
    public void Die()
    {
        isDead = true;
    }
}
