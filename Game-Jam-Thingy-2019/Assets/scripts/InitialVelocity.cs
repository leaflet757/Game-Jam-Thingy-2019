using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour 
{
    [SerializeField]
    private Vector3 startingVelocity;

	// Use this for initialization
	void Start () 
    {
        Rigidbody rb = GetComponent<Rigidbody>();
		Debug.Assert(rb != null);

        rb.AddForce(startingVelocity, ForceMode.Impulse);
	}

}
