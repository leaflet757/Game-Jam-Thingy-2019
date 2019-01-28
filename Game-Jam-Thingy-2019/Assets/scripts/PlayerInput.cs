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
    private float maxSpeed = 10f;

    [SerializeField]
    private GameObject playerBody;

    [SerializeField]
    private Rigidbody playerRigidBody;

    [SerializeField]
    private Transform unicycleRootTransform;

    [SerializeField]
    private Transform unicycleAnchor;

    [SerializeField]
    private Transform centerLeanAnchor;
    
    [SerializeField]
    private Transform leftLeanAnchor;
    
    [SerializeField]
    private Transform rightLeanAnchor;

    [SerializeField]
    private Camera mainCamera;

    private GameManager gameManager;

	// Use this for initialization
	void Start () 
    {
        Debug.Assert(playerRigidBody != null);
        Debug.Assert(mainCamera != null);
    }
	
	// Update is called once per frame
	void Update () 
    {
        // return early if we are not running
        if (gameManager != null && gameManager.GetGameState() != GameState.Running) return;

        bool didPlayerLean = false;
        bool didPlayerRotate = false;

		Vector3 inputDirection = Vector3.zero;
        Vector3 eulerRotation = Vector3.zero;

        Vector3 forwardDirection = Vector3.Project(mainCamera.transform.forward, transform.forward);

        if (Input.GetKey(leanForward))
        {
            inputDirection += forwardDirection;
            didPlayerLean = true;
        }

        if (Input.GetKey(leanBackward))
        {
            inputDirection -= forwardDirection;
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

        if (playerRigidBody.velocity.magnitude < maxSpeed)
        {
            // Move the player forward or backward
            playerRigidBody.AddForce(moveSpeed * inputDirection.normalized, ForceMode.Force);
        }

        // Turn the player about the Y axis
        transform.eulerAngles = transform.eulerAngles + eulerRotation;

        // If the player is moving forward then set the drag to 0
        if (didPlayerLean)
        {
            playerRigidBody.drag = 0;
        }
        else // Otherwise apply some drag
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

    public void Setup(GameManager setManager)
    {
        gameManager = setManager;

        Body playerBody = GetComponentInChildren<Body>();
        Debug.Assert(playerBody != null, "playerBody script is NULL");
        playerBody.Setup(setManager);
    }
}
