using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    //TO-DO: Make the Start Screen functionalities:
    //For the Start game button
    public void StartGame()
    {

    }
  
    //For the Settings button
    public void GoToSettings()
    {

    }

    //For the Quit game button
    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    
}
