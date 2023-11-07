using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class VFXList : MonoBehaviour
{
    
    public GameObject[] list;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    public void DeathExplosion(GameObject player)
    {
       
        Instantiate(list[0],player.transform.position,player.transform.rotation);
        
    }
    // Update is called once per frame

}
