using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRobot : MonoBehaviour
{
    public Robot_Initalization robot;
    // Start is called before the first frame update
    void Start()
    {
        robot=GetComponentInParent<Robot_Initalization>();
        selectRobot(robot.getRobotNum());
    }
    // the child are structured like an array so it starts at 0
private void selectRobot(int num)
    {
        Transform childTransform = this.gameObject.transform.GetChild(num);
        childTransform.gameObject.SetActive(true);
    }
}
