using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class zblan : MonoBehaviour
{   
    public  List<Image>zbdaoru= new List<Image>();
    public  List<TextMeshProUGUI> zbtextdaoru = new List<TextMeshProUGUI>();
    public int xh = -1;
    public static Image[] zblimg;
    public static TextMeshProUGUI[] zbltext;
    public static int[] zbl=new int[6];
    // Start is called before the first frame update
    void Start()
    {   
        zblimg=zbdaoru.ToArray();
        zbltext=zbtextdaoru.ToArray();
        for (int i = 0; i < zbl.Length; i++){zbl[i] = -2;  }
        zbl[0] = -1;
        zblimg[0].sprite = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
