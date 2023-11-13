using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Respawning : MonoBehaviour
{
    [Header("Win Screen Handling")]
    [SerializeField]
    public WinConditionCheck winCond;

    [Header(" Spawns management")]
    public GameObject[] SpawnList;
    [SerializeField]
    private float respawnTime;
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;

    private PlayerInput p1script;
    private PlayerInput p2script;

    //player life
    [SerializeField]
    private int Player2Stock = 3;
    [SerializeField]
    private int Player1Stock = 3;
    public CinemachineTargetGroup target;
    private int selection;
    //spawns the player based on the id and location
    [SerializeField] private int p1Number;// only to show it works
    [SerializeField] private int p2Number;// 
    void Start()
    {

        FindAnyObjectByType<AudioManager>().Stop("Main Theme");
        FindAnyObjectByType<AudioManager>().Play("battle theme");
        // spawns player for the first time no need to add them to the scene
        GameObject newRobot = Instantiate(Player1);
        GameObject newRobot2 = Instantiate(Player2);
        FirstSpawn(newRobot, newRobot2);
        target.AddMember(newRobot.transform, 1, 2);//adds new player to camera



        target.AddMember(newRobot2.transform, 1, 2);//adds new player to camera
        // selects model
        sendSelection(newRobot2);
        sendSelection(newRobot);
    }
    public void Spawn(int id, Transform player)
    {
        //checks player id and life and it spawns a robot   
        if (id == 1 && Player1Stock > 0)
        {
            StartCoroutine(SpawnDelay(player, Player1, false));

            Debug.Log("player 1 spawnned");
            Player1Stock--;


        }
        if (id == 2 && Player2Stock > 0)
        {
            StartCoroutine(SpawnDelay(player, Player2, true));
            Debug.Log("player 2 spawnned");
            Player2Stock--;


        }

        //CZ: checks if player 1 or 2 are out of stocks, and sends the message to display the appropriate win screen
        if (id == 1 && Player1Stock == 0)
        {
            winCond.DisplayWinScreenP2();
            Debug.Log("player 2 wins");
            p2script.enabled = false;
        }
        if (id == 2 && Player2Stock == 0)
        {
            winCond.DisplayWinScreenP1();
            Debug.Log("player 1 wins");
            p1script.enabled = false;
        }

    }
    // gets a random value and searches for a location
    public Transform SpawnLocation()
    {
        int randomIndex = Random.Range(0, SpawnList.Length);
        Debug.Log("random value: " + randomIndex);
        return SpawnList[randomIndex].transform;

    }
    public void FirstSpawn(GameObject p1, GameObject p2)
    {
        int randomIndex = Random.Range(0, SpawnList.Length);
        p1.transform.position = SpawnList[randomIndex].transform.position;
        p1.transform.rotation = SpawnList[randomIndex].transform.rotation;
        int randomIndex2 = Random.Range(0, SpawnList.Length);
        while (randomIndex2 == randomIndex)
        {
            randomIndex2 = Random.Range(0, SpawnList.Length);
        }
        p2.transform.position = SpawnList[randomIndex2].transform.position;
        p1.transform.rotation = SpawnList[randomIndex2].transform.rotation;

        p1script = p1.GetComponent<PlayerInput>();
        p2script = p2.GetComponent<PlayerInput>();

    }
    //character selection ui  use this to set character
    public void intSelection(int p1Number, int p2Number)
    {
        this.p1Number = p1Number;
        this.p2Number = p2Number;
    }
    //
    public void sendSelection(GameObject robot)
    {
        // sends the value store respawn script
        if (robot.GetComponent<Robot_Initalization>().getID() == 1)
        {
            robot.GetComponent<Robot_Initalization>().setRobotNum(p1Number);

        }
        if (robot.GetComponent<Robot_Initalization>().getID() == 2)
        {
            robot.GetComponent<Robot_Initalization>().setRobotNum(p2Number);

        }
    }

    IEnumerator SpawnDelay(Transform player, GameObject playerN, bool secondPlayer)
    {
        yield return new WaitForSeconds(respawnTime);
        target.RemoveMember(player);//removes old player from camera
        GameObject newRobot = Instantiate(playerN, SpawnLocation().position + SpawnLocation().forward, SpawnLocation().rotation);
        target.AddMember(newRobot.transform, 1, 2);//adds new player to camera                                         
        sendSelection(newRobot);
    }

}
