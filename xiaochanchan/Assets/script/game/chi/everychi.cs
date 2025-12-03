using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class everychi : MonoBehaviour
{   
    
    public static everychi chi;
    public Dictionary<int, Action> ZBFunction = new Dictionary<int, Action>();//目前every只能实现自己的办法
    private void Awake()
    {
        if(everychi.chi == null)
        {
            chi = this;
            Debug.Log("成功实例化everychi");
        }
    }
    private void Start()
    {
        ZBFunction.Add(15,every15);
        ZBFunction.Add(18,every18);
        ZBFunction.Add(19,every19);
        ZBFunction.Add(20,every20);
        ZBFunction.Add(21,every21);
        ZBFunction.Add(22,every22);
        ZBFunction.Add(24,every24);
        ZBFunction.Add(25,every25);
        ZBFunction.Add(28,every28);
        ZBFunction.Add(30,every30);
        ZBFunction.Add(35,every35);
    }
    public void EveryInOrOut(int duixiang,zb zb,int index, int inorout, int level = 1)
    {
        int fangshi = zb.fangshi[index];
        Debug.Log(zb.id + " " + zb.fangshi[index]);
        every ls = everyjs.every[fangshi];
        Debug.Log(ls.Action);
        if (ls.Action)
        {
            Debug.Log(ls.leixing + " " + ls.id);
            if (inorout >= 1)
            {

                if(duixiang==0)myfighter.ismyfighter.AllEveryAction[ls.leixing] += chi.ZBFunction[ls.id];
                else drfighter.isdrfighter.AllEveryAction[ls.leixing] += chi.ZBFunction[ls.id];
                Debug.Log("已添加方法"+ ls.id+"至"+ ls.leixing);
            }
            else
            {
                if(duixiang==0)myfighter.ismyfighter.AllEveryAction[ls.leixing] -= chi.ZBFunction[ls.id];
                else drfighter.isdrfighter.AllEveryAction[ls.leixing] -= chi.ZBFunction[ls.id];
                Debug.Log("已移除方法" + ls.id);
            }
        }
        else if(ls.Action==false)
        {
            Debug.Log((ls.leixing + "map"));
            FieldInfo fieldInfo=null;
            if (duixiang == 0) fieldInfo = typeof(myfighter).GetField((ls.leixing + "map"));
            else fieldInfo = typeof(drfighter).GetField((ls.leixing + "map"));
            Dictionary<int, int> ls1 = (Dictionary<int, int>)fieldInfo.GetValue(fieldInfo);
            int zhi = (int)zb.zhi[index] * level * inorout;
            Debug.Log("(int)zb.zhi[i]*level * inorout:" + zhi); 
            
            if (!ls1.ContainsKey(fangshi))
            {
                ls1.Add(fangshi, zhi);
            }
            else
            {
                ls1[fangshi] += (int)zhi;
                Debug.Log(ls1[fangshi] + "-----" + zhi);
                if (ls1[fangshi] <= 0) ls1.Remove(fangshi);
            }
        }
        
    }
    public  float everyshixian(int id, float count=1, float zishiying = 0,int chufazhe=0)//every中的内容实现 zishiying为调用every产生的值 如hit中的受到伤害 atk中的造成伤害 chufazhe为触发此方法的人 0为玩家 1为敌人
    {
        every ls = everyjs.every[id];
        float zhisum=0;
        float zhiadd = 0;
        if (ls.auto)//auto时处置方法
        {
            if (ls.autofangshi == "+") zhisum = count * (ls.zhi + zishiying);
            else zhisum = count * ls.zhi * zishiying;
        }
        else if (ls.yinyongshuxing != null)//引用其他值时处置方法
        {
            switch (ls.yinyongshuxing)
            {
                case ("hp")://暂时没用过yinyongfangshi == "+"可以先不写
                    //if (ls.yinyongfangshi == "+") zhisum = count * (ls.zhi + myhp.hp);
                    //else zhisum=count*ls.zhi * myhp.hp;
                    zhisum = count * ls.zhi * myhp.hp;
                    break;
                case ("atk"):
                    zhisum = count * ls.zhi * myfighter.atk;
                    break;
                case ("dps"):
                    zhisum = count * ls.zhi * myfighter.dps;
                    break;
            }
        }
        else zhisum = count * ls.zhi;
        Debug.Log($"zhisun:{zhisum}");
        zhiadd = fightersx(ls.shuxing, ls.duixiang, ls.fangshi, zhisum, zhiadd,chufazhe);
        //Debug.Log(zhiadd);
        return zhiadd;
    }
    public  float fightersx(string shuxing, int duixiang, string fangshi, float zhisum, float zhiadd = 0,int chufazhe=0)//chufazhe为触发此方法的人 0为玩家 1为敌人
    {
        if (chufazhe == 0)
        {
            switch (shuxing, duixiang)//shuxing为属性 对象==0指自己 对象==1指敌人
                {
                case ("hp", 0):
                    if (fangshi == "+") myhp.hpup(zhisum);
                    else myhp.hpup(myhp.hpmax * zhisum);//此法计算的为最大生命值的百分比 并未有当前生命值的百分别 暂不区分
                    //myhp.hp = Mathf.Clamp(myhp.hp, 0f, myhp.hpmax);
                    break;
                case ("hp", 1):
                    if (fangshi == "+")
                    {
                        drhp.hp += zhisum;
                        zhiadd = zhisum;
                    }
                    else
                    {
                        drhp.hp += drhp.hpmax * zhisum;//此法计算的为最大生命值的百分比 并未有当前生命值的百分别 暂不区分
                        zhiadd = drhp.hpmax * zhisum;
                    }
                    drhp.hp = Mathf.Clamp(drhp.hp, 0f, drhp.hpmax);
                    break;
                case ("shd", 0):
                    if (fangshi == "+") myhp.shd += zhisum;
                    else myhp.shd += myhp.shd * zhisum;//此法计算的为最大生命值的百分比 并未有当前生命值的百分别 暂不区分
                    Debug.Log($"myshd:{myhp.shd}");
                    break;
                case ("mp", 0):
                    if (fangshi == "+") mymp.mp += zhisum;
                    else mymp.mp += mymp.mpmax * zhisum;
                    break;
                case ("mp", 1):
                    if (fangshi == "+") drmp.mp += zhisum;
                    else drmp.mp += drmp.mpmax * zhisum;
                    break;
                case ("atk", 0):
                    if (fangshi == "+") sxchushi.mylssx1.atk += zhisum;
                    else sxchushi.mylssx2.atk += zhisum;
                    myfighter.atkupdata();
                    break;
                case ("dps", 0):
                    if (fangshi == "+") sxchushi.mylssx1.dps += zhisum;
                    else sxchushi.mylssx2.dps += zhisum;
                    myfighter.dpsupdata();
                    break;
                case ("du", 1):
                    if (fangshi == "+") buffchi.chi.buff(0, 2, zhisum);
                    break;
                case ("bingshuang", 1):
                    if (fangshi == "+") buffchi.chi.buff(0, 0, zhisum);
                    break;
                case ("ranshao", 1):
                    if (fangshi == "+") buffchi.chi.buff(0, 3, zhisum);
                    break;
                case ("shang", 1):
                    if (fangshi == "+") buffchi.chi.buff(0, 5, zhisum);
                    break;
            }
        }
        else
        {
            switch (shuxing, duixiang)//shuxing为属性 对象==0指自己 对象==1指敌人
            {
                case ("hp", 0):
                    if (fangshi == "+") drhp.hp += zhisum;
                    else drhp.hp += drhp.hpmax * zhisum;//此法计算的为最大生命值的百分比 并未有当前生命值的百分别 暂不区分
                    //drhp.hp = Mathf.Clamp(drhp.hp, 0f, drhp.hpmax);
                    break;
                case ("hp", 1):
                    if (fangshi == "+")
                    {
                        myhp.hpup(zhisum);
                        zhiadd = zhisum;
                    }
                    else
                    {
                        myhp.hpup(myhp.hpmax * zhisum);//此法计算的为最大生命值的百分比 并未有当前生命值的百分别 暂不区分
                        zhiadd = myhp.hpmax * zhisum;
                    }
                    myhp.hp = Mathf.Clamp(myhp.hp, 0f, myhp.hpmax);
                    break;
                case ("mp", 0):
                    if (fangshi == "+") drmp.mp += zhisum;
                    else drmp.mp += drmp.mpmax * zhisum;
                    break;
                case ("mp", 1):
                    if (fangshi == "+") mymp.mp += zhisum;
                    else mymp.mp += mymp.mpmax * zhisum;
                    break;
                case ("atk", 0):
                    if (fangshi == "+") sxchushi.drlssx1.atk += zhisum;
                    else sxchushi.drlssx2.atk += zhisum;
                    drfighter.atkupdata();
                    break;
                case ("dps", 0):
                    if (fangshi == "+") sxchushi.drlssx1.dps += zhisum;
                    else sxchushi.drlssx2.dps += zhisum;
                    drfighter.dpsupdata();
                    break;
                //case ("du", 1): 这两条目前只有玩家能生效 暂时不管了 
                //    if (fangshi == "+") buffchi.chi.buff(1, 2, zhisum);
                //    break;
                //case ("bingshuang", 1):
                //    if (fangshi == "+") buffchi.chi.buff(1, 0, zhisum);
                //    break;
            }
        }
        return zhiadd;
    }
    public void every18()
    {   
        Debug.Log("受击次数"+myfighter.hitcount);
        if (myfighter.hitcount > 0 && myfighter.hitcount % 4 == 0)
        {
            Debug.Log("反击螺旋");
            everychi.chi.everyshixian(18);
        }
    }
    public async void every15()
    {
        float jiluhp = myhp.hpmax;
        float hpdanwei = myhp.hpmax / 100;
        while (myfighter.fighter)
        {
            await UniTask.Yield();
            int bencikouchu = (int)((jiluhp - myhp.hp) / hpdanwei);
            Debug.Log($"上次记录值{jiluhp},本次值{myhp.hp}，本次单位差{bencikouchu}");
            chi.everyshixian(15, 1, bencikouchu);
            jiluhp -= bencikouchu * hpdanwei;
            jiluhp = myhp.hp;
        }
        Debug.Log("every20Stop");
    }
    public async  void every19()
    {
        float time = everyjs.every[19].chixushijian;
        myhp.hp /= 2;
        
        while (time >0)
        {
            await UniTask.Delay(1000);
            time -= 1;
            Debug.Log($"支援未来剩余{time}秒");
            chi.everyshixian(19);
        }
    }
    public async void every20()
    {
        float jiluhp=myhp.hpmax;
        float hpdanwei = myhp.hpmax/100;
        while (myfighter.fighter)
        {
            await UniTask.Yield();
            if (jiluhp > myhp.hp)
            {
                int bencikouchu = (int)((jiluhp - myhp.hp) / hpdanwei);
                chi.everyshixian(20,1,bencikouchu);
                jiluhp-=bencikouchu*hpdanwei;
            }
            else jiluhp=myhp.hp;
        }
        Debug.Log("every20Stop");
    }
    public void every21()
    {
        if (myfighter.ismyfighter.harmsum >= drhp.hpmax)
        {
            drhp.hp -= 9999;
            Debug.Log("命定之死");
        }
    }
    public void every22()
    {
        Debug.Log("复活吧");
        if (myfighter.neardeathcount == 1)
        {
            myhp.hp = MathF.Max(myhp.hp, 0);
            chi.everyshixian(22);
            Debug.Log("复活");
        }
    }
    public void every24()
    {
        chi.everyshixian(24);
        if (myhp.hp <= myhp.hpmax / 2) chi.everyshixian(22);
    }
    public async void every25()
    {
        sxchushi.mylssx2.atk += 0.1f;
        myfighter.atkupdata();
        bool moshi=false;
        while (myfighter.fighter)
        {
            await UniTask.Yield();
            if (!moshi && myhp.hp > drhp.hp)
            {
                sxchushi.mylssx2.atk += 0.1f;
                myfighter.atkupdata();
                moshi=true;
            }
            else if (moshi && myhp.hp <= drhp.hp)
            {
                sxchushi.mylssx1.atk -= 0.1f;
                myfighter.atkupdata();
                moshi =false;
            }
        }
        Debug.Log("every25stop");
    }
    public void every28()
    {
        myhp.shd += myhp.hponlyupoverflow;
        drhp.hploss(myhp.hponlyupoverflow);
        Debug.Log($"护盾增加{myhp.hponlyupoverflow}");
    }
    public void every30()
    {   
        myhp.shd += myhp.hp * 0.8f;
        myhp.hp *= 0.2f;
        Debug.Log("不朽盾");
    }
    public void every35()
    {
        chi.everyshixian(35);
        Debug.Log("如沐春风");
    }



}

