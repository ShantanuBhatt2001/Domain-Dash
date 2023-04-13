using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoredisplay : MonoBehaviour
{
    float playerscore;
    public Text display;
    public GameObject getscore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerscore = getscore.GetComponent<score>().returnscoretime();
        display.text = playerscore.ToString("0");
    }
}
