using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject carPrefab;
    public float SharkIntervalInSeconds = 5.0f;

    private float spawnCounter = 0;
    private Rigidbody _rb;

    private float totalSharkSpawnedCount = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }
}
