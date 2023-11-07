using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCD : MonoBehaviour
{
    public Slider rocketSlider;

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
    }
}
