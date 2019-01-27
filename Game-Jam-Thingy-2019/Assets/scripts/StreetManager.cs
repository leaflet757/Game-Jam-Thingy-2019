using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour 
{
    [SerializeField]
    private StreetCollider startZone;

    [SerializeField]
    private StreetCollider otherZone;

    [SerializeField]
    private GameManager gameManager;

    private bool playerHitStartZone = true;

    public void Setup(GameManager setGameManager)
    {
        gameManager = setGameManager;

        Debug.Assert(startZone != null, "startZone is NULL");
        startZone.Setup(this, true);

        Debug.Assert(otherZone != null, "otherZone is NULL");
        otherZone.Setup(this, false);

        playerHitStartZone = true;
    }

    public void OnStreetColliderHit(StreetCollider streetCollider, Collider other)
    {
        if (other.transform.parent != null)
        {
            if (playerHitStartZone != streetCollider.IsStartZone() && other.transform.parent.CompareTag("Player"))
            {
                if (gameManager != null)
                {
                    playerHitStartZone = streetCollider.IsStartZone();
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
}
