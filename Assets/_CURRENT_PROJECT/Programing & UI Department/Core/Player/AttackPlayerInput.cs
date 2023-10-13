using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerInput : MonoBehaviour
{
    //area in which attack happens
    private GameObject punchArea = default;
    private GameObject shootArea = default;

    private bool playerPunching = false;
    private bool playerShooting = false;
    
    private float timeToShoot = 0.15f;
    private float timerForShoot = 0f;

    private float timeToPunch = 0.25f;
    private float timerForPunch = 0f;

    void Start()
    {
        if (transform.childCount > 0)
        {
            punchArea = transform.GetChild(0).gameObject;
            shootArea = transform.GetChild(0).gameObject;
        }

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

        //binds player punch to the key E
        if(Input.GetButton("Rocket")) {
            playerShoot();
        }


        if(playerShooting) {
            timerForShoot += Time.deltaTime;

            //resets the shoot attack
            if(timerForShoot >= timeToShoot)
            {
                timerForShoot = 0;
                playerShooting = false;
                shootArea.SetActive(playerShooting);
            }
        }

        
    }

    private void playerPunch()
    {
        playerPunching = true;
        punchArea.SetActive(playerPunching);
    }

    private void playerShoot()
    {
        playerShooting = true;
        shootArea.SetActive(playerShooting);
    }
}
