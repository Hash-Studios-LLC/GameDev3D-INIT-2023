using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject graphics;

    void Awake()
    {   
        //make it so spawnpoints are invisible
        graphics.SetActive(false);
    }
}
