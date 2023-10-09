using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    List<string> resolutionList = new List<string>();
    List<string> graphicsQualityList = new List<string>();

    void Start()
    {
        // Call the functions to populate the lists
        addResolutions(resolutionList);
        addGraphicsQuality(graphicsQualityList);
    }

    List<string> addResolutions(List<string> resolutionList) //returns a list of the resolution options 
    {
        resolutionList.Add("placeholder1");
        resolutionList.Add("placeholder2");
        resolutionList.Add("placeholder3");
        resolutionList.Add("placeholder4");
        resolutionList.Add("placeholder5");
        resolutionList.Add("placeholder6");
        return resolutionList;
    }

    List<string> addGraphicsQuality(List<string> graphicsQualityList) // returns a list of the graphics quality options
    {
        graphicsQualityList.Add("placeholder1");
        graphicsQualityList.Add("placeholder2");
        graphicsQualityList.Add("placeholder3");
        graphicsQualityList.Add("placeholder4");
        graphicsQualityList.Add("placeholder5");
        graphicsQualityList.Add("placeholder6");
        return graphicsQualityList;
    }
}
