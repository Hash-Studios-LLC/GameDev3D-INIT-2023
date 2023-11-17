using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCD : MonoBehaviour
{
    public Slider rocketSlider;
    [SerializeField]
    private bool usingRocket;





    void Update()
    {
        if (rocketSlider.value>0 )
        {
            rocketSlider.value -= Time.deltaTime;
           
        }
        
    }


    public void setMaximun(float cd)
    {
        rocketSlider.maxValue = cd;
    }

 

    public void resetCoolDown()
    {
        rocketSlider.value = rocketSlider.maxValue;
     
        Debug.Log("gun CD is 0 now...");
    
    }
    /*
    IEnumerator raiseSlider()
    {

        while(rocketSlider.value > rocketSlider.maxValue)
        {
            rocketSlider.value +=  0;
        }

        return null;
    }
    */
}
