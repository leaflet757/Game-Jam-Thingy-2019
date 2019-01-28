using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawner : MonoBehaviour {

    public GameObject bearBrefab = null;

    private Rigidbody _rb; //do bears have animations or are they rigid?

    // Use this for initialization
    void Start()
    {
        Instantiate(bearBrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
