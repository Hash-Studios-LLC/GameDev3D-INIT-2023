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
    public void MisileTrail(GameObject item)
    {
     GameObject trail = Instantiate(list[1], item.transform);
        trail.transform.position = item.transform.position;
        trail.transform.rotation = item.transform.rotation;
      //  trail.transform.LookAt(item.transform);
    }
}
