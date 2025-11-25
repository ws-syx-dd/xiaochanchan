using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static buffjs;
[System.Serializable]
public class every
{
    public int id;
    public int zbid;
    public string name;
    public bool Action;//是否是事件委托型
    public float chixushijian;//持续时间
    public string leixing;//每次 攻击、受击、大招 每秒
    public int duixiang;//0自己 1敌人
    public string shuxing;//改变hp mp 之类的
    public string fangshi;//+-或*%
    public float gailv;//概率
    public bool auto;//使用变量而非自身的值
    public string autofangshi;//使用变量而非自身的值
    public float zhi;
    
}
public class everylist
{
    public List<every> list = new List<every>();
}
public class everyjs : MonoBehaviour
{
    public static List<every> every;
    // Start is called before the first frame update
    
     void Start()
    {
        
        string filepath = Application.dataPath + "/js/everytext.json";
        string ls = File.ReadAllText(filepath);
        every= JsonUtility.FromJson<everylist>(ls).list;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
         


}
