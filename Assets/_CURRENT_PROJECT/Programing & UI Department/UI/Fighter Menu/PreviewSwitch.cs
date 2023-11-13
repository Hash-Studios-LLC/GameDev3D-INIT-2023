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
    [SerializeField] Image fighterPreview; //Image to display when selecting fighter
    private int selectedIndex; // Track the currently selected fighter image in the array
    private String[] names; //Names of the fighters to display when selected
    public Button ContinueButton;
    public C_MenuScript menuScript;
    [TextArea] public string characterDescriptions;
    public float characterStats_Speed;
    public float characterStats_RocketDamage;
    public float characterStats_RocketCooldown;
    public float characterStats_PunchDamage;
    public float characterStats_PunchCooldown;
    public Slider[] characterStats_Sliders;

    private Sprite selectedFighter;
    void Start()
    {
        names = new string[] { "Dasher", "Juggernaut", "Tank", "Warrior" };
        selectedIndex = 0;
        selectedFighter = fighters[0];
        fighterPreview.sprite = selectedFighter;
        fighterName.text = names[selectedIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If at index 0, loop around to end of array and show the last fighter
    public void Previous()
    {
        if (selectedIndex == 0) selectedIndex = fighters.Length - 1;
        else selectedIndex--;
        selectedFighter = fighters[selectedIndex];
        fighterPreview.sprite = selectedFighter;
        fighterName.text = names[selectedIndex];
    }

    //If at last index, loop around to front of array and show the first fighter
    public void Next()
    {
        if (selectedIndex == fighters.Length-1) selectedIndex = 0;
        else selectedIndex++;
        selectedFighter = fighters[selectedIndex];
        fighterPreview.sprite = selectedFighter;
        fighterName.text = names[selectedIndex];
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
