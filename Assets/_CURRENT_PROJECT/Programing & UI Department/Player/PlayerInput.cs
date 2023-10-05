using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool secondPlayer = false;
    public Vector3 playerMovementInput;

    // Update is called once per frame
    void Update()
    {
        if (!secondPlayer){
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        }else{
            playerMovementInput = Vector3.Normalize(new Vector3(Input.GetAxis("P2Horizontal"), 0f, Input.GetAxis("P2Vertical")));
        }

    }
}
