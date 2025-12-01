using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dazhaochi : MonoBehaviour
{
    public static dazhaochi chi;
    private void Awake()
    {
        if(chi == null)
        {
            chi=this;
        }
    }
    public void dazhao(int i,int duixang)
    {
        switch (i)
        {
            case 0:
                buffchi.chi.buff(duixang, 2, 6);
                break ;
            case 1:
                if (duixang == 0)
                {
                    drhp.hploss(myfighter.atk * 10);
                    myfighter.ismyfighter.everybig(myfighter.atk * 10);

                }
                else myfighter.everyhit(drfighter.atk * 10);
                break;
            case 2:
                if (duixang == 0) myfighter.everyatk(int.Parse(fighteranniu.moneytext.text)*10);
                else myfighter.everyhit(int.Parse(fighteranniu.moneytext.text) * 10);
                break;
            case 3:
                buffchi.chi.buff(duixang, 3, 99);
                break;
            case 4:
                if (duixang == 0) myfighter.everyatk(myfighter.atk * myfighter.dps * 5);
                else myfighter.everyhit(drfighter.atk * drfighter.dps * 5);
                break;
            case 5:
                if (duixang == 0)
                {
                    float atk = myfighter.atk*2;
                    myhp.hp += atk;
                    myhp.hpupdata();
                    myfighter.everyatk(atk);
                }
                else
                {
                    float atk = drfighter.atk * 2;
                    drhp.hp += atk;
                    drhp.hpupdata();
                    myfighter.everyhit(atk);
                    
                }
                break;
        }
    }
}

