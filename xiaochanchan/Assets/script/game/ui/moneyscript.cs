using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;
    public static int beilv=10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void moenyupdata(int i)
    {
        money += money /beilv  + i / 10;
        fighteranniu.moneytext.text=money.ToString();
    }
    
}
