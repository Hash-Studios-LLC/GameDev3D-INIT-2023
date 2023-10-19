using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform GetPlayerSpawnPoint(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                return player1SpawnPoint;
            case 2:
                return player2SpawnPoint;
            default:
                Debug.LogError("Invalid player number");
                return null;
        }
    }

}
