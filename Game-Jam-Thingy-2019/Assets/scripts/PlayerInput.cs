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
    private float moveSpeed = 500f;

    [SerializeField]
    private float rotationSpeed = 50f;

    [SerializeField]
    private float slowDown = 5f;

    [SerializeField]
    private float rotationSlowDown = 5f;

    [SerializeField]
    private GameObject playerBody;

    [SerializeField]
    private Rigidbody unicycleRigidBody;

	// Use this for initialization
	void Start () 
    {
		Debug.Assert(unicycleRigidBody != null);
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool didPlayerLean = false;
        bool didPlayerRotate = false;

		Vector3 inputDirection = Vector3.zero;
        Vector3 eulerRotation = Vector3.zero;

        if (Input.GetKey(leanForward))
        {
            inputDirection += unicycleRigidBody.transform.forward;
            didPlayerLean = true;
        }

        if (Input.GetKey(leanBackward))
        {
            inputDirection -= unicycleRigidBody.transform.forward;
            didPlayerLean = true;
        }

        if (Input.GetKey(leanRight))
        {
            eulerRotation += Vector3.up;
            didPlayerRotate = true;
        }

        if (Input.GetKey(leanLeft))
        {
            eulerRotation -= Vector3.up;
            didPlayerRotate = true;
        }

        unicycleRigidBody.AddForce(Time.deltaTime * moveSpeed * inputDirection.normalized, ForceMode.Force);
        unicycleRigidBody.transform.eulerAngles = unicycleRigidBody.transform.eulerAngles + eulerRotation;

        if (didPlayerLean)
        {
            unicycleRigidBody.drag = 0;
        }
        else
        {
            unicycleRigidBody.drag = slowDown;
        }

        if (didPlayerRotate)
        {
            unicycleRigidBody.angularDrag = 0;
        }
        else
        {
            unicycleRigidBody.angularDrag = rotationSlowDown;
        }
	}
}
