using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHP;

    private RobotData robotData;
    public GameObject playerRef;
    public HPbar healthBar;

    void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        currentHP = robotData.playerHealth;

        //setting the ui health bar to match the player data
        healthBar.setMaxHealth(currentHP);
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

        //updating the health bar in the UI
        healthBar.setHealth(currentHP);

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
