
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class tiaozhuan : MonoBehaviour
{
     
    public void Startgame()
    {
        SceneManager.LoadScene("fighter");
    }
    public void fblqh()
    {
        Screen.SetResolution(720, 1024, FullScreenMode.Windowed);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void yiming()
    {
        SceneManager.LoadScene("rwxuanze");

    }
}
