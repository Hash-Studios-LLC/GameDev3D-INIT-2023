using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraSystem : MonoBehaviour
{
    [Header("Dependencies")]
    public CinemachineTargetGroup targetGroupScript;
    public CinemachineVirtualCamera cVirtualCamera;



    // Camera System must be initialized by calling this function in other scripts.
    // Otherwise it will do nothing.
    public void InitializeCamera(GameObject[] players)
    {
        foreach (GameObject g in players){
            targetGroupScript.AddMember(g.transform,1,1);
        }

        cVirtualCamera.enabled = true;
    }
}
