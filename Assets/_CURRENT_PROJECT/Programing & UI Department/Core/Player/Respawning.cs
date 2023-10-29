using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    private int test;
    public GameObject spawnPlace;
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;
    public bool isPlayerTwo;
    [SerializeField]
    private int Player2Stock=3;
    [SerializeField]
    private int Player1Stock=3;
    public void Spawn()
    {
        if (!isPlayerTwo && Player1Stock >0)
        {
            GameObject newRobot = Instantiate(Player1, spawnPlace.transform.position + spawnPlace.transform.forward, spawnPlace.transform.rotation);
            newRobot.SetActive(true);
            Debug.Log("player 1 spawnned");
            Player1Stock--;
        }
        if (isPlayerTwo && Player2Stock > 0)
        {
            GameObject newRobot = Instantiate(Player2, spawnPlace.transform.position + spawnPlace.transform.forward, spawnPlace.transform.rotation);
            Debug.Log("player 2 spawnned");
            Player2Stock--;
        }

    }
}
