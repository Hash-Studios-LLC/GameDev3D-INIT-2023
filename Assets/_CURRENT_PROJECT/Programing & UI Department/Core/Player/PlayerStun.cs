using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool isStunned = false;
    [SerializeField] private RobotData rd;

    // Update is called once per frame
    void Update()
    {
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
