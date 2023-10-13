using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerInput : MonoBehaviour
{
    //area in which attack happens
    private GameObject punchArea = default;

    private bool playerPunching = false;
    
    private float timeToPunch = 0.25f;
    private float timera = 0f;

    void Start()
    {
        punchArea = transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {   
        //binds player punch to the key Q
        if(Input.GetKeyDown(KeyCode.Q)) {
            playerPunch();
        }


        if(playerPunching) {
            timera += Time.deltaTime;

            //resets the punch attack
            if(timera >= timeToPunch)
            {
                timera = 0;
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
