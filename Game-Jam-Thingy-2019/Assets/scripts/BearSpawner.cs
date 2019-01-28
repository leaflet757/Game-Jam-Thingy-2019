using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawner : MonoBehaviour {

    public GameObject bearBrefab = null;

    private float spawnCounter = 0;
    public float IntervalInSeconds = 5.0f;

    public AudioClip launchSound;
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        //Instantiate(bearBrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= IntervalInSeconds)
        {
            spawnCounter = 0;
            normalSpawn();
        }
    }
    void normalSpawn()
    {
        Vector3 startLocation = new Vector3(Random.Range(-750, -411), 0, Random.Range(-41, 21));
        
        Instantiate(bearBrefab, startLocation, Quaternion.Euler(0,90,0));
        bearBrefab.transform.Rotate(0, 180, 0);
        float newPitch = Random.Range(.5f, 1.0f);
        source.PlayOneShot(launchSound, newPitch);
    }
}
