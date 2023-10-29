using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHP;

    private RobotData robotData;
    public GameObject playerRef;

    void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        currentHP = robotData.playerHealth;
    }

    public void bulletHit(int damage)
    {
        if (currentHP <= 0) { return; }
        takeDamage(damage);
    }

    public void punchHit(int damage)
    {
        if (currentHP <= 0) { return; }
        takeDamage(damage);
    }

    public void takeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("took " + damage);
        if (currentHP <= 0)
        {
            playerDie();
        }
    }

    private void playerDie()
    {
        Debug.Log("ded");
        // do something else like despawning the player
    }

}
