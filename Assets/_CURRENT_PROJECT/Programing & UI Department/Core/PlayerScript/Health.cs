using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private AnimationStateController animator;
    private RobotData robotData;
    public GameObject playerRef;
    public float animationDeathTime;// time that lasts death animation
    public Respawning respawning;
    public HPbar healthBar;
        
    void Start()
    {
        animationDeathTime = Random.Range(3.0f, 4.0f);
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        currentHP = robotData.playerHealth;
        animator=GetComponentInParent<AnimationStateController>();
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
            StartCoroutine(DestroyPlayer());
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

    }

    private void playerDie()
    {
        FindAnyObjectByType<VFXList>().DeathExplosion(playerRef);
        FindObjectOfType<AudioManager>().Play("death Explosion");
        Debug.Log("ded");
        // do something else like despawning the player
         currentHP++;
        Destroy(playerRef);

        var player = playerRef.GetComponent<Robot_Initalization>();
        int id = player.getID();
      
        respawning.Spawn(id,playerRef.transform);
    }
   IEnumerator DestroyPlayer()
    {
         playerRef.GetComponent<PlayerInput>().enabled=false;
        animator.Death();
        yield return new WaitForSeconds(animationDeathTime);
        playerDie();
    }
}
