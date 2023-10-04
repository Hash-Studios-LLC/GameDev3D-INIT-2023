using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraSystem : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject[] players;
    public CinemachineTargetGroup targetGroupScript;

    private void Awake()
    {
        foreach (GameObject g in players){
            targetGroupScript.AddMember(g.transform,1,1);
        }
        
    }
}
