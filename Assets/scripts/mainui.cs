using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class mainui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Play()
    {
        SceneManager.LoadScene("maingame");
    }
    public void Quit()
    {
        Application.Quit();
    }
}