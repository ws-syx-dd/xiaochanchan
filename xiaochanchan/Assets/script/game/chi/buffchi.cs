using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buffchi : MonoBehaviour
{
    public static buffchi chi;
    private void Awake()
    {
        if(chi == null)chi=this;
    }
    public void buff(int duixiang, int fangshi, float zhi)
    {
        if (duixiang == 0)
        {
            if (!drbuff.buffzhi.ContainsKey(fangshi))
            {
                drbuff.buffzhi.Add(fangshi, zhi);
                drbuff.buffimage[drbuff.buffzhi.Count - 1].gameObject.SetActive(true);
                drbuff.buffimage[drbuff.buffzhi.Count - 1].sprite = buffdr.buffimg[fangshi];
                drbuff.bufftext[drbuff.buffzhi.Count - 1].text = zhi.ToSafeString();
            }
            else
            {
                drbuff.buffzhi[fangshi] = drbuff.buffzhi[fangshi] + zhi;
            }
            switch (fangshi)
            {
                case 0:
                    bingdong(buffdr.buff[fangshi].zhi * drbuff.buffzhi[fangshi]);
                    break;

            }
            buffdelete(fangshi);

        }
    }
    public  void buffdelete(int fangshi)
    {
        if (drbuff.buffzhi[fangshi] <= 0)
        {
            drbuff.buffimage[drbuff.buffzhi.Count - 1].gameObject.SetActive(false);
            drbuff.buffzhi.Remove(fangshi);
        }

    }
    public  void buffreset()
    {
        drbuff.buffzhi.Clear();

        for (int i = 0; i < 8; i++)
        {
            //Debug.Log(drbuff.buffimage[i].name);
            drbuff.buffimage[i].gameObject.SetActive(false);
        }
        foreach (var item in zblan.zbl)
        {
            if (item >= 0)
            {
                zb ls = zbdr.zb[item];

                for (int j = 0; j < ls.count; j++)
                {
                    if (ls.leixing[j] == "buff")//重新添加buff 如每次战斗结束后剧毒药水的剧毒3
                    {
                        buffchi.chi.buff(0, ls.fangshi[j], ls.zhi[j]);
                    }
                }

            }
        }

    }
    public  void bingdong(float sum)
    {
        sxchushi.drlssx2.dps = sum;
        drfighter.dpsupdata();
        Debug.Log("冰冻" + drbuff.buffzhi[0] + ":当前攻速" + drfighter.dps);


    }
    public  void judu(float sum)
    {
        Debug.Log("当前血量" + drhp.hp + " 剧毒" + drbuff.buffzhi[2] + ":扣除血量" + drhp.hpmax * sum);
        drhp.hp -= drhp.hpmax * sum;

        drbuff.buffzhi[2]--;
    }
    public  void ranshao(float sum)
    {
        Debug.Log("当前血量" + drhp.hp + " 燃烧" + drbuff.buffzhi[3] + ":扣除血量" + drhp.hp * sum);
        drhp.hp -= drhp.hp * sum;

        drbuff.buffzhi[3]--;
    }

}
