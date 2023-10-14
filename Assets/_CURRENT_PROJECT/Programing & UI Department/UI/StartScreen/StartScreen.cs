using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //TO-DO: Make the Start Screen functionalities:
    //For the Start game button

    public void StartGame()
    {
        Debug.Log("Loading to fighting menu...");

        SceneManager.LoadScene("Fighter Menu");
    }
  
    //For the Settings button
    public void GoToSettings()
    {
        Debug.Log("Loading to setting screen...");

        SceneManager.LoadScene("SettingsScreen");
    }

    //For the Quit game button
    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    
}
