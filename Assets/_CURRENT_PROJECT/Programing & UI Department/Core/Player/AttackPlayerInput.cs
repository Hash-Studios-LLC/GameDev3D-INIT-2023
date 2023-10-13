using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerInput : MonoBehaviour
{
    //area in which attack happens
    private GameObject punchArea;
    private GameObject shootArea;

    private bool playerPunching = false;
    private bool playerShooting = false;
    
    private float timeToShoot = 1f;
    private float timerForShoot = 0f;

    private float timeToPunch = 0.25f;
    private float timerForPunch = 0f;


    private bool canshoot;

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
        if(Input.GetButtonDown("Punch")) {
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
        if(Input.GetButton("Rocket") && canshoot) {
            playerShoot();
            //canshoot = false;
           // StartCoroutine(ShootCooldown()); // Woodhouse3d: not needed, tracking rocket script already handles input already for some reason.
        }
        // Woodhouse3d: just a getButton for shoot? no wonder it was just exploding everwhere.

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


    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(timeToShoot);
        canshoot = true;
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
