using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool secondPlayer = false;
    [SerializeField] private bool isStunned = false;
    [SerializeField] private RobotData rd;
    private int healthPoints;

    private void Start()
    {
        healthPoints = rd.playerHealth; // Assigns health with the value of the corresponding robotData
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0) // CZ: Would be best to refine this later into a proper death animation
        {
            Destroy(player);
        }

        // CZ: The functions below should be eventually removed and replaced with an appropriate
        // connection to the AttackPlayerInput script or communicate with the colliders for rockets
        // and punches.

        if (Input.GetKeyDown("h") && !secondPlayer) // Debug code, remove later
        {
            healthPoints -= 25;
            Debug.Log("Player HP = " + healthPoints);
        }

        if (Input.GetKeyDown("q") && secondPlayer) // Debug code, remove later 
        {
            healthPoints -= 25;
            Debug.Log("Player HP = " + healthPoints);
        }

        // CZ: The stunned script should stay mostly as is, all that is missing is a external trigger
        // that switches "isStunned" to being True. Feel free to tweak the stun time. Also thanks to Dan for the coroutine!
        if(isStunned)
        {
            isStunned = false;
            stun();
            SendCustomEvenDelayedSeconds(unStun, 3f);
        }
    }

    // CZ: Stun essentially disables player input all together, and enables a stun icon above their head
    // !!!BUG: Currently, the player's model will briefly rotate independently of the parent object when stunned.
    // Only quick fix I could think of at the moment is setting the player model's y rotation to 0 after becoming unstunned

    void stun() 
    {
        MonoBehaviour playerInput = player.GetComponent<PlayerInput>();
        playerInput.enabled = false;
        Debug.Log("Bro is stunned");
        GameObject sI = player.transform.Find("StunIcon").gameObject;
        sI.SetActive(true);
    }

    void unStun()
    {
        MonoBehaviour playerInput = player.GetComponent<PlayerInput>();
        playerInput.enabled = true;
        Debug.Log("Bro is no longer stunned");
        GameObject sI = player.transform.Find("StunIcon").gameObject;
        sI.SetActive(false);
    }

    private IEnumerator RunFunctionAfterDelay(float delayInSeconds, System.Action functionToRun)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Call the function after the delay
        functionToRun.Invoke();
    }

    public void SendCustomEvenDelayedSeconds(System.Action functionToRun, float delayInSeconds)
    {
        StartCoroutine(RunFunctionAfterDelay(delayInSeconds, functionToRun));
    }
}
