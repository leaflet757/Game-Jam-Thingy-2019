using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour 
{
    [SerializeField]
    private string scoreLabel = "You're \"DatBoi\" power\nis {0}";

    [SerializeField]
    private string elapsedTimeLabel = "You \"DatBoi-ed\" for\n{0} seconds";

    [SerializeField]
    private GameObject mainGameScreen;
	
    [SerializeField]
    private GameObject titleScreen;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text timeElapsedText;

    [SerializeField]
    private Text turnAroundText;

    private float turnAroundTextFlashDuration = 0;
    private float turnAroundFlashInterval = 0;

    public void SetMainGameScreenEnabled(bool setEnabled)
    {
        mainGameScreen.SetActive(setEnabled);
        titleScreen.SetActive(!setEnabled);
        gameOverPanel.SetActive(!setEnabled);

        turnAroundText.enabled = false;
    }

    public void SetTitleScreenEnabled(bool setEnabled)
    {
        titleScreen.SetActive(setEnabled);
        mainGameScreen.SetActive(!setEnabled);
        gameOverPanel.SetActive(!setEnabled);
    }

    public void SetGameOverScreen(bool setEnabled)
    {
        gameOverPanel.SetActive(setEnabled);
        titleScreen.SetActive(!setEnabled);
        mainGameScreen.SetActive(!setEnabled);
    }

    public void SetScore(int score)
    {
        scoreText.text = string.Format(scoreLabel, score.ToString());
    }

    public void SetGameTime(float setTime)
    {
        timeElapsedText.text = string.Format(elapsedTimeLabel, Mathf.FloorToInt(setTime).ToString());
    }

    public void FlashTurnAroundText(float duration, float interval)
    {
        turnAroundTextFlashDuration = duration;
        turnAroundFlashInterval = interval;

        turnAroundText.enabled = true;
        StartCoroutine(DisplayTurnAroundText());
    }

    private IEnumerator DisplayTurnAroundText()
    {
        float displayTime = 0;
        float intervalTime = 0;
        
        while (displayTime < turnAroundTextFlashDuration)
        {
            displayTime += Time.deltaTime;
            intervalTime += Time.deltaTime;

            if (intervalTime > turnAroundFlashInterval)
            {
                intervalTime = 0;
                turnAroundText.enabled = !turnAroundText.enabled;
            }

            yield return null;
        }

        turnAroundText.enabled = false;

        yield return null;
    }
}
