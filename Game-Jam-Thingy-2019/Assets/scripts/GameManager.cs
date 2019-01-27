using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField]
    private GameCanvas gameCanvas;

    [SerializeField]
    private string streetSceneName = "street";

    private int timesCrossedStreet = 0;

    private float gameTime = 0;

    private GameState gameState = GameState.Title;

	// Use this for initialization
	void Start () 
    {
        gameState = GameState.Title;
        gameCanvas.SetTitleScreenEnabled(true);
	}

    void Update()
    {
        switch (gameState)
        {
            case GameState.Title:
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    StartGame();
                }
            }
            break;
            case GameState.Running:
            {
                UpdateTimer();
            }
            break;
            case GameState.GameOver:
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Restart();
                }
            }
            break;
        }
    }

    private void UpdateTimer()
    {
        gameTime += Time.deltaTime;
        gameCanvas.SetGameTime(gameTime);
    }

    private void StartGame()
    {
        gameState = GameState.Running;
        
        gameCanvas.SetMainGameScreenEnabled(true);
        
        SceneManager.LoadScene(streetSceneName, LoadSceneMode.Additive);
        
        gameTime = 0;
        timesCrossedStreet = 0;
        gameCanvas.SetScore(timesCrossedStreet);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        timesCrossedStreet++;
        gameCanvas.SetScore(timesCrossedStreet);
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }

    public int GetScore()
    {
        return timesCrossedStreet;
    }
}
