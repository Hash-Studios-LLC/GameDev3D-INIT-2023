using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_RealPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") || Input.GetButtonDown("P2Pause"))
        {
            isPaused = !isPaused;
            pauseMenu.gameObject.SetActive(isPaused);
            if(isPaused == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void removePause()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
