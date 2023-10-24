using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;

    public RobotData robot;
    void Start()
    {
        // gets value from attributes 
        //RobotData  robot=GetComponent<RobotData>();
        health = robot.playerHealth;


    }
    // call to damage the player
    public void getDamage(int damage)
    {
        health -= damage;
    }

}
