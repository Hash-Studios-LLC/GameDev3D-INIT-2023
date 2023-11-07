using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCD : MonoBehaviour
{
    public Slider rocketSlider;
    private bool isReady;

    /*
    void Update()
    {
        if (!isReady)
        {
            raiseSlider();
        }
        else
        {
            isReady = true;
        }
    }
    */

    public void setMaxCD(float CD)
    {
        rocketSlider.maxValue = CD;
        rocketSlider.value = CD;
    }

    public void setCurrentCDVal(float CD)
    {
        rocketSlider.value = CD;
    }

    public void resetCoolDown()
    {
        rocketSlider.value = 0;
        isReady = false;
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
