using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchCD : MonoBehaviour
{
    public Slider punchSlider;

    void Update()
    {
        if (punchSlider.value > 0)
        {
            punchSlider.value -= Time.deltaTime;

        }

    }


    public void setMaximun(float cd)
    {
       punchSlider.maxValue = cd;
    }



    public void resetCoolDown()
    {
        punchSlider.value = punchSlider.maxValue;

        Debug.Log("gun CD is 0 now...");
       
    }
}
