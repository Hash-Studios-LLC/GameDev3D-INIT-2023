using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C_ControlMenuScript : MonoBehaviour
{
    public Sprite[] playerControls;
    public Image imageToChange;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI controllerText;
    int playerInt = 0;
    int controllerInt = 0;

    public void checkForValue()
    {
        if(playerInt > 1)
        {
            playerInt = 0;
        }
        if(playerInt < 0)
        {
            playerInt = 1;
        }
        if (controllerInt > 1)
        {
            controllerInt = 0;
        }
        if (controllerInt < 0)
        {
            controllerInt = 1;
        }
        if (controllerInt == 0)
        {
            // show keyboard
            if(playerInt == 0)
            {
                // show player 1 keyboard
                imageToChange.sprite = playerControls[0];
                playerText.text = "Player 1";
                controllerText.text = "Keyboard";
            }
            else
            {
                // show player 2 keyboard
                imageToChange.sprite = playerControls[1];
                playerText.text = "Player 2";
                controllerText.text = "Keyboard";
            }
        }
        else
        {
            // show controller
            if (playerInt == 0)
            {
                // show player 1 controller
                imageToChange.sprite = playerControls[2];
                playerText.text = "Player 1";
                controllerText.text = "Controller";
            }
            else
            {
                // show player 2 controller
                imageToChange.sprite = playerControls[3];
                playerText.text = "Player 2";
                controllerText.text = "Controller";
            }
        }
    }

    public void nextPlayer()
    {
        playerInt++;
        checkForValue();
    }

    public void previousPlayer()
    {
        playerInt--;
        checkForValue();
    }

    public void nextController()
    {
        controllerInt++;
        checkForValue();
    }

    public void previousController()
    {
        controllerInt--;
        checkForValue();
    }
}
