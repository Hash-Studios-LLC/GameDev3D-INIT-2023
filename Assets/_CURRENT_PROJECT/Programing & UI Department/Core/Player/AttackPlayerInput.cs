using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerInput : MonoBehaviour
{
    //area in which attack happens
    private GameObject punchArea = default;

    private bool playerPunching = false;
    private bool playerShooting = false;
    
    private float timeToShoot = 0.15f;
    private float timerForShoot = 0f;

    private float timeToPunch = 0.25f;
    private float timerForPunch = 0f;

    void Start()
    {
        punchArea = transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {   
        //binds player punch to the key Q
        if(Input.GetButton("Punch")) {
            playerPunch();
        }


        if(playerPunching) {
            timerForPunch += Time.deltaTime;

            //resets the punch attack
            if(timerForPunch >= timeToPunch)
            {
                timerForPunch = 0;
                playerPunching = false;
                punchArea.SetActive(playerPunching);
            }
        }

        
    }

    private void playerPunch()
    {
        playerPunching = true;
        punchArea.SetActive(playerPunching);
    }
}
