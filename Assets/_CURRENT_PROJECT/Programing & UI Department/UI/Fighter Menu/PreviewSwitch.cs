using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Sprite[] fighters; //Hold preview images for each fighter
    [SerializeField] TextMeshProUGUI fighterName; //To be replaced with name of selected fighter
    [SerializeField] Image fighterPreview; //Image to display when selecting fighter
    private int selectedIndex; // Track the currently selected fighter image in the array
    private String[] names; //Names of the fighters to display when selected

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
}
