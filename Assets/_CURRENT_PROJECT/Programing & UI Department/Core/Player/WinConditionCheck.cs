using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinConditionCheck : MonoBehaviour
{
    [SerializeField]
    private  TextMeshProUGUI _title; // Assign the Text object that is a child of this canvas as the reference

    private void Start()
    {
        _title.gameObject.SetActive(false);
    }

    public void DisplayWinScreenP1()
    {
        _title.text = "EPIC WIN P1!!!!";
        _title.gameObject.SetActive(true);
    }

    public void DisplayWinScreenP2()
    {
        _title.text = "EPIC WIN P2!!!!";
        _title.gameObject.SetActive(true);
    }

}
