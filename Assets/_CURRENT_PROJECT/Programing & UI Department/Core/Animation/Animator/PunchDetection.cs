using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetection : MonoBehaviour
{
   
   public RobotData robot;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
            var health = other.GetComponent<Health>();//gets component
            health.getDamage(robot.punchDamage);//sends damage
            Debug.Log("hit confirmed");
        }
        }

}
