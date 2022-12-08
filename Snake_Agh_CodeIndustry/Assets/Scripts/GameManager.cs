using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    private bool gameWon = false;
    public float restartDelay = 0.5f;
    public GameObject GameOverUI;
    public GameObject GameWonUI;
    private SnakeController _snakeController;

    [Header("Beans")] 
    public bool killedBean1= false;
    public bool killedBean2= false;
    public bool killedBean3= false;

    private void Awake()
    {
        _snakeController = GameObject.Find("Snake").GetComponent<SnakeController>();
    }

    private void Update()
    {
        if (gameHasEnded && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        else if (gameHasEnded && Input.anyKeyDown)
        {
            Restart();
        }

        if (gameWon && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(("StartScene"));
        }
        else if (gameWon && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (killedBean1 && killedBean2 && killedBean3)
        {
            WinGame();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false && gameWon == false)
        {
            gameHasEnded = true;
            GameOverUI.SetActive(true);
        }
    }

    public void WinGame()
    {
        if (gameWon == false)
        {
            gameWon = true;
            _snakeController.moveSpeed = 0f;
            GameWonUI.SetActive(true);
            
        }
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
