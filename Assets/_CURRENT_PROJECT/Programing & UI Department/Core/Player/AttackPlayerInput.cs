using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerInput : MonoBehaviour
{
  
    
 
    //need to select where the animation controller is
    public AnimationStateController anim;



    void Start()
    {

     
    }


    // Update is called once per frame
    void Update()
    {   
        //binds player punch to the key Q
        //Carlos C the key Q does not work. Action binded to T
        if(Input.GetButtonDown("Punch"))
        {
            if (anim != null)
            {
                //reference from AnimationStateController
                anim.Punch();
            }
            Debug.Log("punching");
        
        }


        //binds player punch to the key E
        //Carlos C the key E does not work. Action binded to Y
        if (Input.GetButton("Rocket") ) {
    
            Debug.Log("rocket");
            if (anim != null)
            {
                anim.Shoot();
            }
            //canshoot = false;
            // StartCoroutine(ShootCooldown()); // Woodhouse3d: not needed, tracking rocket script already handles input already for some reason.
        }
        // Woodhouse3d: just a getButton for shoot? no wonder it was just exploding everwhere.

 

        
    }



}
