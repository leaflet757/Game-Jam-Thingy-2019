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

    private StreetManager streetManager;
    private PlayerInput playerInput;

	// Use this for initialization
	void Start () 
    {
        gameState = GameState.Title;
        if (gameCanvas != null) gameCanvas.SetTitleScreenEnabled(true);
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
        if (gameCanvas != null) gameCanvas.SetGameTime(gameTime);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(streetSceneName, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene loadedScene, LoadSceneMode loadSceneMode)
    {
        if (loadedScene.name == streetSceneName)
        {
            var foundStreetManagers = GameObject.FindObjectsOfType<StreetManager>();
            Debug.Assert(foundStreetManagers.Length == 1, "Did not find the street manager");
            streetManager = foundStreetManagers[0];
            streetManager.Setup(this);

            var foundPlayers = GameObject.FindObjectsOfType<PlayerInput>();
            Debug.Assert(foundPlayers.Length == 1, "Did not find the player");
            playerInput = foundPlayers[0];
            playerInput.Setup(this);

            gameState = GameState.Running;

            gameTime = 0;
            timesCrossedStreet = 0;

            if (gameCanvas != null)
            {
                gameCanvas.SetMainGameScreenEnabled(true);
                gameCanvas.SetScore(timesCrossedStreet);
            }
        }
    }

    private void Restart()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        timesCrossedStreet++;
        if (gameCanvas)
        {
            gameCanvas.SetScore(timesCrossedStreet);
            gameCanvas.FlashTurnAroundText(5f, 1f);
        }
    }

    public void GameOver()
    {
        gameCanvas.SetGameOverScreen(true);
        gameState = GameState.GameOver;
    }

    public int GetScore()
    {
        return timesCrossedStreet;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}
