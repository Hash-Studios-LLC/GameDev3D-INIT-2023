using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Initalization : MonoBehaviour
{

    public RobotData rob;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRobot(RobotData rb)
    {
        rob = rb;
        // initializasion stuff
        setRobotModel(0);
    }

    private void setRobotModel(int rob)
    {
        switch (rob)
        {
            case 0:
                // enable model 0, disable the rest
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

}
