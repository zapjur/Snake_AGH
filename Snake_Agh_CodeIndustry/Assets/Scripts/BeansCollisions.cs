using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeansCollisions : MonoBehaviour
{
    private GameManager _gameManager;
    public KilledTextEnable _killedTextEnable;
    private SnakeController _snakeController;
    public tooShort _tooshort;

    private void Awake()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _snakeController = GameObject.Find("Snake").GetComponent<SnakeController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Snake" && _snakeController.cubeCounter >= 15)
        {
            _gameManager.killedBean1 = true;
            Destroy(gameObject);
            _killedTextEnable.killedUI.SetActive(true);
            _killedTextEnable.StartCoroutine(_killedTextEnable.killed());
        }
        else if (collision.collider.tag == "Snake" && _snakeController.cubeCounter < 15)
        {
            _tooshort.tooShortUI.SetActive(true);
            _tooshort.StartCoroutine(_tooshort.tooShortToEat());
        }
    }
    
}
