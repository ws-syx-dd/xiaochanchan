using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class citiaoonly: MonoBehaviour
{
    public int id;
    public TextMeshProUGUI counttext;
    public int count;
    private int money;
    public GameObject jianhao;
    // Start is called before the first frame update
    public void chushihua()
    {
        money = int.Parse(transform.Find("shuliang").GetComponent<TextMeshProUGUI>().text);
        counttext.text = "*"+cundangjs.cundang.citiaocout[id].ToString();
        count = cundangjs.cundang.citiaocout[id];
        jianhao.SetActive(false);
    }
    public void add()
    {   
        if(cundangjs.cundang.mojing>=money)
        {
            count++;
            counttext.text = $"*{count}";
            cundangjs.cundang.mojing-=money;
            if(!jianhao.activeSelf)jianhao.SetActive(true);
        }
        citiaoall.citiao.MoneyUpdate();
        
    }
    public void loss()
    {
        count--;
        cundangjs.cundang.mojing += money;
        counttext.text = $"*{count}";
        if (cundangjs.cundang.citiaocout[id]==count)jianhao.SetActive(false);
        citiaoall.citiao.MoneyUpdate();

    }
   

}
