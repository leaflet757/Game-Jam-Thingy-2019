using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

	void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Collision: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Terrain"))
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
}
