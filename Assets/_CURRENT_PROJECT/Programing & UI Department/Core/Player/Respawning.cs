using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Respawning : MonoBehaviour
{
   
    public GameObject spawnPlace;
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;
  //player life
    [SerializeField]
    private int Player2Stock=3;
    [SerializeField]
    private int Player1Stock=3;
    public CinemachineTargetGroup target;
    //spawns the player based on the id and location
    public void Spawn(int id,Transform player)
    {
        //checks player id and life and it spawns a robot
        if (id==1 && Player1Stock >0)
        {
            target.RemoveMember(player);//removes old player from camera
            GameObject newRobot = Instantiate(Player1, SpawnLocation().position + SpawnLocation().forward, SpawnLocation().rotation);
            target.AddMember(newRobot.transform, 1, 2);//adds new player to camera
        
            Debug.Log("player 1 spawnned");
            Player1Stock--;
        }
        if (id==2 && Player2Stock > 0)
        {
            target.RemoveMember(player);//removes old player from camera
            GameObject newRobot = Instantiate(Player2, SpawnLocation().position + SpawnLocation().forward, SpawnLocation().rotation);
            target.AddMember(newRobot.transform, 1, 2);//adds new player to camera
            Debug.Log("player 2 spawnned");
            Player2Stock--;
        }

    }
   // gets a random value and searches for a location
    public Transform SpawnLocation()
    {
        int randomIndex = Random.Range(0, 2);
        Debug.Log("random value: "+randomIndex);
        if (randomIndex == 0)
        {
            Transform location1Transform = GameObject.Find("Location 1").transform;//name should be the same in Scene
            return location1Transform;
        }
        else if (randomIndex == 1)
        {

            Transform location2Transform = GameObject.Find("Location 2").transform;//name should be the same in Scene

            return location2Transform;
        }
        else
        {
            return spawnPlace.transform;
        }
    }
}
    