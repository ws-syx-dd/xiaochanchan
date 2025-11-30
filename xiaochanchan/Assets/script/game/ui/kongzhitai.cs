using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class kongzhitai : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    // Start is called before the first frame update
    public void cilck()
    {

        if (text1.text!=""&&text2.text!="") 
           {
            try 
            {
                int index1 = int.Parse(text1.text.Substring(0, text1.text.Length - 1));//对象
                int index2 = int.Parse(text2.text.Substring(0, text2.text.Length - 1));//装备序号
                zhuangbeiadd(index1, index2);
            }
            catch
            {

            }
            
        }
    }
    public static void zhuangbeiadd(int index1,int index2)
    {
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
}
