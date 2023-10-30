using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1;
    [SerializeField]
    private bool isPlayer2;



    private int id;
    void Start()
    {
        if (isPlayer1)
            id = 1;
        if (isPlayer2)
            id = 2;
    }

  public int getId()
    {
        return id;
    }
}
