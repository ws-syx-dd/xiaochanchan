using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class rw
{
    public int id;
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
        TextAsset ls = Resources.Load<TextAsset>("js/rwtext");
        rw = JsonUtility.FromJson<rwlist>(ls.text).list;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
