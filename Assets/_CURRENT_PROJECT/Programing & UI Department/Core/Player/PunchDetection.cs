using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetection : MonoBehaviour
{
   // don't apply the script to player or model,it goes with punchCollider 
  
   public RobotData robot;
   
    void Start()
    {
        robot = GetComponentInParent<Robot_Initalization>().rob;
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
            health.punchHit(robot.punchDamage);//sends damage
            Debug.Log("hit confirmed");
        }
        }

}
