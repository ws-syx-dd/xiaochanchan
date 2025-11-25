using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class zbbuy : MonoBehaviour
{
    // Start is called before the first frame update
    public Image zb;
    public int xh;
    void Start()
    {
        zb=transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public  void buy()
    {   
        int  zbwz = -1;//装备位置
        if (zbdr.zb[xh].xiaohui&& moneyscript.money >= zbdr.zb[xh].money)//销毁 不置入装备栏
        {
            moneyscript.money -= zbdr.zb[xh].money;
            fighteranniu.moneytext.text = moneyscript.money.ToString();
            zb ls = zbdr.zb[xh];
            zhuangbeichi.xiaoguo(0, ls, 1, zbdr.zbleve[ls.id]);
            gameObject.SetActive(false);
        }
        else//置入装备栏
        {
            {
                for (int i = 0; i < zblan.zbl.Length; i++)
                {
                    if (zblan.zbl[i] == -1)
                    {
                        zbwz = i;
                        break;
                    }
                }
                if (moneyscript.money >= zbdr.zb[xh].money && zbwz != -1)
                {
                    moneyscript.money -= zbdr.zb[xh].money;
                    fighteranniu.moneytext.text = moneyscript.money.ToString();
                    zblan.zbl[zbwz] = xh;
                    zblan.zblimg[zbwz].sprite = zb.sprite;
                    zblan.zbltext[zbwz].text = zbdr.zb[xh].jieshao;
                    zb ls = zbdr.zb[xh];
                    zhuangbeichi.xiaoguo(0, ls, 1, zbdr.zbleve[ls.id]);
                    Debug.Log(gameObject.name + "隐藏");
                    gameObject.SetActive(false);
                }
            }
        }
        
    }
}
