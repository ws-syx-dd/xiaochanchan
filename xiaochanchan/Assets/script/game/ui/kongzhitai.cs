using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class kongzhitai : MonoBehaviour
{
    public TextMeshProUGUI text1;
    // Start is called before the first frame update
    public void cilck()
    {

        if (text1.text!="") 
           {
            try 
            {
                string[] lstext = text1.text.Substring(0, text1.text.Length - 1).Split("-");
                int index1=0;
                int index2 = int.Parse(lstext[2]);
                if (lstext[0] == "he") index1 = 1;
                if (lstext[1] == "zb") zhuangbeiadd(index1, index2);
                else if (lstext[1] != "zbl") shuxiangtiaozheng(index1, lstext[1], index2);
            }
            catch
            {

            }
            
        }
    }
    public static void zhuangbeiadd(int index1,int index2)
    {
        Debug.Log("添加装备id:" + index2);
        int zbwz = -1;//装备位置
        if (zbdr.zb[index2].xiaohui)//销毁 不置入装备栏
        {
            zb ls = zbdr.zb[index2];
            zhuangbeichi.xiaoguo(index1, ls, 1, zbdr.zbleve[ls.id]);
        }
        else//置入装备栏
        {
            if (index1 == 0)//不想重构之前代码 直接复制写两份
            {
                for (int i = 0; i < zblan.zbl.Length; i++)
                {
                    if (zblan.zbl[i] == -1)
                    {
                        zbwz = i;
                        break;
                    }
                }
                if (zbwz != -1)
                {
                    zblan.zbl[zbwz] = index2;
                    Sprite zbimg = zbdr.zbimgall[index2];
                    zblan.zblimg[zbwz].sprite = zbimg;
                    zblan.zbltext[zbwz].text = zbdr.zb[index2].jieshao;
                    zb ls = zbdr.zb[index2];
                    zhuangbeichi.xiaoguo(index1, ls, 1, zbdr.zbleve[ls.id]);
                }
            }
            else if (index1 == 1)
            {
                for (int i = 0; i < zblan.Drzbl.Length; i++)
                {
                    if (zblan.Drzbl[i] == -1)
                    {
                        zbwz = i;
                        break;
                    }
                }
                if (zbwz != -1)
                {
                    zblan.Drzbl[zbwz] = index2;
                    Sprite zbimg = zbdr.zbimgall[index2];
                    zblan.Drzblimg[zbwz].sprite = zbimg;
                    zblan.Drzbltext[zbwz].text = zbdr.zb[index2].jieshao;
                    zb ls = zbdr.zb[index2];
                    zhuangbeichi.xiaoguo(index1, ls, 1, zbdr.zbleve[ls.id]);
                }
            }
        }
    }
    public void shuxiangtiaozheng(int duixiang,string shuxing,int zhi)//对基础属性进行调整
    {
        FieldInfo field = typeof(sxchushi.shuxing).GetField(shuxing);//反射直接获取目标属性下的值 等同于 sxchushi.shuxing.leixing
        sxchushi.shuxing ls = new sxchushi.shuxing();
        switch (duixiang)
        {
            case (0):
                ls = sxchushi.mysxchishu;
                break;
            case (1):
                ls = sxchushi.drsxchishu;
                break;

        }
        field.SetValue(ls,zhi);
        drfighter.allupdata();
        myfighter.allupdata();
    }
}
