using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreviewSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] fighters;
    [SerializeField] Camera previewCam;
    [SerializeField] TextMeshProUGUI fighterName;
    private int selectedIndex;
    private String[] names;

    private GameObject selectedFighter;
    void Start()
    {
        names = new string[] { "Dasher", "Juggernaut", "Tank", "Warrior" };
        selectedIndex = 0;
        selectedFighter = fighters[0];
        previewCam.transform.position = new Vector3(selectedFighter.transform.position.x, 549.907f, -6.041f);
        fighterName.text = names[selectedIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Previous()
    {
        if (selectedIndex == 0) return;
        selectedIndex--;
        selectedFighter = fighters[selectedIndex];
        previewCam.transform.position = new Vector3(selectedFighter.transform.position.x, 549.907f, -6.041f);
        fighterName.text = names[selectedIndex];
    }

    public void Next()
    {
        if (selectedIndex == fighters.Length - 1) return;
        selectedIndex++;
        selectedFighter = fighters[selectedIndex];
        previewCam.transform.position = new Vector3(selectedFighter.transform.position.x, 549.907f, -6.041f);
        fighterName.text = names[selectedIndex];
    }
}
