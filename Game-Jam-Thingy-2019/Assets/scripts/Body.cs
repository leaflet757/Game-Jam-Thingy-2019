using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour 
{
    [SerializeField]
    private GameObject deathEffectPrefab;

    [SerializeField]
    private GameObject rainPrefab;

    [SerializeField]
    private GameObject impactEffectPrefab;

    private GameManager gameManager;

    private const int TERRAIN_LAYER = 9;

	void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.layer == TERRAIN_LAYER)
        {
            if (gameManager != null)
            {
                PlayDeathFx();
                gameManager.GameOver();
            }
            else
            {
                Debug.Log("GameManager has not been set for Body script!");
            }
        }
    }

    public void OnJointBreak(float breakForce)
    {
        if (impactEffectPrefab != null)
        {
            GameObject impactInstance = Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);
            impactInstance.transform.rotation = Quaternion.Euler(-90,0,0);
        }
        else
        {
            Debug.Log("Body impactEffectPrefab has not been set!");
        }
    }

    public void Setup(GameManager setGameManager)
    {
        gameManager = setGameManager;
    }

    private void PlayDeathFx()
    {
        if (deathEffectPrefab != null)
        {
            GameObject deathFxInstance = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            deathFxInstance.transform.rotation = Quaternion.Euler(-90,0,0);
        }
        else
        {
            Debug.Log("Body deathEffectPrefab has not been set!");
        }
        if (rainPrefab != null)
        {
            //GameObject rainFxInstance = Instantiate(rainPrefab, transform.position, Quaternion.identity);
            //rainFxInstance.transform.rotation = Quaternion.Euler(90,0,0);
        }
    }
}
