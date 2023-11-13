using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HPbar : MonoBehaviour
{
    int maxHp;
    public Slider slider;
    public TextMeshProUGUI hp;
    public void setHealth(int health)
    {
        if (health < 0)
            health = 0;
        slider.value = health;
        hp.text = health.ToString() + "/" + maxHp.ToString();
    }

    public void setMaxHealth(int health)
    {
        maxHp = health;
        slider.maxValue = health;
        slider.value = health;
        hp.text =health.ToString()+"/" + health.ToString();
    }
}
