using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    [SerializeField]
    private Vector3 startingVelocity;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null);

        rb.AddForce(startingVelocity, ForceMode.Impulse);
    }
    private void Update()
    {
        rb.velocity = startingVelocity;
    }

}
