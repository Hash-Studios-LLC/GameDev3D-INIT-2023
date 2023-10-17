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
        if (other != null)
        {
            var health = other.GetComponent<Health>();
            health.getDamage(15);
            Debug.Log("i wanna be free");
        }
        }

}
