using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class C_PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string thisScene;
    public string mainMenuScene;

    public void reloadMap()
    {
        SceneManager.LoadScene(thisScene);
    }

    public void reloadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
