using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField]
    private string streetSceneName = "street";

    [SerializeField]
    private GameObject playerPrefab;

    private int timesCrossedStreet = 0;

	// Use this for initialization
	void Start () 
    {
        SceneManager.LoadScene(streetSceneName, LoadSceneMode.Additive);
	}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        timesCrossedStreet++;
    }

    public int GetScore()
    {
        return timesCrossedStreet;
    }
}
