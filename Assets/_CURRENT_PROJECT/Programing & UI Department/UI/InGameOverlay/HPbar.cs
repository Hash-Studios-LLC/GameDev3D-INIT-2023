using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{

    public Slider slider;

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
