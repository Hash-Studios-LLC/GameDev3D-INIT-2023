using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconFollowCamera : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        cam = Camera.main.transform; // Assign MainCamera to this value
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward); // CZ: Stun icon will follow camera
    }
}
