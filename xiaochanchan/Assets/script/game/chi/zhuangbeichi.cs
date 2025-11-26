
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class zhuangbeichi: MonoBehaviour
{
    // Start is called before the first frame update
    public static List<zb> zblist=new List<zb>();
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public static void xiaoguo(int duixiang,zb zb , int inorout,int level=1)//duixiang=0代表自己 =1代表敌人 fangshi= 1代表加减 2代表乘除
    {   
        for(int i=0;i<zb.count;i++)
        {
            if (zb.leixing[i] == "only")
            {
                sx(zb.shuxing[i], duixiang, zb.fangshi[i], zb.zhi[i] * level * inorout);
                myfighter.allupdata();
                drfighter.allupdata();
                myhp.hpupdata();
                drhp.hpupdata();
                mymp.mpupdata();
                drmp.mpupdata();
            }
            else if (zb.leixing[i] == "buff")
            {
                
                buffchi.chi.buff(duixiang, zb.fangshi[i], zb.zhi[i]*level*inorout);
                drbuff.buffupdata();
            }
            else if (zb.leixing[i] == "every")
            {
                everychi.chi.EveryInOrOut(zb, i, inorout, level);
            }
            else if (zb.leixing[i] == "qita")
            {
                qitaxiaoguo(zb.fangshi[i], (int)zb.zhi[i]*level*inorout);
            }
        }
    }

    public static void sx(string leixing, int duixiang,int fangshi,float zhi)//永久属性如：atk+1
    {
        
        FieldInfo field=typeof(sxchushi.shuxing).GetField(leixing);//反射直接获取目标属性下的值 等同于 sxchushi.shuxing.leixing
        sxchushi.shuxing ls = new sxchushi.shuxing();
        switch (duixiang, fangshi)
        {
            case (0, 1):
                ls = sxchushi.mysx1;
                break;
            case(0,2):
                ls = sxchushi.mysx2;
                break;
            case (1, 1):
                ls = sxchushi.drsx1;
                break ;
            case (1, 2):
                ls=sxchushi.drsx2;
                break ;

        }
        field.SetValue(ls, (float)field.GetValue(ls) + zhi);
    }
   
    public static float gailvcount(int key,int value)//只计算成功多少次
    {
        var ls = everyjs.every[key];
        float jieguo=0;
        if (ls.gailv == 0)
        {
            jieguo = value;
        }
        else if (ls.gailv != 0 && value <= 6)
        {
            for (int i = 0; i < value; i++)
            {
                if (Random.Range(0f, 1f) <= ls.gailv) jieguo++;
            }
        }
        else
        {
            float qiwang = ls.gailv * value;
            float bodong = qiwang * 0.15f;
            jieguo = Mathf.RoundToInt(qiwang + Random.Range(bodong, -bodong));
        }
        Debug.Log(ls.name + "触发了:" + jieguo);
        return jieguo;
    }

    public static void qitaxiaoguo(int fangshi,int zhi=1)
    {
        switch (fangshi)
        {
            case 13:
                moneyscript.money += 15;
                fighteranniu.moneytext.text = moneyscript.money.ToString();
                break;
            case 28://分裂箭效果 暂时硬编码一下
                zbdr.zbleve[28] += zhi;
                Debug.Log("分裂箭启动" + zbdr.zbleve[28]);
                break;
            case 34:
                int i = Random.Range(0, 10);
                if (i < 1) moneyscript.money += 3;
                else if(i>=1&&i<=4) moneyscript.money += 2;
                fighteranniu.moneytext.text = moneyscript.money.ToString();
                break;
        }
    }
    public static void zblevelup(string tiaojian)
    {
        for (int i = 0; i <6;i++)
        {
            if (zblan.zbl[i] >= 0 )
            {
                zb ls = zbdr.zb[zblan.zbl[i]];
                if(ls.uptiaojian == tiaojian)
                {
                    zbdr.zbleve[ls.id]++;

                    for (int j = 0; j < ls.count; j++)
                    {
                        if (ls.leixing[j] == "every")
                        {
                            
                            zhuangbeichi.xiaoguo(0, ls,1);
                            break;
                        }
                            
                    }
                   
                }
            }
        }
    }
    public static void zbleveldown()
    {
        for (int i = 0; i < 6; i++)
        {
            if (zblan.zbl[i] >= 0)
            {
                zb ls = zbdr.zb[zblan.zbl[i]];
                for(int j = 0; j < ls.count; j++)
                {
                    if (ls.leixing[j]=="every")
                    {
                        zbdr.zbleve[ls.id] = 1;
                    }
                }
                
            }
        }
        sxchushi.mylssx1 = new sxchushi.shuxing();//重置所有临时属性
        sxchushi.mylssx2 = new sxchushi.shuxing();
        myfighter.allupdata();
    }

}


