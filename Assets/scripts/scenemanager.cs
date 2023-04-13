

using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public float delay = 1f;
    public GameObject endgameui;
    private bool check=false;
    public void EndGame()
    {
        endgameui.SetActive(true);
        
        check = true;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    public void Quit()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public bool returncheck()
    {
        return check;
    }
}
