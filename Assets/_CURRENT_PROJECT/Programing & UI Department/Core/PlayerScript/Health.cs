using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHP;

    private RobotData robotData;
    public GameObject playerRef;
   
    public Respawning respawning;
    public HPbar healthBar;
        
    void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        currentHP = robotData.playerHealth;

        //setting the ui health bar to match the player data
        var player = playerRef.GetComponent<Robot_Initalization>();
        int id = player.getID();

        if (id == 1)
        {
            healthBar = GameObject.Find("HealthBarP1").GetComponent<HPbar>();
            healthBar.setMaxHealth(currentHP);
        }
        else
        {
            healthBar = GameObject.Find("HealthBarP2").GetComponent<HPbar>();
            healthBar.setMaxHealth(currentHP);
        }



        respawning = GameObject.Find("Spawn Manager").GetComponent<Respawning>();
        
    }
    private void Update()
    {
        if (currentHP <= 0)
        {
            playerDie();
        }

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
        //check
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
         currentHP++;
        Destroy(playerRef);

        var player = playerRef.GetComponent<Robot_Initalization>();
        int id = player.getID();
      
        respawning.Spawn(id,playerRef.transform);
    }

}
