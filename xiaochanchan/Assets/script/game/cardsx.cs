using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardsx : MonoBehaviour
{
    public List<Transform> card=new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in transform)card.Add(t);
        allshuaxing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void allshuaxing()
    {   
        int xyd = fighteranniu.xydlv;
        for (int i = 0; i < card.Count; i++)
        {
           bool qr=true;
            int index = 0 ;
            while (qr)
            {

                int ls = (int)Random.Range(0, zbdr.zb.Count);
                zb lszb=zbdr.zb[ls];
                if (lszb.money<=2||xyd>=4||(xyd>=3&&lszb.money<=5)||(xyd>=2&&lszb.money<=3))
                {
                    qr = !qr;
                    index = ls;
                }
            }
            shuaxing(i,index);
        }
    }
    void shuaxing(int xh,int id)
    {
        card[xh].gameObject.SetActive(true);
        Transform ls=card[xh];
        zb lszb = zbdr.zb[id];
        ls.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = lszb.name;
        ls.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = lszb.jieshao;
        ls.GetChild(1).GetChild(0).GetComponent<Image>().sprite = zbdr.zbimgall[id];
        ls.GetChild(2).GetComponent<TextMeshProUGUI>().text = lszb.money +"";
        switch (lszb.money)
        {
            case 1:
                ls.GetComponent<Image>().color= Color.white;
                break;
            case 2:
                ls.GetComponent<Image>().color = Color.green;
                break;
            case 3:
                ls.GetComponent<Image>().color = new Color(0,150,255,255);
                break;
            case 5:
                ls.GetComponent<Image>().color = Color.yellow;
                break;
            case 10:
                ls.GetComponent<Image>().color = Color.red;
                break;
        }   
        ls.GetComponent<zbbuy>().xh = id;
        

    }
}
