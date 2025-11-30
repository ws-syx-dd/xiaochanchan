using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class zblan : MonoBehaviour
{   
    public  List<Image>zbdaoru= new List<Image>();
    public  List<Image>Drzbdaoru= new List<Image>();
    public  List<TextMeshProUGUI> zbtextdaoru = new List<TextMeshProUGUI>();
    public  List<TextMeshProUGUI> Drzbtextdaoru = new List<TextMeshProUGUI>();
    public static Image[] zblimg;
    public static TextMeshProUGUI[] zbltext;
    public static int[] zbl=new int[6];
    public static Image[] Drzblimg;
    public static TextMeshProUGUI[] Drzbltext;
    public static int[] Drzbl = new int[6];
    // Start is called before the first frame update
    void Start()
    {   
        zblimg=zbdaoru.ToArray();
        zbltext=zbtextdaoru.ToArray();
        Drzblimg = Drzbdaoru.ToArray();
        Drzbltext=Drzbtextdaoru.ToArray ();
        for (int i = 0; i < zbl.Length; i++){zbl[i] = -2;  }
        for (int i = 0; i < Drzbl.Length; i++)
        {
            Drzbl[i] = -1;
            Drzblimg[i].sprite=null;
        }
        zbl[0] = -1;
        zblimg[0].sprite = null;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
