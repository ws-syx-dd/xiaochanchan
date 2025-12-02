using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class drhp : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI hptext;
    public TextMeshProUGUI shdtext;
    public GameObject shdparent;
    public static float hpmax;
    public static float hp;
    public static float shd;
    private RectTransform hpimage;
    void Start()
    {
        hpupdata();
        hp = hpmax;
        hptext = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        hpimage = transform.GetChild(1).GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        hptext.text = hp.ToString("F0") + "/" + hpmax.ToString("F0");
        Vector3 ls = hpimage.localScale;
        hpimage.localScale = new Vector3(Mathf.Clamp((hp / hpmax), 0, 1), ls.y, ls.z);
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
        hpmax = (sxchushi.drsxchishu.hp + sxchushi.drsx1.hp + sxchushi.drlssx1.hp) * (sxchushi.drsx2.hp + sxchushi.drlssx2.hp);
        hpmax =Mathf.Round(hpmax);
        hp=hpmax;
        shd = (sxchushi.drsxchishu.shd + sxchushi.drsx1.shd + sxchushi.drlssx1.shd) * (sxchushi.drsx2.shd + sxchushi.drlssx2.shd);
    }
    public static void hploss(float i)
    {
        if (shd >= i) shd -= i;
        else
        {
            i -= shd;
            shd = 0;
            hp -= i;
        }
    }
}
