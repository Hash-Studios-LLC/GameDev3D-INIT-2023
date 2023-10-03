using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour 
{
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        // gets value from attributes
        PlayerAttributes att =GetComponent<PlayerAttributes>();
          speed = att.playerSpeed;

    }

  
}
