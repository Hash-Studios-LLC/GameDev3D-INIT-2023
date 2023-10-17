using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingsScene : MonoBehaviour
{
    List<string> resolutionListString = new List<string>();
    private Resolution[] resolutionList;
    private List<int> resolutionToSet;
    public AudioMixer audioMixer;
    
    public void Start()
    {
        resolutionList = Screen.resolutions;
        initializeResolutionList();
    }
    private void initializeResolutionList()
    {
        foreach (Resolution res in resolutionList)
        {
            resolutionListString.Add(res.width.ToString() + "x" + res.height.ToString() + " @ " + res.refreshRate.ToString());
        }
    }
        #region ChangeResolution
        public void changeResolutionUp()  //to do: make accesible for the buttons
        {
            string currentResText;
            string currentRes = Screen.currentResolution.width.ToString() + "x" + Screen.currentResolution.height.ToString() + " @ " + Screen.currentResolution.refreshRate.ToString();
            int index = resolutionListString.IndexOf(currentRes); //getting the index of the current resolution
            foreach (Resolution res in resolutionList)
            {
                resolutionListString.Add(res.width.ToString() +"x" + res.height.ToString() + " @ " + res.refreshRate.ToString());
            }
            
            if (index == resolutionListString.Count - 1) //if the list is in the last position restart the list
            {
                index = 0;
                
            }
                //if the index of the list is in a valid position go forward on the list
            else
            {
                index +=1;
            }
            resolutionToSet = getResolutionWHhz(resolutionListString[index]); // gets first item from the resolution list created earlier and returns 3 ints, width, height, refresh rate
            Screen.SetResolution(resolutionToSet[0], resolutionToSet[1], true, resolutionToSet[2]); //setting the new resolution and refresh rate
            currentResText = resolutionListString[index]; //this will be used to display the new resolution in the unity object
            Debug.Log(currentResText);

        }
        public void changeResolutionDown() //to do: make accesible for the buttons
            {
                string currentResText;
                string currentRes = Screen.currentResolution.width.ToString() + "x" + Screen.currentResolution.height.ToString() + " @ " + Screen.currentResolution.refreshRate.ToString();
                int index = resolutionListString.IndexOf(currentRes); //getting the index of the current resolution
                foreach (Resolution res in resolutionList)
                {
                    resolutionListString.Add(res.width.ToString() +"x" + res.height.ToString() + " @ " + res.refreshRate.ToString());
                }
            
                if (index == 0 ) //if the list is in the first position restart the list
                {
                    index = resolutionListString.Count - 1;
                }
                //if the index of the list is in a valid position go back on the list
                else
                {
                    index -=1;
                }
                resolutionToSet = getResolutionWHhz(resolutionListString[index]); // gets item from the resolution list created earlier and returns 3 ints, width, height, refresh rate
                Screen.SetResolution(resolutionToSet[0], resolutionToSet[1], true, resolutionToSet[2]); //setting the new resolution and refresh rate
                currentResText = resolutionListString[index]; //this will be used to display the new resolution in the unity object
                Debug.Log(currentResText);

            }
    

    public List<int> getResolutionWHhz(string inputString) // returns a list of 3 ints, width and height and refresh rate. this is to be used when changing the resolution up or down
    {
        //inputString should be something like "1920x1080 @ 144hz"
        string[] fullRes = inputString.Split(' ');  // splitting the string by space, we only want the 1920x1080 and 144hz aka the first element and third element
        string wh = fullRes[0]; //getting the first element only for the resolution width and height
        
        string[] widthheight = wh.Split('x');
        int width = int.Parse(widthheight[0]);
        int height = int.Parse(widthheight[1]);

        string hz = fullRes[2]; //getting the third element which is the refresh rate 144hz in the example but we only want the number
        string numericPart = new string(hz.TakeWhile(char.IsDigit).ToArray());

        int hzNum = int.Parse(numericPart);
        List<int> fullResInt = new List<int>();
        fullResInt.Add(width);
        fullResInt.Add(height);
        fullResInt.Add(hzNum);
        return fullResInt; 
    }
    #endregion

    #region audioMixer
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
    #endregion
    
    /*List<string> addGraphicsQuality(List<string> graphicsQualityList) // returns a list of the graphics quality options
    {
        graphicsQualityList.Add("Low");
        graphicsQualityList.Add("Medium");
        graphicsQualityList.Add("High");
        return graphicsQualityList;
    }*/
    #region ChangeGraphics
    /*void changeGraphicsDown() 
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

    }*/

    /*void changeGraphicsUp()
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


    }*/
    #endregion
}
