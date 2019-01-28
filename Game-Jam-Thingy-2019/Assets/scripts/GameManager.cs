using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField]
    private GameCanvas gameCanvas;

    [SerializeField]
    private GameAudio gameAudio;

    [SerializeField]
    private string streetSceneName = "street";

    private int timesCrossedStreet = 0;

    private float gameTime = 0;

    private bool isDayTime = true;

    private GameState gameState = GameState.Title;

    private StreetManager streetManager;
    private PlayerInput playerInput;

	// Use this for initialization
	void Start () 
    {
        gameState = GameState.Title;
        if (gameCanvas != null) gameCanvas.SetTitleScreenEnabled(true);
        if (gameAudio != null) gameAudio.PlaySoundFx("aster");
	}

    void Update()
    {
        switch (gameState)
        {
            case GameState.Title:
            {
                CheckBgTrackStart();
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

    private void CheckBgTrackStart()
    {
        if (!gameAudio.IsSoundFxPlaying("aster"))
        {
            gameAudio.PlayTrack("day_track_1");
        }
    }

    private void UpdateTimer()
    {
        gameTime += Time.deltaTime;
        if (gameCanvas != null) gameCanvas.SetGameTime(gameTime);

        if (!gameAudio.IsSoundFxPlaying("aster") && !gameAudio.IsTrackPlaying("day_track_1"))
        {
            gameAudio.PlayTrack("day_track_1");
        }
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
            playerInput.Setup(this, gameAudio);

            gameState = GameState.Running;

            gameTime = 0;
            timesCrossedStreet = 0;

            if (gameCanvas != null)
            {
                gameCanvas.SetMainGameScreenEnabled(true);
                gameCanvas.SetScore(timesCrossedStreet);
                gameCanvas.FlashText(GameCanvas.FlashLabel.Info, 5f, 5f);
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
        if (gameCanvas != null)
        {
            gameCanvas.SetScore(timesCrossedStreet);
            gameCanvas.FlashText(GameCanvas.FlashLabel.TurnAround, 5f, 0.25f);
        }
    }

    public void GameOver()
    {
        if (gameState != GameState.GameOver)
        {
            gameCanvas.SetGameOverScreen(true);
            gameState = GameState.GameOver;
        }
        if (gameAudio != null)
        {
            gameAudio.PlaySoundFx("explosion");
        }
    }

    public int GetScore()
    {
        return timesCrossedStreet;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public bool IsDayTime()
    {
        return isDayTime;
    }

    public void GetGameAudio()
    {

    }
}
