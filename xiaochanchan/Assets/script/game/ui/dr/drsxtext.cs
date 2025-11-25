using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class drsxtext : MonoBehaviour
{   //属性文本
    // Start is called before the first frame update
    public static TextMeshProUGUI atk;//攻击
    public static TextMeshProUGUI dps;//攻速
    public static TextMeshProUGUI dzbl;//大招倍率
    public static TextMeshProUGUI mphf;//蓝量恢复
    void Start()
    {
        atk = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dps = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        mphf = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        dzbl = transform.GetChild(3).GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void atktext(float i)
    {
        atk.text = "攻击力:" + i;
    }
    public static void dpstext(float i)
    {
        dps.text = "攻速:" + i;
    }
    public static void mphftext(float i)
    {
        mphf.text = "能量回复:" + i;
    }
    public static void dzbltext(float i)
    {
        dzbl.text = "大招倍率:" + i;
    }

}
