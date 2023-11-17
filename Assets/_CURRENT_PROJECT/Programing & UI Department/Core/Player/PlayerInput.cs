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
    bool p1Action = false;
    bool p2Action = false;
    private void Start()
    {
      
    }
    void Update()
    {
        
        if (!secondPlayer){
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
            if (Input.GetButton("Rocket") && gameObject.GetComponent<Robot_Initalization>().getRobotNum() != 1 && p2Action != true)
            {
                StartCoroutine(ActionCDp2());
                anim.Shoot();
            }
            if (Input.GetButton("Punch") && p2Action != true)
            {
                StartCoroutine(ActionCDp2());
                anim.Punch();
            }
        }
        else{
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("P2Horizontal"), 0f, Input.GetAxis("P2Vertical")));
            if (Input.GetButton("P2Rocket") && gameObject.GetComponent<Robot_Initalization>().getRobotNum() != 1&& p1Action!=true)
            {
                StartCoroutine(ActionCDp1());
                anim.Shoot();
            }
            if (Input.GetButton("P2Punch") && p1Action != true)
            {
                StartCoroutine(ActionCDp1());
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

    IEnumerator ActionCDp1()
    {
        p1Action = true;
        yield return new WaitForSeconds(0.5f);
        p1Action = false;
    }
    IEnumerator ActionCDp2()
    {
        p2Action = true;
        yield return new WaitForSeconds(0.5f);
        p2Action = false;
    }
}
