using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beidongchi : MonoBehaviour
{
    // Start is called before the first frame update
    public static beidongchi chi;
    private Action neardeath;
    private void Awake()
    {
        if (chi == null) { chi = this; }
    }
    private void Start()
    {
        beidong(sxchushi.myid);  
    }
    public void beidong(int i)
    {
        switch (i)
        {
            case 0:
                //第一次濒死时恢复25%的血量
                 Action beidonghuifu= () =>
                {
                    if (myfighter.neardeathcount == 1)
                    {   
                        if(myhp.hp<0)myhp.hp = 0;
                        everychi.chi.fightersx("hp", 0, "*", 0.25f);
                    }
                };
                myfighter.ismyfighter.AllEveryAction["neardeath"] += beidonghuifu;

                break;
            case 1:
                myfighter.ismyfighter.AllEveryAction["everyfighterend"] += ()=> zhuangbeichi.sx("hp", 0, 1, 50);
                myfighter.ismyfighter.AllEveryAction["everyfighterend"] += myhp.hpupdata;
                break;
            case 2:
                moneyscript.beilv = 5;
                break;
            case 3:
                //暂时没做
                break;
            case 4:
                //暂时没做
                break;
            case 5:
                myfighter.ismyfighter.AllEveryAction["everyfighterend"] += () => zhuangbeichi.sx("atk", 0, 1, 1);
                myfighter.ismyfighter.AllEveryAction["everyfighterend"] += myfighter.atkupdata;
                break;

        }
    }
}
