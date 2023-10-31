using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchCD : MonoBehaviour
{
    public Slider punchSlider;

    public void setMaxCoolDown(float coolDown)
    {
        punchSlider.maxValue = coolDown;
        punchSlider.value = coolDown;
    }

    public void setCurrentCDVal(float CD)
    {
        punchSlider.value = CD;
    }

    public void resetCoolDown()
    {
        punchSlider.value = 0;
    }
}
