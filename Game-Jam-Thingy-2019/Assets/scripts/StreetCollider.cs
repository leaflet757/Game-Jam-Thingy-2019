using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCollider : MonoBehaviour 
{
    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.IncrementScore();
                Debug.Log("Score: " + gameManager.GetScore());
            }
            else
            {
                Debug.Log("GameManaager is null, should increment score!");
            }
        }
    }
}
