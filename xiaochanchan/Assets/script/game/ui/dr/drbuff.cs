using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class drbuff : MonoBehaviour//µ–»Àbuff
{
    // Start is called before the first frame update
    public static List<Image> buffimage=new List<Image>();
    public static List<TextMeshProUGUI> bufftext=new List<TextMeshProUGUI>();
    public static Dictionary<int,float>buffzhi=new Dictionary<int,float>();
    void Start()
    {   
        
        buffimage.Clear();
        foreach (Transform t in transform)
        {
            
            buffimage.Add(t.GetComponent<Image>());
            bufftext.Add(t.GetChild(0).GetComponent<TextMeshProUGUI>());
            t.gameObject.SetActive(false);

        }
        //for (int i = 0; i < buffimage.Count; i++)
        //{
        //   if(i<buffdr.buffimg.Count) buffimage[i].sprite=buffdr.buffimg[i];
        //    bufftext[i].text=i.ToString();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void buffupdata()
    {
        int zhi = 0;
        foreach(KeyValuePair<int,float> pair in buffzhi)
        {
            buffimage[zhi].sprite = buffdr.buffimg[pair.Key];
            bufftext[zhi].text=pair.Value.ToString();
            zhi++;

        }

    }

   
    
}
