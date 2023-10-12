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
        //SceneManager.LoadScene("Game");
    }
  
    //For the Settings button
    public void GoToSettings()
    {
        SceneManager.LoadScene("GameScene");
    }

    //For the Quit game button
    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    
}
