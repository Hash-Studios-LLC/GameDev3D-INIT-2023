using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncher : MonoBehaviour
{
    //reference to player
    //TODO: edit with GameManager later maybe?

    public AnimationStateController anim;
    public PlayerInput playerInput;
    public RobotData robotData;
    public float shootcooldown = 0.5f;
    public float punchLength = 0.2f;
    int punchdamage = 10;
    public GameObject playerRef;

    public BoxCollider punchCollider;

    private bool canshoot = true;

    private Health punchableObject;

    //creating object for punch cooldown ui element
    public PunchCD punchCD;

    private void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        shootcooldown = robotData.punchCooldown;
        punchdamage = robotData.punchDamage;

        //setting max value for punch Cool down UI element
        punchCD.setMaxCoolDown(shootcooldown);
    }

    public void punchInput()
    {
        if (canshoot)
        {
            //setting punch cooldown ui element to show its ready
            punchCD.setCurrentCDVal(0);

            Debug.Log("pow");
            StartCoroutine(Punch());
            canshoot = false;
            anim.Punch();
        }
    }

    IEnumerator Punch()
    {
        if (punchableObject != null)
        {
            punchableObject.punchHit(punchdamage);

        }

        yield return new WaitForSeconds(shootcooldown);
        punchCD.setCurrentCDVal(shootcooldown);
        canshoot = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Hitbox")
        {
            Debug.Log("object in range of punch");
            punchableObject = other.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hitbox")
        {
            punchableObject = null;
        }
    }
}
