using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;

    [Header("Dependencies")]
    [SerializeField] private PlayerInput playerInput; // component that handles input
    [SerializeField] private Rigidbody playerBody; //reference to player's rigidbody
    [Space]
    [Header("Options")]
    [SerializeField] private float playerSpeed; //for player's speed


    // Update is called once per frame
    void Update()
    {
        //records the input for the main movement keys
        playerMovementInput = playerInput.playerMovementInput;

        if (Input.GetKey(KeyCode.X)) // running mode. experimental feature for some extra movement mechanics
        {
            movePlayer(playerSpeed * 2);
        }
        else
        {
            movePlayer(playerSpeed);
        }
    }

    //for moving the player
    private void movePlayer(float mSpeed)
    {
        //Vector3 moveVector = transform.TransformDirection(playerMovementInput) * playerSpeed;
        //playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
        Vector3 moveVector = playerMovementInput * mSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
    }

}
