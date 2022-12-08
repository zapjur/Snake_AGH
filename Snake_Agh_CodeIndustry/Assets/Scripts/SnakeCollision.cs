using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    private SnakeController _snakeController;
    private BoostsCoroutines _boostsCoroutines;
    public AudioSource eatSound;

    private void Awake()
    {
        _snakeController = GetComponent<SnakeController>();
        _boostsCoroutines = GetComponent<BoostsCoroutines>();
        eatSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Food")
        {
            eatSound.Play();

            if (_boostsCoroutines.isScoreBoosting == true)
            {
                _snakeController.growSnake();
                _snakeController.growSnake();
                _snakeController.growSnake();
            }
            else _snakeController.growSnake();
        }

        if (collision.collider.tag == "Body" && _snakeController.cubeCounter > 10 && !(_snakeController.isDashing))
        {
            FindObjectOfType<GameManager>().EndGame();
            _snakeController.Die();
        }

        if (collision.collider.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
            _snakeController.Die();
        }

        if (collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
            _snakeController.Die();
        }

        //Mystery Boosts
        if (collision.collider.tag == "IncreaseSpeed")
        {
            _boostsCoroutines.StartCoroutine(_boostsCoroutines.IncreaseSpeed());
        }
        if (collision.collider.tag == "DecreaseSpeed")
        {
            _boostsCoroutines.StartCoroutine(_boostsCoroutines.DecreaseSpeed());
        }
        if (collision.collider.tag == "InvertedSteering")
        {
            _boostsCoroutines.StartCoroutine(_boostsCoroutines.InvertedSteering());
        }
        if (collision.collider.tag == "ScoreBooster")
        {
            _boostsCoroutines.StartCoroutine(_boostsCoroutines.ScoreBooster());
        }
    }
}
