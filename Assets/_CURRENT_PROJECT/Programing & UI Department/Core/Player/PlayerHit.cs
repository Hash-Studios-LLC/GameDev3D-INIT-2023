using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int hitPoints = 100;
    [SerializeField] private bool secondPlayer = false;
    [SerializeField] private bool isStunned = false;

    // Update is called once per frame
    void Update()
    {
        if (hitPoints == 0) // CZ: Would be best to refine this later into a proper death animation
        {
            Destroy(player);
        }

        // CZ: The functions below should be eventually removed and replaced with an appropriate
        // connection to the AttackPlayerInput script or communicate with the colliders for rockets
        // and punches.

        if (Input.GetKeyDown("h") && !secondPlayer) // Debug code, remove later
        {
            hitPoints -= 25;
            Debug.Log("Player HP = " + hitPoints);
        }

        if (Input.GetKeyDown("q") && !secondPlayer) // Debug code, remove later 
        {
            hitPoints -= 25;
            Debug.Log("Player HP = " + hitPoints);
        }

        // CZ: The stunned script should stay mostly as is, all that is missing is a external trigger
        // that switches "isStunned" to being True.
        if(isStunned)
        {
            isStunned = false;
            stun();
            SendCustomEvenDelayedSeconds(unStun, 3f);
        }
    }

    void stun() // Stun essentially disables player input all together.
    {
        MonoBehaviour playerInput = player.GetComponent<PlayerInput>();
        playerInput.enabled = false;
        Debug.Log("Bro is stunned");
    }

    void unStun()
    {
        MonoBehaviour playerInput = player.GetComponent<PlayerInput>();
        playerInput.enabled = true;
        Debug.Log("Bro is no longer stunned");
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
