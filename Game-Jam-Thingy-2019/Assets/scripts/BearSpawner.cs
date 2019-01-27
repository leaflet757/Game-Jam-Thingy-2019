using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawner : MonoBehaviour {

    public GameObject carPrefab = null;

    private Rigidbody _rb; //do bears have animations or are they rigid?

    // Use this for initialization
    void Start()
    {
        Instantiate(carPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
