using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getCurrentRes : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text currentRes;
    void Start()
    {
        currentRes = GetComponent<TMP_Text>();
        currentRes.text = Screen.width.ToString() + "x" + Screen.height.ToString();
    }

    // Update is called once per frame
}
