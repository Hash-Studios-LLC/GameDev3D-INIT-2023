using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public GameObject robotGroup;
    public AnimationStateController anim;
    public bool secondPlayer = false;
    public Vector3 playerMovementInput;
    // Update is called once per frame
    private void Start()
    {
      
    }
    void Update()
    {
        
        if (!secondPlayer){
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
            if (Input.GetButton("Rocket") && gameObject.GetComponent<Robot_Initalization>().getRobotNum() != 1)
            {
                anim.Shoot();
            }
            if (Input.GetButton("Punch"))
            {
                anim.Punch();
            }
        }
        else{
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("P2Horizontal"), 0f, Input.GetAxis("P2Vertical")));
            if (Input.GetButton("P2Rocket") && gameObject.GetComponent<Robot_Initalization>().getRobotNum() != 1)
            {
                anim.Shoot();
            }
            if (Input.GetButton("P2Punch") )
            {
                anim.Punch();
            }
        }
         IEnumerator DelayedComponentRetrieval()
        {
            // Wait for a short delay (e.g., 1 second) to ensure the GameObject is activated
            yield return new WaitForSeconds(0.1f);

            // Now, retrieve the component
            anim = robotGroup.GetComponentInChildren<AnimationStateController>();
        }

        }
    public void setAnimator(AnimationStateController x)
    {
        anim = x;
    }
    }
