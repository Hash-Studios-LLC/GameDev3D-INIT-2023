using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;

    //reference to player's rigidbody
    [SerializeField] private Rigidbody playerBody;
    [Space]
    //for player's speed
    [SerializeField] private float playerSpeed;

    // Update is called once per frame
    void Update()
    {
        //records the input for the main movement keys
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        movePlayer();
    }

    //for moving the player
    private void movePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * playerSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

    }

}
