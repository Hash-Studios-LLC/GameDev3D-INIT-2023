using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingsScene : MonoBehaviour
{
    List<string> resolutionList = new List<string>();
    List<string> graphicsQualityList = new List<string>();

    public TMP_Text currentResText;
    void Start()
    {   
        //to:do load current graphics quality in graphics quality label
    }

    
    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("SettingsScreen");
        // Call the functions to populate the lists
        //addResolutions(resolutionList);
        //addGraphicsQuality(graphicsQualityList);
    }

    
    public AudioMixer audioMixer;
    public void SetMenuVolume(float volume)//for the menu mixer for the menu audio slider
    {
        audioMixer.SetFloat("MenuVolume", volume);
    }

    public void SetGameVolume(float volume)// for the game mixer for the game audio slider
    {
        audioMixer.SetFloat("GameVolume", volume);
    }

    public void SetMusicVolume(float volume)// for the music mixer for the music audio slider
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    //increment resolution
    public void incrementResolution() //to do
    {
        
    }
    //to-do:decrement resolution
    //to-do:increment graphics quality
    //to-do:decrement graphics quality
    //to-do:enable post processing
    //to-do:go back button

    /*List<string> addResolutions(List<string> resolutionList) //returns a list of the resolution options 
    {
        Resolution[] resolutions = SettingsScreen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height;
            resolutionList.Add(option);
        }
        return resolutionList;
    }*/

    /*List<string> addGraphicsQuality(List<string> graphicsQualityList) // returns a list of the graphics quality options
    {
        graphicsQualityList.Add("placeholder1");
        graphicsQualityList.Add("placeholder2");
        graphicsQualityList.Add("placeholder3");
        graphicsQualityList.Add("placeholder4");
        graphicsQualityList.Add("placeholder5");
        graphicsQualityList.Add("placeholder6");
        return graphicsQualityList;
    }*/
}
