using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class myhp : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI hptext;
    public  TextMeshProUGUI shdtext;
    public GameObject shdparent;
    public static float hpmax;
    public static float hp;
    public static float hponlyup;//记录单次hp上升的值
    public static float hponlyupoverflow;//记录单次hp上升时溢出的值
    public static float shd;
    private RectTransform hpimage;
    void Start()
    {
        hpupdata();
        hp= hpmax;
        hptext=transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        hpimage =transform.GetChild(1).GetComponent<RectTransform>();
        shdparent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hptext.text = hp.ToString("F0") + "/" + hpmax.ToString("F0");
        Vector3 ls = hpimage.localScale;
        hpimage.localScale = new Vector3(Mathf.Clamp((hp / hpmax), 0, 1), ls.y,ls.z);
        if (shd > 0)
        {
            if (!shdparent.activeSelf) shdparent.SetActive(true);
            shdtext.text = Mathf.Round(shd).ToString();
        }
        else if (shd <= 0)
        {
            if (shdparent.activeSelf) shdparent.SetActive(false);
            shd = 0;
            shdtext.text = "";
        }


    }
    public static void hpupdata()
    {
        hpmax = (sxchushi.mysxchishu.hp + sxchushi.mysx1.hp+sxchushi.mylssx1.hp) * (sxchushi.mysx2.hp+sxchushi.mylssx2.hp);
        hpmax = Mathf.Round(hpmax);
        hp = hpmax;
        shd = (sxchushi.mysxchishu.shd + sxchushi.mysx1.shd + sxchushi.mylssx1.shd) * (sxchushi.mysx2.shd + sxchushi.mylssx2.shd);//目前只用到sxchushi.mysx1.shd  在每次战斗结束时将sxchushi.mysx1.shd=0;
    }
    public static void hploss(float i)
    {
        if (shd > i) shd -= i;
        else
        {
            if (shd > 0)
            {
                i -= shd;
                shd = 0;
                myfighter.ismyfighter.AllEveryAction["everyshdbreakAction"]?.Invoke();
            }
            
            hp -= i;
        }
    }
    public static void hpup(float zhi)
    {   
        hponlyup = zhi;
        hponlyupoverflow = 0;
        if (hp + zhi > hpmax)
        {
            hponlyupoverflow = hp + zhi - hpmax;
            hp = hpmax;
        }
        Debug.Log($"hponlyup:{hponlyup}");
        Debug.Log($"hponlyupoverflow:{hponlyupoverflow}");
        myfighter.ismyfighter.AllEveryAction["everyhpupAction"]?.Invoke();

    }


}
