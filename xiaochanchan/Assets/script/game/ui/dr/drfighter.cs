using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drfighter : MonoBehaviour
{
    // Start is called before the first frame update
    public static float atk;//攻击力 
    public static float dps;//攻速 1秒x次攻击
    public static float dzbl;//大招倍率
    public static float mphf;//蓝量恢复 每次攻击时回蓝 
    public static bool fighter = false;
    public static int level = 0;
    public static int[] boci = { 1, 1, 1, 1, 1 };//还有几波升级
    public static int dqboci = 0;//当前波次
    public static Animator donghua;
    public GameObject shoujidr;
    public static GameObject shouji;
    public GameObject shoujiprdr;
    public static GameObject shoujipr;//受击文本父对象
    void Start()
    {
        atkupdata();
        dpsupdata();
        dzblupdata();
        mphfupdata();
        donghua = transform.GetChild(0).GetComponent<Animator>();
        shouji = shoujidr;
        shoujipr = shoujiprdr;
        //Debug.Log(shouji.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void zd()
    {
       
            if (drmp.mp >= drmp.mpmax)
            {
                donghua.Play("atk");
                myhp.hp -= atk * dzbl;
                drmp.mp = 0;
                myfighter.everyhit(atk * dzbl);

            }
            else
            {
                donghua.Play("atk");
                myhp.hp -= atk;
                drmp.mp += mphf;
                myfighter.everyhit(atk);
                everyatk();
            }
            if (drhp.hp <= 0)
            {
                fighter = false;
                return;
            }
            else
            {
                StartCoroutine(wait(1 / dps));
            }
        }
       
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        if (myhp.hp > 0 && drhp.hp > 0)
        {
            Debug.Log("myhp:" + myhp.hp + "drhp:" + drhp.hp);
            zd();
        }
        else
        {
            fighter = false;
        }
    }
    public static void atkupdata()
    {
        atk = (sxchushi.drsxchishu.atk + sxchushi.drsx1.atk + sxchushi.drlssx1.atk) * (sxchushi.drsx2.atk + sxchushi.drlssx2.atk);
        drsxtext.atktext(atk);
    }
    public static void dpsupdata()
    {
        dps = (sxchushi.drsxchishu.dps + sxchushi.drsx1.dps + sxchushi.drlssx1.dps) * (sxchushi.drsx2.dps + sxchushi.drlssx2.dps);
        drsxtext.dpstext(dps);
    }
    public static void dzblupdata()
    {
        dzbl = (sxchushi.drsxchishu.dzbl + sxchushi.drsx1.dzbl + sxchushi.drlssx1.dzbl) * (sxchushi.drsx2.dzbl + sxchushi.drlssx2.dzbl);
        drsxtext.dzbltext(dzbl);
    }
    public static void mphfupdata()
    {
        mphf = (sxchushi.drsxchishu.mphf + sxchushi.drsx1.mphf + sxchushi.drlssx1.mphf) * (sxchushi.drsx2.mphf + sxchushi.drlssx2.mphf);
        drsxtext.mphftext(mphf);
    }
    public static void stronger()//与dr在fighterend时一样
    {
        sxchushi.drsx1.hp += 50;
        sxchushi.drsx1.mp -= 10;
        sxchushi.drsx1.atk += 5;
        sxchushi.drsx1.dps += 0.1f;
        sxchushi.drsx1.dzbl += 0.5f;
        sxchushi.drsx1.mphf += 0.5f;
        buffchi.chi.buffreset();
        level++;
        if (boci[dqboci] > 1) boci[dqboci]--;
        else
        {
            dqboci++;
            dranimator.animatorupdata();
        }
        sxchushi.drlssx1 = new sxchushi.shuxing();
        sxchushi.drlssx2 = new sxchushi.shuxing();
        allupdata();
    }
    public static void allupdata()
    {
        drhp.hpupdata();
        drmp.mpupdata();
        atkupdata();
        dpsupdata();
        dzblupdata();
        mphfupdata();
    }
    public  void everyatk()
    {
        if (drbuff.buffzhi.ContainsKey(0))
        {   
            drbuff.buffzhi[0]--;
            buffchi.chi.bingdong(drbuff.buffzhi[0] * buffdr.buff[0].zhi);
            buffchi.chi.buffdelete(0);
            drbuff.buffupdata();
        }
       
    }
    public static void everyhit(float zhi)
    {
        drfighter.donghua.Play("hit", 1, 0f);
        GameObject ls = Instantiate(shouji, shoujipr.transform);
        ls.GetComponent<hit>().Animatorstart(-zhi);

    }
    public void everytime()
    {
        if (myfighter.fighter && drfighter.fighter)
        {
            if (drbuff.buffzhi.ContainsKey(2))
            {
                buffchi.chi.judu(drbuff.buffzhi[2] * buffdr.buff[2].zhi);
                buffchi.chi.buffdelete(2);
            }
            if (drbuff.buffzhi.ContainsKey(3))
            {
                buffchi.chi.ranshao(drbuff.buffzhi[3] * buffdr.buff[3].zhi);
                buffchi.chi.buffdelete(3);
            }
            drbuff.buffupdata();
            if (myfighter.fighter && drfighter.fighter) Invoke("everytime", 1f);
            else Debug.Log("dr-everytime 结束");
        }
        
    }
    public static void bocistart()
    {
        level = 0;
        for (int i = 0; i < 5; i++)
        {
            boci[i] = 1;
        }
        dqboci = 0;
    }
 
}
