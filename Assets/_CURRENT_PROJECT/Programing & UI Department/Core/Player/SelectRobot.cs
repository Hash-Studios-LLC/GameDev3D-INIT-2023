using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRobot : MonoBehaviour
{
    [Header("Colors")]

    [SerializeField] private Color playerOneColor = Color.red;
    [SerializeField] private Color playerTwoColor = Color.blue;


    [Header("Robot Parts")]

    public Robot_Initalization robot;
    public PlayerInput playerInput;
   
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
        Transform mesh = childTransform.GetChild(0);
        Material material = mesh.gameObject.GetComponent<Renderer>().material;
        Shader material2 = mesh.gameObject.GetComponent<Renderer>().material.shader;

        int propertyID = Shader.PropertyToID("_Player_Color");
        if (robot.getID() == 1)
        {
            material.SetColor(propertyID, playerOneColor);
        }
        else
        {
            material.SetColor(propertyID, playerTwoColor);
        }
        childTransform.gameObject.SetActive(true);
        

        playerInput.setAnimator( childTransform.GetComponent<AnimationStateController>());
    }
}
