using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject carPrefab = null;

    public Vector3 start1 = new Vector3();
    public Vector3 currentLocation;

    private float spawnCounter = 0;
    public float IntervalInSeconds = 5.0f;

    //AUDIO
    public AudioClip launchSound;
    private AudioSource source;

    //DELTA
    private Vector3 delta1 = new Vector3(-750, 0, 21);
    private Vector3 delta2 = new Vector3(-725, 0, 11);
    private Vector3 delta3 = new Vector3(-700, 0, -11);
    private Vector3 delta4 = new Vector3(-725, 0, -31);
    private Vector3 delta5 = new Vector3(-750, 0, -41);
         
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        // Instantiate(carPrefab,start1, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    //    int score = gameManager.GetScore();
        
        
            spawnCounter += Time.deltaTime;
            if (spawnCounter >= IntervalInSeconds)
            {
                spawnCounter = 0;
                normalSpawn();
                normalSpawn();
            }
    }
    void deltaSpawn()
    {
        Instantiate(carPrefab, delta1, Quaternion.identity);
        Instantiate(carPrefab, delta2, Quaternion.identity);
        Instantiate(carPrefab, delta3, Quaternion.identity);
        Instantiate(carPrefab, delta4, Quaternion.identity);
        Instantiate(carPrefab, delta5, Quaternion.identity);
    }
    void normalSpawn()
    {
        Vector3 startLocation = new Vector3(Random.Range(-750, -411), 0, Random.Range(-41, 21));
        Instantiate(carPrefab, startLocation, Quaternion.identity);
        float newPitch = Random.Range(.5f, 1.0f);
        source.PlayOneShot(launchSound, newPitch);
    }
}
