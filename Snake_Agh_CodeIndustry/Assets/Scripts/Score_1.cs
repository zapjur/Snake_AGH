using System;
using UnityEngine;
using UnityEngine.UI;

public class Score_1 : MonoBehaviour
{
    private SnakeController _snakeController;
    public Text score;
    public Text highscore;

    private void Awake()
    {
        _snakeController = GameObject.Find("Snake").GetComponent<SnakeController>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = _snakeController.cubeCounter.ToString();
    }
}
