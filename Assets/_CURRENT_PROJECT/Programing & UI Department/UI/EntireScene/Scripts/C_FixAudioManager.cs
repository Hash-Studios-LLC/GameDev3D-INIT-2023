using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FixAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager audioManagerScript = FindObjectOfType<AudioManager>();
        if (audioManagerScript != null)
        {
            audioManagerScript.gameObject.SetActive(true);
        }
    }
}
