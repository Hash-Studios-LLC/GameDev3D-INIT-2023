using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraDynamicPosition : MonoBehaviour
{
    public float deltaYRotation = 2f; //this just changes the distance the camera rotates per frame
    void Start()
    {
       /*TODO: Calculate midpoint posiiton in the map that level design gives using all objects in the scene
        * I don't think that we need to calculate position of all game objects in a scene
        *but I do think that calculating middle position through the main ground plane might helpo
        */
        //This is just so regardless of map loaded in the main menu it will always be in the middle
    }

    void Update()
    {
        //Spin Camera work.
        //NOTE: DO NOT USE THE CURRENT SCENE METHOD TO CHECK FOR THIS IT BREAKS IT COMPLETELY
        //I just used a while loop like an idiot..
        float angle = deltaYRotation * Time.deltaTime;
        transform.Rotate(0f, angle, 0f, Space.Self);
    }
}
