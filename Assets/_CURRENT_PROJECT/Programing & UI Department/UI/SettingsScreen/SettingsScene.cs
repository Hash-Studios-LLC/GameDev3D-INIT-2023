using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{
    List<string> resolutionList = new List<string>();
    List<string> graphicsQualityList = new List<string>();

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("SettingsScreen");
        // Call the functions to populate the lists
        addResolutions(resolutionList);
        addGraphicsQuality(graphicsQualityList);
    }

    public static void SetVolume(float volume)
    {
        Debug.Log(volume);
    }

    List<string> addResolutions(List<string> resolutionList) //returns a list of the resolution options 
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height;
            resolutionList.Add(option);
        }
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
