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

    void SetVolume(float volume)
    {
        Debug.Log(volume);
    }


    void changeResolution()
    {

    }

    List<string> addResolutions(List<string> resolutionList) //returns a list of the resolution options 
    {
        resolutionList.Add("1920 x 1080");
        resolutionList.Add("2560 x 1440");
        resolutionList.Add("3840 x 2160");
        resolutionList.Add("7680 x 4320");

        return resolutionList;
    }

    List<string> addGraphicsQuality(List<string> graphicsQualityList) // returns a list of the graphics quality options
    {
        graphicsQualityList.Add("Low");
        graphicsQualityList.Add("Medium");
        graphicsQualityList.Add("High");
        return graphicsQualityList;
    }
}
