using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Initalization : MonoBehaviour
{

    public RobotData rob;
    [SerializeField]
    private bool isPlayer1;
    [SerializeField]
    private bool isPlayer2;
    [SerializeField]// only to test/ display accuracy
    private int robotNum;

  
    private int id;
    // Start is called before the first frame update
    void Awake()
    {
        if (isPlayer1)
            id = 1;
        if (isPlayer2)
            id = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void setRobot(RobotData rb)
    {
        rob = rb;
        // initializasion stuff
        setRobotModel(0);
    }**/
    public int getID()
    {
        Debug.Log("id= "+id);
        return id;
    }
   /*
    public void setRobotModel(int rob)
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
    } **/
    public void setRobotNum(int num)
    {
        robotNum = num;
    }
    public int getRobotNum()
    {
        return robotNum;
    }
}
