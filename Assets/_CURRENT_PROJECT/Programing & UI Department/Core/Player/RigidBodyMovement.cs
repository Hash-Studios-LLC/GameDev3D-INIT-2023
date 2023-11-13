using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;

    [Header("Dependencies")]
    [SerializeField] private PlayerInput playerInput; // component that handles input
    [SerializeField] private Rigidbody playerBody; //reference to player's rigidbody
    public RobotData robotData;
    [Space]
    [Header("Options")]
    [SerializeField] private float basePlayerSpeed; // the base speed, before the specific speed modifiers for each robot

    private void Start()
    {
        robotData = gameObject.GetComponent<Robot_Initalization>().rob;
    }
    // Update is called once per frame
    void Update()
    {
        //records the input for the main movement keys
        playerMovementInput = playerInput.playerMovementInput;

        if (Input.GetKey(KeyCode.X)) // running mode. experimental feature for some extra movement mechanics
        {
            movePlayer(basePlayerSpeed * 2 * robotData.playerSpeed);
        }
        else
        {
            movePlayer(basePlayerSpeed * robotData.playerSpeed);
        }
    }

    //for moving the player
    private void movePlayer(float mSpeed)
    {
        //Vector3 moveVector = transform.TransformDirection(playerMovementInput) * playerSpeed;
        //playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
        Vector3 moveVector = playerMovementInput * mSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

        if (moveVector != Vector3.zero)
        {
            playerBody.transform.forward = moveVector; // Changes rotation to match movement direction
        }
    }

}
