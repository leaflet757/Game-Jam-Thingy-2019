using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    private GameManager gameManager;

    private const int TERRAIN_LAYER = 9;

	void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.layer == TERRAIN_LAYER)
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                Debug.Log("GameManager has not been set for Body script!");
            }
        }
    }

    public void Setup(GameManager setGameManager)
    {
        gameManager = setGameManager;
    }
}
