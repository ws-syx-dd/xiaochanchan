using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
[System.Serializable]
public class zb
{
    public int id;
    public int imgwz;
    public string name;
    public string jieshao;
    public int money;
    public int count;//物品效果分支 如：hp+10 cout=1; hp+10，mp+10 conut=2; hp+10,mp+10.atk+10 count=3
    public string[] leixing;
    public string[] shuxing;
    public int[] fangshi;
    public float[] zhi;
    public bool xiaohui;//默认不销毁 销毁物品不会进入装备栏中
    public bool nothuishou;//默认回收 无法回收的物品永远在装备栏中  
    public string uptiaojian;//永久物品的升级条件
}
public class zblist
{
    public List<zb> list=new List<zb>();
};
public class zhuangbeijs : MonoBehaviour
{
    public static bool jsupdata=false;
    // Start is called before the first frame update
    void Start()
    {   
        string filepath = Application.dataPath + "/js/zbtext.json";
        string ls = File.ReadAllText(filepath);
        zbdr.zb=JsonUtility.FromJson<zblist>(ls).list;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
