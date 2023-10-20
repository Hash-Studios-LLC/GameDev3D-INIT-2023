using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncher : MonoBehaviour
{
    //reference to player
    //TODO: edit with GameManager later maybe?

    public PlayerInput playerInput;
    public RobotData robotData;
    public float shootcooldown = 0.5f;
    public float punchLength = 0.2f;
    int punchdamage = 10;
    public GameObject playerRef;

    public BoxCollider punchCollider;

    private bool canshoot = true;

    private Health punchableObject;

    private void Start()
    {
        robotData = playerRef.GetComponent<Robot_Initalization>().rob;
        shootcooldown = robotData.punchCooldown;
        punchdamage = robotData.punchDamage;
    }

    public void punchInput()
    {
        if (canshoot)
        {
            Debug.Log("pow");
            StartCoroutine(Punch());
            canshoot = false;
        }
    }

    IEnumerator Punch()
    {
        if (punchableObject != null)
        {
            punchableObject.punchHit(punchdamage);

        }

        yield return new WaitForSeconds(shootcooldown);
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
