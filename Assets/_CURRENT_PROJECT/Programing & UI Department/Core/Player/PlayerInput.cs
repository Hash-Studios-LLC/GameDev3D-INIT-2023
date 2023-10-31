using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   

    public AnimationStateController anim;
    public bool secondPlayer = false;
    public Vector3 playerMovementInput;
    // Update is called once per frame
    void Update()
    {
        if (!secondPlayer){
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
            if (Input.GetButton("Rocket"))
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
            if (Input.GetButton("P2Rocket"))
            {
                anim.Shoot();
            }
            if (Input.GetButton("P2Punch"))
            {
                anim.Punch();
            }
        }


    }
}
