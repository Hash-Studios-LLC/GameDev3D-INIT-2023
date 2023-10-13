using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static Boolean isPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    /*
     * Resume() method obviously unfreezes time and allows players to continue the gameplay.
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    /*
     * Pause() method freezes time and pauses the gameplay
     * also sets boolean value isPaused = true
     */
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /*
     * Quit() method closes the entire application
     */
    public void Quit()
    {
        Debug.Log("Quitting game :) I hope there was no rage quitting");
        Application.Quit();
    }

    /*
     * ExitToMenu() method ends the game and returns player to main menu
     * Cannot route players to main menu yet due to undetermined scene structuring pratices.
     * I don't know what structure the department lead is gonna go with, so until then this script is incomplete.
     */
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Going back to Menu, I always forget to set the rules to stock smh");
        //SceneManager.LoadScene("GameScene");
    }
}
