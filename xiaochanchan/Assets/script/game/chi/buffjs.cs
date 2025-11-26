using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class buff
{
    public int id;
    public string name;
    public string leixing;
    public int fangshi;
    public float zhi;
}
public class bufflist
{
    public List<buff> list = new List<buff>();
}
public class buffjs : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {


        TextAsset ls= Resources.Load<TextAsset>("js/bufftext");
        buffdr.buff=JsonUtility.FromJson<bufflist>(ls.text).list;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
