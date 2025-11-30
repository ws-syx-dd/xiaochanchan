using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homefunction : MonoBehaviour
{
    public GameObject GongGaofunction;
    public GameObject GongZuoFunction;
    private bool qr;
    // Start is called before the first frame update
    void Start()
    {
        qr=false;
    }
    public void GongGaoIn()
    {
        if (!qr)
        {
            GongGaofunction.SetActive(true);
            qr = true;
        }
    }
    public void GongGaoOut()
    {
        GongGaofunction.SetActive(false);
        qr=false;
    }
    public void GongZuoIn()
    {
        if (!qr)
        {
            GongZuoFunction.SetActive(true);
            qr = true;
        }
    }

    public void GongZuoOut()
    {
        GongZuoFunction.SetActive(false);
        qr=false;
    }
    public void back()
    {
        if (!qr) SceneManager.LoadScene("strat");
        qr=false;
    }


}
