using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class myhp : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI hptext;
    public static float hpmax;
    public static float hp;
    private RectTransform hpimage;
    void Start()
    {
        hpupdata();
        hp= hpmax;
        hptext=transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        hpimage =transform.GetChild(1).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        hptext.text = hp.ToString("F0") + "/" + hpmax.ToString("F0");
        Vector3 ls = hpimage.localScale;
        hpimage.localScale = new Vector3(Mathf.Clamp((hp / hpmax), 0, 1), ls.y,ls.z);
    }
    public static void hpupdata()
    {
        hpmax = (sxchushi.mysxchishu.hp + sxchushi.mysx1.hp+sxchushi.mylssx1.hp) * (sxchushi.mysx2.hp+sxchushi.mylssx2.hp);
        hpmax = Mathf.Round(hpmax);
        hp = hpmax;
    }
}
