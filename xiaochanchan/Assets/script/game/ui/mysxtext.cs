using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mysxtext : MonoBehaviour
{   //属性文本
    // Start is called before the first frame update
    public static TextMeshProUGUI atk;//攻击
    public static TextMeshProUGUI dps;//攻速
    public static TextMeshProUGUI dzbl;//大招倍率
    public static TextMeshProUGUI mphf;//蓝量恢复
    void Start()
    {
        atk=transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dps=transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        mphf=transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        dzbl=transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void atktext(float chushi,float jiazhi,float chengzhi,float sum)
    {   
        atk.text =$"攻击力:({chushi:F0}+{jiazhi:F0})*{chengzhi:F1}={sum:F1}";
    }
    public static void dpstext(float chushi, float jiazhi, float chengzhi, float sum)
    {
        dps.text = $"攻速:({chushi:F0}+{jiazhi:F0})*{chengzhi:F1}={sum:F1}";
    }
    public static void mphftext(float chushi, float jiazhi, float chengzhi, float sum)
    {
        mphf.text = $"蓝量回复:({chushi:F0}+{jiazhi:F0})*{chengzhi:F1}={sum:F1}";
    }
    public static void dzbltext(float chushi, float jiazhi, float chengzhi, float sum)
    {
        dzbl.text = $"大招倍率:({chushi:F0}+{jiazhi:F0})*{chengzhi:F1}={sum:F1}";
    }

}
