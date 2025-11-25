using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zbdr : MonoBehaviour
{
    public static List<Sprite> zbimgall;
    public static List<zb> zb=new List<zb>();
    public static int[] zbleve=new int[99];
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] ls = Resources.LoadAll<Sprite>("img/zb");
        List<Sprite> sprites = new List<Sprite> (ls);
        zbimgall = sprites;
        for(int i=0;i<99;i++)zbleve[i] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
