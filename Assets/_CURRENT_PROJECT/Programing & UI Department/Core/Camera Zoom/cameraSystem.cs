using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraSystem : MonoBehaviour
{
    [Header("Dependencies")]
    public CinemachineTargetGroup targetGroupScript;
    public CinemachineVirtualCamera cVirtualCamera;

    public float minFOV = 60f;
    public float maxFOV = 120f;
    public float zoomSpeed = 5f;

    // Camera System must be initialized by calling this function in other scripts.
    // Otherwise it will do nothing.
    public void InitializeCamera(GameObject[] players)
    {
        foreach (GameObject g in players){
            targetGroupScript.AddMember(g.transform,1,1);
        }

        cVirtualCamera.enabled = true;
    }
    /*
    private void Update()
    {
        if (cVirtualCamera == null || targetGroupScript == null)
        {
            Debug.LogError("Ensure the virtualCamera and targetGroup are assigned.");
            return;
        }

        // Get the bounding box that encapsulates all the targets in the target group
        Bounds boundingBox = targetGroupScript.BoundingBox;

        // Calculate the diagonal distance of the bounding box
        float distance = boundingBox.size.magnitude;

        // Map the distance to the FOV range
        float targetFOV = Mathf.Lerp(maxFOV, minFOV, distance / 150);

        // Smoothly interpolate towards the target FOV
        cVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cVirtualCamera.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        
    }*/
}

