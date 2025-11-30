using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class rw
{
    public int id=0;
    public string name;
    public float hp;
    public float mp;
    public float atk;
    public float dps; 
    public float mphf;
    public string bdjieshao;
    public int bdid;
    public string dzjieshao;
    public int dzid;
   

}
public class rwlist
{
    public List<rw> list =new List<rw>();
}
public class renwujs : MonoBehaviour
{
    public static List<rw> rw;
    // Start is called before the first frame update
    void Start()
    {

        string filepath = Application.dataPath + "/js/rwtext.json";
        string ls = File.ReadAllText(filepath);
        rw= JsonUtility.FromJson<rwlist>(ls).list;
        //if (rw == null)
        //{
        //    TextAsset lstext = Resources.Load<TextAsset>("js/rwtext");
        //    rw = JsonUtility.FromJson<rwlist>(lstext.text).list;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
