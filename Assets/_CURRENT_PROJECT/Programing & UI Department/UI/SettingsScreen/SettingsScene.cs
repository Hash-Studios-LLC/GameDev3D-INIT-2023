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

    private List<string> graphicsQualityList = new List<string>();

    public AudioMixer audioMixer;
    public TextMeshProUGUI resText;
    public TextMeshProUGUI graText;
    public string currGraphicsQuality;

    void Start()
    {
        resolutionList = Screen.resolutions;

        initializeResolutionList();
        initializeGraphicsList();

        resText = GameObject.Find("labelResolutionOption").GetComponent<TextMeshProUGUI>();
        graText = GameObject.Find("labelGraphicQualityOption").GetComponent<TextMeshProUGUI>();

        resText.GetComponent<TextMeshProUGUI>().text = Screen.width.ToString() + "x" + Screen.height.ToString();
        graText.GetComponent<TextMeshProUGUI>().text = QualitySettings.currentLevel.ToString();
        
    }

    void Update ()
    {
        resText.GetComponent<TextMeshProUGUI>().text = Screen.width.ToString() + "x" + Screen.height.ToString();
        
    }
    private void initializeResolutionList()
    {
        foreach (Resolution res in resolutionList)
        {
            resolutionListString.Add(res.width.ToString() + "x" + res.height.ToString());
        }
    }
    private void initializeGraphicsList()
    {
        graphicsQualityList.Add("Very low");
        graphicsQualityList.Add("Low");
        graphicsQualityList.Add("Medium");
        graphicsQualityList.Add("High");
        graphicsQualityList.Add("Very High");
        graphicsQualityList.Add("Ultra");
    }
        #region ChangeResolution
        public void changeResolutionUp() 
        {
            //string currentResText;
            string currentRes = Screen.width.ToString() + "x" + Screen.height.ToString();
            int index = resolutionListString.IndexOf(currentRes); //getting the index of the current resolution
            
            if (index == resolutionListString.Count-1 ) //if the list is in the first position restart the list
                {
                    index = 0;
                }
                //if the index of the list is in a valid position go up on the list
            else
                {
                    index +=1;
                }
            resolutionToSet = getResolutionWHhz(resolutionListString[index]); // gets item from the resolution list created earlier and returns 3 ints, width, height, refresh rate
            Screen.SetResolution(resolutionToSet[0], resolutionToSet[1], true); //setting the new resolution, the paramater true is a fullscreen boolean
            //currentResText = resolutionListString[index]; //this will be used to debug
            Debug.Log(resolutionToSet[0]);
            Debug.Log(resolutionToSet[1]);
        }

        public void changeResolutionDown() 
            {
                string currentResText;
                string currentRes = Screen.width.ToString() + "x" + Screen.height.ToString();
                int index = resolutionListString.IndexOf(currentRes); //getting the index of the current resolution
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
                Screen.SetResolution(resolutionToSet[0], resolutionToSet[1], true); //setting the new resolution, the paramater true is a fullscreen boolean
                currentResText = resolutionListString[index]; //this will be used to debug
                Debug.Log(currentResText);
                
            }
    

    public List<int> getResolutionWHhz(string inputString) // returns a list of 2 ints, width and height and refresh rate. this is to be used when changing the resolution up or down
    {
        //inputString should be something like "1920x1080"
        //string[] fullRes = inputString.Split(' ');  // splitting the string by space, we only want the 1920x1080 and 144hz aka the first element and third element
        //string wh = fullRes[0]; //getting the first element only for the resolution width and height
        
        string[] widthheight = inputString.Split('x');
        int width = int.Parse(widthheight[0]);
        int height = int.Parse(widthheight[1]);

        //string hz = fullRes[2]; //getting the third element which is the refresh rate 144hz in the example but we only want the number
        //string numericPart = new string(hz.TakeWhile(char.IsDigit).ToArray());

        //int hzNum = int.Parse(numericPart);
        List<int> fullResInt = new List<int>();
        fullResInt.Add(width);
        fullResInt.Add(height);
        //fullResInt.Add(hzNum);
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
    
    #region ChangeGraphics

    public void changeGraphicsDown() 
    {
        
        int index = graphicsQualityList.IndexOf(currGraphicsQuality);
        //if the list is on the first position go to the last value in the list
        if (index == 0)
        {
            index = graphicsQualityList.Count - 1;
        }
        //if the list is in a valid position on the list go back one GQ option
        else
        {
            index -= 1;
        }

        currGraphicsQuality = graphicsQualityList[index];
        QualitySettings.SetQualityLevel(index);
    }

    public void changeGraphicsUp()
    {
        
        int index = graphicsQualityList.IndexOf(currGraphicsQuality);
        //if the list is on the last position go to the last value in the list
        if (index == graphicsQualityList.Count -1 )
        {
            index = 0;
        }
        //if the list is in a valid position on the list go back one GQ option
        else
        {
            index += 1;
        }

        currGraphicsQuality = graphicsQualityList[index];
        QualitySettings.SetQualityLevel(index);
    }
    #endregion
}
