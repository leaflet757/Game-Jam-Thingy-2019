using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
    [SerializeField]
    private KeyCode leanForward = KeyCode.W;

    [SerializeField]
    private KeyCode leanBackward = KeyCode.S;

    [SerializeField]
    private KeyCode leanLeft = KeyCode.A;

    [SerializeField]
    private KeyCode leanRight = KeyCode.D;

    [SerializeField]
    private float moveSpeed = 50f;

    [SerializeField]
    private float rotationSpeed = 50f;

    [SerializeField]
    private float dragAmount = 5f;

    [SerializeField]
    private GameObject playerBody;

    private Rigidbody playerRigidBody;

	// Use this for initialization
	void Start () 
    {
		playerRigidBody = playerBody.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool wasInputPressed = false;

		Vector3 inputDirection = Vector3.zero;
        Vector3 eulerRotation = Vector3.zero;

        if (Input.GetKey(leanForward))
        {
            inputDirection += transform.forward;
            wasInputPressed = true;
        }

        if (Input.GetKey(leanBackward))
        {
            inputDirection -= transform.forward;
            wasInputPressed = true;
        }

        if (Input.GetKey(leanRight))
        {
            eulerRotation += transform.up;
        }

        if (Input.GetKey(leanLeft))
        {
            eulerRotation -= transform.up;
        }

        playerRigidBody.AddForce(Time.deltaTime * moveSpeed * inputDirection.normalized, ForceMode.Force);
        transform.Rotate(Time.deltaTime * rotationSpeed * eulerRotation);

        if (wasInputPressed)
        {
            playerRigidBody.drag = 0;
        }
        else
        {
            playerRigidBody.drag = dragAmount;
        }
	}
}
