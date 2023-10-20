using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() // singleton stuff. it makes sure this is the only instance of the gamemanager.
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // for info on how to use the gamemanager and what it is for,
    // read this: https://gamedevbeginner.com/singletons-in-unity-the-right-way/

    // the rest of the code
    public RobotData player1_Selection;
    public RobotData player2_Selection;
    public int selectedMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void initializeMap() // function that initializes the battlefield.
    {

    }

    void startBattle() // function that starts the battle.
    {

    }

    public void exitBattle() // function that returns to the main menu.
    {

    }

    void respawnPlayer()
    {

    }

    public void playerDies()
    {

    }

}
