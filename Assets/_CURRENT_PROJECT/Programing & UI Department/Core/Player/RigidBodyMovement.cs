using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;

    [Header("Dependencies")]
    [SerializeField] private PlayerInput playerInput; 
    [SerializeField] private Rigidbody playerBody; 
    public RobotData robotData;

    [Space]
    [Header("Options")]
    [SerializeField] private float basePlayerSpeed;

    [Space]
    [Header("Player Settings")]
    [SerializeField] private int playerNumber; // Set this in the inspector

    private void Start()
    {
        RespawnPlayer(); 
    }

    void Update()
    {
        playerMovementInput = playerInput.playerMovementInput;

        float speedMultiplier = Input.GetKey(KeyCode.X) ? 2f : 1f;
        movePlayer(basePlayerSpeed * speedMultiplier * robotData.playerSpeed);
    }
    //for moving the player
    private void movePlayer(float mSpeed)
    {
        Vector3 moveVector = playerMovementInput * mSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

        if (moveVector != Vector3.zero)
        {
            playerBody.transform.forward = moveVector;
        }
    }
    //spawns the player at the certain points
    public void RespawnPlayer()
    {
        Transform spawnPoint = SpawnManager.Instance.GetPlayerSpawnPoint(playerNumber);
        if(spawnPoint != null)
        {
            Debug.Log("Spawn Point Found: " + spawnPoint.position);
            playerBody.position = spawnPoint.position;
            playerBody.rotation = spawnPoint.rotation;
        }
        else
        {
            Debug.Log("Spawn Point Not Found");
        }
    }

}
