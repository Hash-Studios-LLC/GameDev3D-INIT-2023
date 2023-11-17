using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinConditionCheck : MonoBehaviour
{
    [SerializeField]
    private  TextMeshProUGUI _title; // Assign the Text object that is a child of this canvas as the reference
    public TextMeshProUGUI winnerText;
    public GameObject cameraWinner;

    private void Start()
    {
        _title.gameObject.SetActive(false);

    }

    public void DisplayWinScreenP1(Transform winner)
    {
        
        _title.text = "EPIC WIN P1!!!!";
        ShowUi();
        winnerText.text = "PLAYER 1 WON";
        winnerText.color = Color.red;
        cameraWinner.SetActive(true);
        cameraWinner.GetComponent<VictoryManager>().Victory(winner);
    }

    public void DisplayWinScreenP2(Transform winner)
    {
       
        _title.text = "EPIC WIN P2!!!!";
        ShowUi();
        winnerText.text = "PLAYER 2 WON";
        winnerText.color = Color.blue;
        cameraWinner.SetActive(true);
        cameraWinner.GetComponent<VictoryManager>().Victory(winner);
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
