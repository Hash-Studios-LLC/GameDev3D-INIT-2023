using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
   
    public GameObject spawnPlace;
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;
  
    [SerializeField]
    private int Player2Stock=3;
    [SerializeField]
    private int Player1Stock=3;
   
    //spawns the player based on the id and location
    public void Spawn(int id)
    {
        if (id==1 && Player1Stock >0)
        {
            GameObject newRobot = Instantiate(Player1, spawnPlace.transform.position + spawnPlace.transform.forward, spawnPlace.transform.rotation);
         
            Debug.Log("player 1 spawnned");
            Player1Stock--;
        }
        if (id==2 && Player2Stock > 0)
        {
            GameObject newRobot = Instantiate(Player2, spawnPlace.transform.position + spawnPlace.transform.forward, spawnPlace.transform.rotation);
            Debug.Log("player 2 spawnned");
            Player2Stock--;
        }

    }
   
    public void SpawnLocation()
    {
        int randomIndex = Random.Range(0, 2);
        Debug.Log(randomIndex);
    }
}
