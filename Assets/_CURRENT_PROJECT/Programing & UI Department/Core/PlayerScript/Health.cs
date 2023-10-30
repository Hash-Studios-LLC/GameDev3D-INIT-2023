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
    
    
    void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        currentHP = robotData.playerHealth;
       respawning= GameObject.Find("Spawn Manager").GetComponent<Respawning>();
        
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
