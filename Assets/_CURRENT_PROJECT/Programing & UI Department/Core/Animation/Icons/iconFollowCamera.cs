using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconFollowCamera : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
        cam = GameObject.Find("MainCamera").transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward); // CZ: Stun icon will follow camera
    }
}
