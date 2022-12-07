using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsCoroutines : MonoBehaviour
{
    public float effectTimer = 5f;
    public float increaseSpeed = 5f;
    public float decreaseSpeed = 5f;
    public bool isScoreBoosting = false;

    private SnakeController _snakeController;

    private void Awake()
    {
        _snakeController = GetComponent<SnakeController>();
    }

    public IEnumerator IncreaseSpeed()
    {
        _snakeController.moveSpeed += increaseSpeed;
        yield return new WaitForSeconds(effectTimer);
        _snakeController.moveSpeed -= increaseSpeed;
    }

    public IEnumerator DecreaseSpeed()
    {
        if (_snakeController.moveSpeed - decreaseSpeed < 5f)
        {
            _snakeController.moveSpeed = 5f;
        }
        else
        {
            _snakeController.moveSpeed -= decreaseSpeed;
        }
        yield return new WaitForSeconds(effectTimer);
        _snakeController.moveSpeed += decreaseSpeed;
    }

    public IEnumerator InvertedSteering()
    {
        _snakeController.inverted = -1;
        yield return new WaitForSeconds(effectTimer);
        _snakeController.inverted = 1;
    }

    public IEnumerator ScoreBooster()
    {
        isScoreBoosting = true;
        yield return new WaitForSeconds(2 * effectTimer);
        isScoreBoosting = false;
    }
}
