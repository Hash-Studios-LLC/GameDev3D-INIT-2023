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
    
    List<string> graphicsQualityList = new List<string>();
    int index = 0; // initialize index for resolution

    public TMP_Text currentResText;
    public string labelGraphicsQualityList;


    public void Start()
    {
        //SceneManager.LoadScene("SettingsScreen"); // this line is bugging out when running the scene
        // Call the functions to populate the lists
        Resolution[] resolutionList = Screen.resolutions;
        System.Diagnostics.Debug.WriteLine(resolutionList);
        addGraphicsQuality(graphicsQualityList);

        //change resolution
        void changeResolutionDown() //to do: make accesible for the buttons
        {
            //if the list is on the first position go to the last value in the list
            if (index == 0)
            {
                int final = resolutionList.Length - 1;
                //currentResText = ToString(resolutionList[final]);
                index = final;
            }
            //if the list is in a valid position on the list go back one resolution option
            else
            {
                //currentResText = ToString(resolutionList[index--]);
            }

        }

        void changeResolutionUp()  //to do: make accesible for the buttons
        {
            //if the list is in the last position restart the list
            if (index == resolutionList.Length - 1)
            {
                //currentResText = ToString(resolutionList[0]);
                index = 0;
            }
            //if the index of the list is in a valid position go forward on the list
            else
            {
                //currentResText = ToString(resolutionList[index++]);
            }


        }


        //to:do load current graphics quality in graphics quality label

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

    
    //to-do:increment graphics quality
    //to-do:decrement graphics quality
    //to-do:enable post processing

    List<string> addGraphicsQuality(List<string> graphicsQualityList) // returns a list of the graphics quality options
    {
        graphicsQualityList.Add("Low");
        graphicsQualityList.Add("Medium");
        graphicsQualityList.Add("High");
        return graphicsQualityList;
    }

    void changeGraphicsDown() 
    {
        //if the list is on the first position go to the last value in the list
        if (index == 0)
        {
            int final = graphicsQualityList.Count - 1;
            labelGraphicsQualityList = graphicsQualityList[final];
            index = final;
        }
        //if the list is in a valid position on the list go back one GQ option
        else
        {
            labelGraphicsQualityList = graphicsQualityList[index--];
        }

    }

    void changeGraphicsUp()
    {
        //if the list is in the last position restart the list
        if (index == graphicsQualityList.Count - 1)
        {
            labelGraphicsQualityList = graphicsQualityList[0];
            index = 0;
        }
        //if the index of the list is in a valid position go forward on the list
        else
        {
            labelGraphicsQualityList = graphicsQualityList[index++];
        }


    }
}
