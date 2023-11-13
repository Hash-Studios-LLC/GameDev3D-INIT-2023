using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinConditionCheck : MonoBehaviour
{
    [SerializeField]
    private  TextMeshProUGUI _title; // Assign the Text object that is a child of this canvas as the reference
    public TextMeshProUGUI winnerText;
    private void Start()
    {
        _title.gameObject.SetActive(false);
    }

    public void DisplayWinScreenP1()
    {
        _title.text = "EPIC WIN P1!!!!";
        ShowUi();
        winnerText.text = "PLAYER 1 WON";
        winnerText.color = Color.blue;
    }

    public void DisplayWinScreenP2()
    {
        _title.text = "EPIC WIN P2!!!!";
        ShowUi();
        winnerText.text = "PLAYER 2 WON";
        winnerText.color = Color.red;
    }

    private void ShowUi()
    {
        foreach (Transform child in transform)
        {
            // Enable the child GameObject
            child.gameObject.SetActive(true);
        }
    }
}
