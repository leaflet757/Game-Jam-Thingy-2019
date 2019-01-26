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


	// Use this for initialization
	void Start () 
    {
        SceneManager.LoadScene(streetSceneName, LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
