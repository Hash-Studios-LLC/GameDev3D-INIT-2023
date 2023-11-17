using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StockDisplay : MonoBehaviour
{
    private TextMeshProUGUI lives;
    private int pStocks;
    private int pNumber;
    [SerializeField]
    private bool secondPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform dash = transform.GetChild(0);
        Transform jugg = transform.GetChild(1);
        Transform tank = transform.GetChild(2);
        Transform warr = transform.GetChild(3);

        pStocks = PlayerPrefs.GetInt("Player-Lives", 1);

        if (secondPlayer)
        {
            pNumber = PlayerPrefs.GetInt("Player-2-Class", 0);
        }
        else
        {
            pNumber = PlayerPrefs.GetInt("Player-1-Class", 0);
        }
        

        dash.gameObject.SetActive(false);
        jugg.gameObject.SetActive(false);
        tank.gameObject.SetActive(false);
        warr.gameObject.SetActive(false);

        lives = GetComponentInChildren<TextMeshProUGUI>();

        switch (pNumber)
        {
            case 0:
                {
                    dash.gameObject.SetActive(true);
                    break;
                }
            case 1:
                {
                    jugg.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    tank.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    warr.gameObject.SetActive(true);
                    break;
                }
            default:
                {
                    break;
                }
        }

        if (secondPlayer)
        {
            lives.text = "X " + FindObjectOfType<Respawning>().getP2Stock();
        }
        else
        {
            lives.text = "X " + FindObjectOfType<Respawning>().getP1Stock();
        }

        
    }

    void Update()
    {
        if (secondPlayer)
        {
            lives.text = "X " + FindObjectOfType<Respawning>().getP2Stock();
        }
        else
        {
            lives.text = "X " + FindObjectOfType<Respawning>().getP1Stock();
        }
    }




}
