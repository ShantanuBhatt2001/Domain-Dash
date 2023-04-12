using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoretext;
    public GameObject pause;
    float scoretime=0;
    private bool pausescore;
    public float multiply=1;
    // Update is called once per frame
    void Update()
    {

        pausescore = pause.GetComponent<scenemanager>().returncheck();
        if (!pausescore)
        {
            
            scoretime += Time.deltaTime*multiply;
            scoretext.text = scoretime.ToString("0");
            multiply += Time.deltaTime*0.1f;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
    public float returnscoretime()
    {
        return scoretime;
    }
}
