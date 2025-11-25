using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buffdr : MonoBehaviour
{
    public static List<Sprite> buffimg;
    public static List<buff> buff=new List<buff>();
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] ls = Resources.LoadAll<Sprite>("img/buff");
        List<Sprite> sprites = new List<Sprite>(ls);
        buffimg=sprites;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
