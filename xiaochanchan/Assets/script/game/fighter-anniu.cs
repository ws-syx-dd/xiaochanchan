using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fighteranniu: MonoBehaviour
{
    public GameObject suo;
    public int moneydr;
    public TextMeshProUGUI moneytextdr;
    public static TextMeshProUGUI moneytext;
    private int zbllv=1;//装备l栏等级
    public static int xydlv = 1;//稀有度等级
    public TextMeshProUGUI xyddr;
    public static TextMeshProUGUI xydtext;//敌人还有几波进阶
    public static string[] xydgs = { "<color=white>普通</color>", "<color=green>稀有</color>", "<color=#0096FF>罕见</color>", "<color=yellow>珍稀</color>","<color=red>传说</color>" };

    public cardsx sx;//卡牌刷新
    public myfighter myfighter;
    public drfighter drfighter;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {   
        moneyscript.money=moneydr;
        moneytext=moneytextdr;
        FighterEnd(false);
        moneytext.text = moneyscript.money.ToString();
        xydtext = xyddr;
        xyd(xydlv);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fighterstart()
    {
        suo.SetActive(true);
        myfighter.fighter = true;
        drfighter.fighter=true;
        myfighter.ismyfighter.FighterStart();
        drfighter.zd();
        drfighter.everytime();
        myfighter.everytime();
        StartCoroutine(fighterjc());

    }
    void FighterEnd(bool qr=true)
    {
        if (qr)
        {
            if (myhp.hp > 0)
            {
                myfighter.fighterend("win");//每0.1秒检测战斗是否结束
            }
            else
            {
                myfighter.fighterend("loser");//每0.1秒检测战斗是否结束
            }
        }
        suo.SetActive(false);
        sx.allshuaxing();
    }
    IEnumerator fighterjc()//每0.1秒检测战斗是否结束
    {   
        yield return new WaitForSeconds(0.1f);
        if (!myfighter.fighter && !drfighter.fighter)//战斗结束
        {
            Debug.Log("myhp:" + myhp.hp + "drhp:" + drhp.hp);
            
            if (myhp.hp >0)
            {   
               
                donghuastart(1);
                moneyscript.moenyupdata((int)myhp.hp);
                FighterEnd();
            }
            else
            {
                myfighter.fighterend("loser");
            }
           
        }
        else StartCoroutine(fighterjc());
    }

    public void shuaxing()
    {
        if (moneyscript.money >= 1)
        {
            moneyscript.money--; moneytext.text = moneyscript.money.ToString();
            sx.allshuaxing();
        }
     
    }
    public void shengji()
    {
        Debug.Log("111");
        if (moneyscript.money >= 5&&zbllv<=5)
        {
            moneyscript.money -= 5; 
            moneytext.text = moneyscript.money.ToString();
            zbllv++;
            zblan.zbl[zbllv - 1] = -1;
            zblan.zblimg[zbllv-1].sprite = null;
            if (zbllv%2==0)
            {
                xydlv++;
                xyd(xydlv);
            }
            
        }
        
    }
    void donghuastart(int i)
    {
        animator.SetInteger("jieguo", 1);
        Invoke("donghuaend", 0.3f);

    }
    public void donghuaend()
    {
        animator.SetInteger("jieguo", 0);
        myhp.hpupdata();
        mymp.mpupdata();
        drfighter.stronger();
        Debug.Log("敌人升级");
        loser.cengshu++;
    }
    public static void xyd(int i)//稀有度文字提示
    {
        switch (i)
        {
            case 1:
                xydtext.text = "<size=1><color=black><b>当前卡牌稀有度\n</b></color></size>" + $"<size=1.5>{xydgs[0]},{xydgs[1]}</size>";
                break;
            case 2:
                xydtext.text = "<size=1><color=black><b>当前卡牌稀有度\n</b></color></size>" + $"<size=1.5>{xydgs[0]},{xydgs[1]},\n{xydgs[2]}</size>";
                break;
            case 3:
                xydtext.text = "<size=1><color=black><b>当前卡牌稀有度\n</b></color></size>" + $"<size=1.5>{xydgs[0]},{xydgs[1]},\n{xydgs[2]}{xydgs[3]}</size>";
                break;
            case 4:
                xydtext.text = "<size=1><color=black><b>当前卡牌稀有度\n</b></color></size>" + $"<size=1.5>{xydgs[0]},{xydgs[1]},\n{xydgs[2]}{xydgs[3]},\n{xydgs[4]}</size>";
                break;
        }
    }

    
}
