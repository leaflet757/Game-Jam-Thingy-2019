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
    private Rigidbody playerRigidBody;

	// Use this for initialization
	void Start () 
    {
		Debug.Assert(playerRigidBody != null);
        //SetRagDollEnabled(false);
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
            inputDirection += transform.forward;
            didPlayerLean = true;
        }

        if (Input.GetKey(leanBackward))
        {
            inputDirection -= transform.forward;
            didPlayerLean = true;
        }

        if (Input.GetKey(leanRight))
        {
            eulerRotation += transform.up;
            didPlayerRotate = true;
        }

        if (Input.GetKey(leanLeft))
        {
            eulerRotation -= transform.up;
            didPlayerRotate = true;
        }

        playerRigidBody.AddForce(Time.deltaTime * moveSpeed * inputDirection.normalized, ForceMode.Force);
        transform.Rotate(Time.deltaTime * rotationSpeed * eulerRotation);

        if (didPlayerLean)
        {
            playerRigidBody.drag = 0;
        }
        else
        {
            playerRigidBody.drag = slowDown;
        }

        if (didPlayerRotate)
        {
            playerRigidBody.angularDrag = 0;
        }
        else
        {
            playerRigidBody.angularDrag = rotationSlowDown;
        }
	}

    public void SetRagDollEnabled(bool setEnabled)
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = !setEnabled;
            rb.detectCollisions = setEnabled;
        }

        foreach (CharacterJoint joint in GetComponentsInChildren<CharacterJoint>())
        {
            joint.enableProjection = !setEnabled;
        }

        foreach (Collider col in GetComponentsInChildren<Collider>())
        {
            col.enabled = setEnabled;
        }
    }
}
