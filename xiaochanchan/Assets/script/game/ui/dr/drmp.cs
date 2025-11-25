using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class drmp : MonoBehaviour
{
    // Start is called before the first frame update
    public float csmp;//³õÊ¼ÑªÁ¿
    public static TextMeshProUGUI mptext;
    public static float mpmax;
    public static float mp;
    private RectTransform mpimage;
    void Start()
    {
        mpupdata();
        mptext = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        mpimage = transform.GetChild(1).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        mptext.text = mp + "/" + mpmax;
        Vector3 ls = mpimage.localScale;
        mpimage.localScale = new Vector3(Mathf.Clamp((mp / mpmax),0,1), ls.y, ls.z);
    }
    public static void mpupdata()
    {
        mpmax = (sxchushi.drsxchishu.mp + sxchushi.drsx1.mp + sxchushi.drlssx1.mp) * (sxchushi.drsx2.mp + sxchushi.drlssx2.mp);
        mpmax = ((float)Mathf.Round(mpmax));
        mp = 0;
        //Debug.Log("drmp:"+mpmax);
    }
}
