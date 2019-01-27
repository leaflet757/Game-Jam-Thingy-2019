using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject carPrefab = null;

    public Rigidbody rb;
    public Vector3 start1 = new Vector3();

    // Use this for initialization
    void Start()
    {
        Instantiate(carPrefab,start1, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
                
    }
}
