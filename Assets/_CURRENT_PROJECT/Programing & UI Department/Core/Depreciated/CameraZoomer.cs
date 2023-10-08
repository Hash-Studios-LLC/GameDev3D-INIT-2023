using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [Header("Dependencies")]
    public Camera cam;
    public CameraScript camScript;
    [Header("Options")]
    public float defaultFOV = 90;
    public float zoomStrength = 10;
    //public float minFOV = 90;
    //public float maxFOV = 90;
    void Update()
    {
        cam.fieldOfView = ((defaultFOV * camScript.averageDist) / zoomStrength);
        //if (Input.GetButton("Submit"))
        //{
        //    cam.fieldOfView = (defaultFOV * camScript.averageDist);
        //}
        //else
        //{
        //    cam.fieldOfView = (defaultFOV);
        //}
    }
}
