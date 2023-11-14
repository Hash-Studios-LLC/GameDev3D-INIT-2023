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
     if ( player.GetComponent<Robot_Initalization>().getID()==1)
      Destroy(  Instantiate(list[2],player.transform.position,player.transform.rotation),2.0f);
      if (player.GetComponent<Robot_Initalization>().getID() == 2)
       Destroy(Instantiate(list[0], player.transform.position, player.transform.rotation), 2.0f);
    }
    // Update is called once per frame
    public void MisileExplosion(GameObject item)
    {
       
       var x= Instantiate(list[1], item.transform.position, item.transform.rotation);
        Destroy(x, 1f);
    }
}
