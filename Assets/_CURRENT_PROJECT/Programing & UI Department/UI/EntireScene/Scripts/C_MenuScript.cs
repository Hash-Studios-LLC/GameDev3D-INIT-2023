using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class C_MenuScript : MonoBehaviour
{
    public int mapSelection = -1;
    public int mapSelectedIndex = -1;
    public bool mapSelected = false;
    public int player_1_classSelection;
    public int player_2_classSelection;
    public Button MapContinueButton; // Assign your continue button here
    public CanvasGroup continueButtonCanvasGroup; // Assign your canvas group here
    public string[] sceneNames;
    public C_MapToSelect[] mapScripts;
    public int lives = -1;
    public TextMeshProUGUI livesText;
    public ScrollRect scrollRect_P1;
    public ScrollRect scrollRect_P2;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager audioManagerScript = FindObjectOfType<AudioManager>();
        if(audioManagerScript != null)
        {
            audioManagerScript.gameObject.SetActive(false);
        }
        MapContinueButton.interactable = false;
        continueButtonCanvasGroup.alpha = 0.5f;
        lives = 3;
        livesText.text = "Lives: " + lives;
        resetScrollP1();
        resetScrollP2();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private IEnumerator RunFunctionAfterDelay(float delayInSeconds, System.Action functionToRun)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Call the function after the delay
        functionToRun.Invoke();
    }

    public void SendCustomEvenDelayedSeconds(System.Action functionToRun, float delayInSeconds)
    {
        StartCoroutine(RunFunctionAfterDelay(delayInSeconds, functionToRun));
    }

    public void LoadMap_Delayed()
    {
        SendCustomEvenDelayedSeconds(LoadMap, 0.5f);
    }

    public void SelectMap(int mapIndex)
    {

        if (mapIndex != mapSelection)
        {
            // New map selected
            mapSelection = mapIndex;
            MapContinueButton.interactable = true;
            continueButtonCanvasGroup.alpha = 1;

            // Show the newly selected map
            PlayAnimationForMap(mapIndex, "Show");

            // Hide the previously selected map, if any
            if (mapSelected) // Check if a map was previously selected
            {
                PlayAnimationForMap(mapSelectedIndex, "Hide");
            }

            // Update the selected map index and state
            mapSelectedIndex = mapIndex;
            mapSelected = true;
        }
        else
        {
            // Same map reselected, so hide it
            mapSelection = -1;
            MapContinueButton.interactable = false;
            continueButtonCanvasGroup.alpha = 0.5f;

            PlayAnimationForMap(mapIndex, "Hide");

            // Update the selected state
            mapSelected = false;
        }
    }

    public void resetMap()
    {
        if(mapSelection != -1)
        {
            int temp = mapSelection;
            mapSelection = -1;
            MapContinueButton.interactable = false;
            continueButtonCanvasGroup.alpha = 0.5f;

            PlayAnimationForMap(temp, "Hide");

            // Update the selected state
            mapSelected = false;
        }
    }

    private void PlayAnimationForMap(int mapIndex, string animationName)
    {
        foreach (C_MapToSelect mapScript in mapScripts)
        {
            if (mapIndex == mapScript.mapToSelect)
            {
                mapScript.animator.Play(animationName);
                mapScript.isShowing = animationName == "Show";
            }
        }
    }

    public void LoadMap()
    {
        if (mapSelection != -1)
        {
            SceneManager.LoadScene(sceneNames[mapSelection]);
        }
    }

    //If at index 0, loop around to end of array and show the last fighter
    public void PreviousLives()
    {
        if (lives <= 1)
        {
            lives = 99;
            livesText.text = "Lives: " + lives;
        }
        else
        {
            lives--;
            livesText.text = "Lives: " + lives;
        }
    }

    //If at last index, loop around to front of array and show the first fighter
    public void NextLives()
    {
        if (lives >= 99)
        {
            lives = 1;
            livesText.text = "Lives: " + lives;
        }
        else
        {
            lives++;
            livesText.text = "Lives: " + lives;
        }
    }

    public void SaveLives()
    {
        lives = Mathf.Clamp(lives, 1, 99);
        PlayerPrefs.SetInt("Player-Lives", lives);
        PlayerPrefs.Save();
    }

    public void resetScrollP1()
    {
        scrollRect_P1.verticalNormalizedPosition = 1f;
    }

    public void resetScrollP2()
    {
        scrollRect_P2.verticalNormalizedPosition = 1f;
    }
}
