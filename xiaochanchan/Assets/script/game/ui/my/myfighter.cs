
using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myfighter : MonoBehaviour
{
    public static myfighter ismyfighter;
    public static float atk;//攻击力 
    public static float dps;//攻速 1秒x次攻击
    public static float dzbl;//大招倍率
    public static float mphf;//蓝量恢复 每次攻击时回蓝 
    public static bool fighter=false;
    public static Dictionary<int,int>everyatkmap= new Dictionary<int,int>();
    public static Dictionary<int,int>everyhitmap= new Dictionary<int,int>();
    public static Dictionary<int,int>everydzmap= new Dictionary<int,int>();
    public static Dictionary<int,int>everytimemap= new Dictionary<int,int>();
    public static Dictionary<int,int>everystartmap= new Dictionary<int,int>();
    public  Dictionary<string,Action>AllEveryAction= new Dictionary<string,Action>();
    public Action everyfighterstart;
    public Action everyfighterend ;
    public Action neardeath;
    public Action everyhitAction;
    public Action everyatkAction;
    public static int neardeathcount = 0;//濒死次数
    public static int hitcount = 0;//受击次数
    public static int atkcount = 0;//攻击次数
    public  float harmsum = 0;//伤害总量
    public static Animator donghua;
    public GameObject shoujidr;
    public static GameObject shouji;
    public GameObject shoujiprdr;
    public static GameObject shoujipr;//受击文本父对象
    private void Awake()
    {
        if (myfighter.ismyfighter == null) ismyfighter = this;

    }
    void Start()
    {
        neardeathcount = 0;
        atkupdata();
        dpsupdata();
        dzblupdata();
        mphfupdata();
        donghua=transform.GetChild(0).GetComponent<Animator>();
        donghua.runtimeAnimatorController = dranimator.Controller[sxchushi.myid];
        shouji = shoujidr;
        shoujipr=shoujiprdr;
        AllEveryAction.Add("everyfighterstart", everyfighterstart);
        AllEveryAction.Add("everyfighterend", everyfighterend);
        AllEveryAction.Add("neardeath", neardeath);
        AllEveryAction.Add("everyhitAction", everyhitAction);
        AllEveryAction.Add("everyatkAction", everyatkAction);
        


    }
    private void OnDisable()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FighterStart()
    {
        ismyfighter.AllEveryAction["everyfighterstart"]?.Invoke();
        zd();

    }
    public  void zd()
    {
            if (mymp.mp >= mymp.mpmax)
            {
                donghua.Play("atk");
                //drhp.hp -= atk * dzbl;
                mymp.mp = 0;
                dazhaochi.chi.dazhao(sxchushi.myid,0);
                everybig();

            }
            else
            {
                donghua.Play("atk");
                if (zbdr.zbleve[28] == 2)
                {
                    Debug.Log("攻击分裂");
                    for (int i = 0; i < 2; i++)
                    {
                        drhp.hp -= atk * 0.35f;
                        mymp.mp += mphf;
                        everyatk(atk * 0.35f);

                    }
                }
                else
                {
                    drhp.hp -= atk;
                    mymp.mp += mphf;
                    everyatk(atk);
                }

            }
            if (myhp.hp <= 0)
            {   
                fighter = false;
                return;
            }
            else
            {
               wait((int)(1000 / dps));
            }
    }
     public async void  wait(int time)
    {
        await UniTask.Delay(time);
        if (myhp.hp > 0 &&drhp.hp > 0)
        {   
            //Debug.Log("myhp:"+myhp.hp+"drhp:"+drhp.hp);
            zd();
        }
        else
        {
            fighter = false;
        }
     }
    
    public static void atkupdata()//这四条updata调用会比较多就不用反射了
    {
        float chushi = sxchushi.mysxchishu.atk;
        float jiazhi = sxchushi.mysx1.atk + sxchushi.mylssx1.atk;
        float chengzhi = sxchushi.mysx2.atk + sxchushi.mylssx2.atk;
        atk = (chushi +jiazhi) * (chengzhi);
        atkcount++;
        Debug.Log("当前攻击次数:" + atkcount);
        mysxtext.atktext(chushi,jiazhi,chengzhi,atk);
    }
    public static void dpsupdata()
    {
        float chushi = sxchushi.mysxchishu.dps;
        float jiazhi = sxchushi.mysx1.dps + sxchushi.mylssx1.dps;
        float chengzhi = sxchushi.mysx2.dps + sxchushi.mylssx2.dps;
        dps = (chushi + jiazhi) * (chengzhi);
        mysxtext.dpstext(chushi, jiazhi, chengzhi, dps);
    }
    public static void dzblupdata()
    {
        float chushi = sxchushi.mysxchishu.dzbl;
        float jiazhi = sxchushi.mysx1.dzbl + sxchushi.mylssx1.dzbl;
        float chengzhi = sxchushi.mysx2.dzbl + sxchushi.mylssx2.dzbl;
        dzbl = (chushi + jiazhi) * (chengzhi);
        mysxtext.dzbltext(chushi, jiazhi, chengzhi, dzbl);
    }
    public static void mphfupdata()
    {
        float chushi = sxchushi.mysxchishu.mphf;
        float jiazhi = sxchushi.mysx1.mphf + sxchushi.mylssx1.mphf;
        float chengzhi = sxchushi.mysx2.mphf + sxchushi.mylssx2.mphf;
        mphf = (chushi + jiazhi) * (chengzhi);
        mysxtext.mphftext(chushi, jiazhi, chengzhi, mphf);
    }
    public static void allupdata()
    {
        atkupdata();
        dpsupdata();
        dzblupdata();
        mphfupdata();
    }
    public static void everyatk(float zhi)
    {
        zhuangbeichi.zblevelup("everyatk");
        float zhisum = -zhi;
        foreach (var i in everyatkmap)
        {
           zhisum+=everychi.chi.everyshixian(i.Key,zhuangbeichi.gailvcount(i.Key,i.Value),zhi);
            Debug.Log("本次伤害总量:" + zhisum);
        }
       ismyfighter.harmsum += zhisum;


        drfighter.everyhit(-Mathf.Round(zhisum));
    }
    public void everytime()
    {
       foreach (var i in everytimemap)
        {
            everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value));
        }
        if (myfighter.fighter && drfighter.fighter) Invoke("everytime", 1f);
        else Debug.Log("my-everytime end");

    }
    public void everybig(float zhi=0)
    {
        Debug.Log("大招施放");
        float zhisum = zhi;
        foreach (var i in everydzmap)
        {
            Debug.Log("everydzmap:" + i.Key);
           zhisum+=everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value),zhi);
        }
        if(zhisum>0) drfighter.everyhit(-Mathf.Round(zhisum));

    }
    public static void everyhit(float zhi)
    {
        hitcount++;
        ismyfighter.AllEveryAction["everyhitAction"]?.Invoke();
        foreach (var i in everyhitmap)
        {
            everychi.chi.everyshixian(i.Key, zhuangbeichi.gailvcount(i.Key, i.Value),zhi);
        }
        myfighter.donghua.Play("hit",1,0f);
        GameObject ls = Instantiate(shouji,shoujipr.transform);
        ls.GetComponent<hit>().Animatorstart(-zhi);
        if (myhp.hp <= 0)
        {
            Debug.Log("neardeath");
            neardeathcount++;
            ismyfighter.AllEveryAction["neardeath"]?.Invoke();
        }
    }
    public void fighterend(string jieguo) 
    {
        Debug.Log("战斗结束");
        ismyfighter.AllEveryAction["everyfighterend"]?.Invoke();
         neardeathcount = 0;//濒死次数
         hitcount = 0;//受击次数
        harmsum = 0;//伤害总量


        if (jieguo == "win")
        {
            zhuangbeichi.zblevelup("win");
            zhuangbeichi.zbleveldown();
        }
        else
        {
            loserjiesuan();
            
        }
    }
    public void donghuastart()
    {

    }
    public void loserjiesuan()
    {
        myheart.heart[myheart.heartcount-1].gameObject.SetActive(false);
        myheart.heartcount--;
        if(myheart.heartcount == 0)
        {
            sxchushi.chushihua();//将所有属性初始化
            zbxiaohui.allxiaohui();//全部装备销毁
            myfighter.allupdata();
            drfighter.allupdata();
            myhp.hpupdata();
            mymp.mpupdata();
            drhp.hpupdata();
            drmp.mpupdata();
            fighteranniu.xydlv = 1;
            dranimator.animatorupdata();
            //for (int i = 0; i < 8; i++)
            //{
            //    Debug.Log(drbuff.buffimage[i]);
            //}
            SceneManager.LoadScene("loser");
        }
        else
        {
            myhp.hpupdata();
            mymp.mpupdata();
            myfighter.allupdata();
            fighteranniu.xydlv++;
            fighteranniu.xyd(Mathf.Min(fighteranniu.xydlv, 4));
        }
        
    }

}
