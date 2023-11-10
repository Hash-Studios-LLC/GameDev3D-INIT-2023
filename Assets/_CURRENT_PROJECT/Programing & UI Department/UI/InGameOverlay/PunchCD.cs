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
        Debug.Log("Punch CD slider was changed...");
    }

    public void resetCoolDown()
    {
        punchSlider.value = 0;
        Debug.Log("Punch CD is 0...");
    }
}
