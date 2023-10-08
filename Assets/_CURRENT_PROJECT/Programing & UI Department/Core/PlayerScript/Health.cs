using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
  
    void Start()
    {
        // gets value from attributes 
      PlayerAttributes  att=GetComponent<PlayerAttributes>();
        health = att.playerHealth;

       
    }

    
}
