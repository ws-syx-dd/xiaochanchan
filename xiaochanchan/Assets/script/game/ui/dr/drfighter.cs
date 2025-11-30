using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class drfighter : MonoBehaviour
{
    public static drfighter isdrfighter;
    // Start is called before the first frame update
    public static float atk;//攻击力 
    public static float dps;//攻速 1秒x次攻击
    public static float dzbl;//大招倍率
    public static float mphf;//蓝量恢复 每次攻击时回蓝 
    public static bool fighter = false;
    public static Dictionary<int, int> everyatkmap = new Dictionary<int, int>();
    public static Dictionary<int, int> everyhitmap = new Dictionary<int, int>();
    public static Dictionary<int, int> everydzmap = new Dictionary<int, int>();
    public static Dictionary<int, int> everytimemap = new Dictionary<int, int>();
    public static Dictionary<int, int> everystartmap = new Dictionary<int, int>();
    public Dictionary<string, Action> AllEveryAction = new Dictionary<string, Action>();
    public Action everyfighterstart;
    public Action everyfighterend;
    public Action neardeath;
    public Action everyhitAction;
    public Action everyatkAction;
    public static int neardeathcount = 0;//濒死次数
    public static int hitcount = 0;//受击次数
    public static int atkcount = 0;//攻击次数
    public float harmsum = 0;//伤害总量
    public static Animator donghua;
    public GameObject shoujidr;
    public static GameObject shouji;
    public GameObject shoujiprdr;
    public static GameObject shoujipr;//受击文本父对象
    public static int dqboci = 0;//当前波次
    private void Awake()
    {
        if (drfighter.isdrfighter == null) isdrfighter = this;
    }
    void Start()
    {
        neardeathcount = 0;
        atkupdata();
        dpsupdata();
        dzblupdata();
        mphfupdata();
        donghua = transform.GetChild(0).GetComponent<Animator>();
        donghua.runtimeAnimatorController = dranimator.Controller[sxchushi.myid];
        shouji = shoujidr;
        shoujipr = shoujiprdr;
        AllEveryAction.Add("everyfighterstart", everyfighterstart);
        AllEveryAction.Add("everyfighterend", everyfighterend);
        AllEveryAction.Add("neardeath", neardeath);
        AllEveryAction.Add("everyhitAction", everyhitAction);
        AllEveryAction.Add("everyatkAction", everyatkAction);
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
                everybig(dzbl);
                

            }
            else
            {
                donghua.Play("atk");
                if (false)//目前只能检测玩家的到时候再改
                {
                    Debug.Log("攻击分裂");
                    for (int i = 0; i < 2; i++)
                    {
                        myhp.hp -= atk * 0.35f;
                        drmp.mp += mphf;
                        everyatk(atk * 0.35f);

                    }
                }
                else
                {
                    myhp.hp -= atk;
                    drmp.mp += mphf;
                    everyatk(atk);
                }
            }
            if (drhp.hp <= 0)
            {
                fighter = false;
                return;
            }
            else
            {
                wait((int)(1000 / dps));
            }
        }

    public async void wait(int time)
    {
        await UniTask.Delay(time);
        if (myhp.hp > 0 && drhp.hp > 0)
        {
            //Debug.Log("myhp:"+myhp.hp+"drhp:"+drhp.hp);
            zd();
        }
        else
        {
            fighter = false;
        }
    }
    public static void atkupdata()
    {
        float chushi=sxchushi.drsxchishu.atk;
        float jiazhi=sxchushi.drsx1.atk+sxchushi.drlssx1.atk;
        float chengzhi = sxchushi.drsx2.atk + sxchushi.drlssx2.atk;
        atk= (chushi + jiazhi) * (chengzhi);
        drsxtext.atktext(atk);
    }
    public static void dpsupdata()
    {
        float chushi = sxchushi.drsxchishu.dps;
        float jiazhi = sxchushi.drsx1.dps + sxchushi.drlssx1.dps;
        float chengzhi = sxchushi.drsx2.dps + sxchushi.drlssx2.dps;
        dps = (chushi + jiazhi) * (chengzhi);
        drsxtext.dpstext(dps);
    }
    public static void dzblupdata()
    {
        float chushi = sxchushi.drsxchishu.dzbl;
        float jiazhi = sxchushi.drsx1.dzbl + sxchushi.drlssx1.dzbl;
        float chengzhi = sxchushi.drsx2.dzbl + sxchushi.drlssx2.dzbl;
        dzbl = (chushi + jiazhi) * (chengzhi);
        drsxtext.dzbltext(dzbl);
    }
    public static void mphfupdata()
    {
        float chushi = sxchushi.drsxchishu.mphf;
        float jiazhi = sxchushi.drsx1.mphf + sxchushi.drlssx1.mphf;
        float chengzhi = sxchushi.drsx2.mphf + sxchushi.drlssx2.mphf;
        mphf = (chushi + jiazhi) * (chengzhi);
        drsxtext.mphftext(mphf);
    }
    public static void stronger()//与dr在fighterend时一样 敌人升级
    {
        sxchushi.drsx1.hp += 50;
        sxchushi.drsx1.mp -= 10;
        sxchushi.drsx1.atk += 5;
        sxchushi.drsx1.dps += 0.1f;
        sxchushi.drsx1.dzbl += 0.5f;
        sxchushi.drsx1.mphf += 0.5f;
        buffchi.chi.buffreset();
        dqboci++;
        dranimator.animatorupdata();
        sxchushi.drlssx1 = new sxchushi.shuxing();
        sxchushi.drlssx2 = new sxchushi.shuxing();
        allupdata();
        kongzhitai.zhuangbeiadd(1, UnityEngine.Random.Range(0, zbdr.zb.Count));

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
    public  void everyatk(float zhi)
    {
        //zhuangbeichi.zblevelup("everyatk"); //目前只有玩家能正常触发等后期代码更改
        float zhisum = -zhi;
        foreach (var i in everyatkmap)
        {
            zhisum += everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value), zhi,1);
            Debug.Log("本次伤害总量:" + zhisum);
        }
        isdrfighter.harmsum += zhisum;
        myfighter.everyhit(-Mathf.Round(zhisum));
        if (drbuff.buffzhi.ContainsKey(0))//每次攻击时触发冰冻效果
        {   
            drbuff.buffzhi[0]--;
            buffchi.chi.bingdong(drbuff.buffzhi[0] * buffdr.buff[0].zhi);
            buffchi.chi.buffdelete(0);
            drbuff.buffupdata();
        }
       
    }
    
    public void everytime()
    {   

        if (myfighter.fighter && drfighter.fighter)
        {
            foreach (var i in everytimemap)
            {
                everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value),0,1);
            }
        
            if (drbuff.buffzhi.ContainsKey(2))//每秒触发剧毒效果
            {
                buffchi.chi.judu(drbuff.buffzhi[2] * buffdr.buff[2].zhi);
                buffchi.chi.buffdelete(2);
            }
            if (drbuff.buffzhi.ContainsKey(3))//每秒触发剧毒效果
            {
                buffchi.chi.ranshao(drbuff.buffzhi[3] * buffdr.buff[3].zhi);
                buffchi.chi.buffdelete(3);
            }
            drbuff.buffupdata();
            if (myfighter.fighter && drfighter.fighter) Invoke("everytime", 1f);
            else Debug.Log("dr-everytime 结束");
        }
        
    }
    public void everybig(float zhi = 0)
    {
        Debug.Log("大招施放");
        float zhisum = zhi;
        foreach (var i in everydzmap)
        {
            Debug.Log("everydzmap:" + i.Key);
            zhisum += everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value), zhi,1);
        }
        if (zhisum > 0) myfighter.everyhit(-Mathf.Round(zhisum));

    }
    public static void everyhit(float zhi)
    {
        hitcount++;
        isdrfighter.AllEveryAction["everyhitAction"]?.Invoke();
        foreach (var i in everyhitmap)
        {
            everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value), zhi, 1);
        }
        drfighter.donghua.Play("hit", 1, 0f);
        GameObject ls = Instantiate(shouji, shoujipr.transform);
        ls.GetComponent<hit>().Animatorstart(-zhi);
        if (myhp.hp <= 0)
        {
            Debug.Log("neardeath");
            neardeathcount++;
            isdrfighter.AllEveryAction["neardeath"]?.Invoke();
        }

    }


}
