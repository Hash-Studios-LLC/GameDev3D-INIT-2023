using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PreviewSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public int forWhichPlayer;
    [SerializeField] Sprite[] fighters; //Hold preview images for each fighter
    [SerializeField] TextMeshProUGUI fighterName; //To be replaced with name of selected fighter
    public TextMeshProUGUI fighterDescription;
    [SerializeField] Image fighterPreview; //Image to display when selecting fighter
    private int selectedIndex; // Track the currently selected fighter image in the array
    private String[] names; //Names of the fighters to display when selected
    private float[] health;
    private float[] speed;
    private float[] punchDamage;
    private float[] punchCooldown;
    private float[] rocketDamage;
    private float[] rocketCooldown;
    public Button ContinueButton;
    public C_MenuScript menuScript;
    [TextArea] public string [] characterDescriptions;
    public Slider[] characterStats_Sliders;

    private Sprite selectedFighter;
    void Start()
    {
        selectedIndex = 3;
        names = new string[] { "Dasher", "Juggernaut", "Tank", "Warrior" };
        health = new float[] { 0.7f, 1.5f, 1.75f, 1f }; // out of 2
        speed = new float[] { 1.25f, 1.30f, 0.75f, 1f }; // out of 2
        punchDamage = new float[] { 1f, 1.5f, 4f, 2.5f }; // out of 5
        punchCooldown = new float[] { 0.5f, 0.25f, 1.5f, 1f }; // out of 2
        rocketDamage = new float[] { 2.5f, 0f, 1f, 1.5f }; // out of 3
        rocketCooldown = new float[] { 1.5f, 0f, 1f, 1f }; // out of 2
        //punchDamage = new float[] { , };
        updateValues();
    }

    public void resetValues()
    {
        selectedIndex = 3;
        updateValues();
    }

    public void updateValues()
    {
        selectedFighter = fighters[selectedIndex];
        fighterPreview.sprite = selectedFighter;
        fighterName.text = names[selectedIndex];

        fighterDescription.text = characterDescriptions[selectedIndex];
        characterStats_Sliders[0].value = health[selectedIndex];
        characterStats_Sliders[1].value = speed[selectedIndex];
        characterStats_Sliders[2].value = rocketDamage[selectedIndex];
        characterStats_Sliders[3].value = rocketCooldown[selectedIndex];
        characterStats_Sliders[4].value = punchDamage[selectedIndex];
        characterStats_Sliders[5].value = punchCooldown[selectedIndex];
    }

    //If at index 0, loop around to end of array and show the last fighter
    public void Previous()
    {
        if (selectedIndex == 0) selectedIndex = fighters.Length - 1;
        else selectedIndex--;
        updateValues();
    }

    //If at last index, loop around to front of array and show the first fighter
    public void Next()
    {
        if (selectedIndex == fighters.Length-1) selectedIndex = 0;
        else selectedIndex++;
        updateValues();
    }

    public void Continue()
    {
        ContinueButton.interactable = false;
        if(forWhichPlayer == 0)
        {
            menuScript.player_1_classSelection = selectedIndex;
            PlayerPrefs.SetInt("Player-1-Class", selectedIndex);
            PlayerPrefs.Save();
            menuScript.LoadMap_Delayed();
        }
        else
        {
            menuScript.player_2_classSelection = selectedIndex;
            PlayerPrefs.SetInt("Player-2-Class", selectedIndex);
            PlayerPrefs.Save();
        }
    }
}
