using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sxchushi : MonoBehaviour
{
    // Start is called before the first frame update
    public  class shuxing
    {
        public float hp;
        public float shd;
        public float mp;
        public float atk;
        public float dps;
        public float dzbl;
        public float mphf;
    }
    public static int myid=0;
    public static shuxing mysxchishu=new shuxing();
    public static shuxing mysx1 = new shuxing();//1代表加减
    public static shuxing mysx2 = new shuxing();//2代表乘除
    public static shuxing mylssx1= new shuxing();
    public static shuxing mylssx2= new shuxing();
    public static shuxing drsxchishu = new shuxing();
    public static shuxing drsx1 = new shuxing();//1代表加减
    public static shuxing drsx2 = new shuxing();//2代表乘除
    public static shuxing drlssx1= new shuxing();
    public static shuxing drlssx2= new shuxing();

    void Start()
    {


        chushihua();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void chushihua()
    {   
        Debug.Log("myid为:"+myid);
        mysxchishu.hp = renwujs.rw[myid].hp;
        mysxchishu.shd = renwujs.rw[myid].shd;
        mysxchishu.mp = renwujs.rw[myid].mp;
        mysxchishu.atk = renwujs.rw[myid].atk;
        mysxchishu.dps = renwujs.rw[myid].dps;
        mysxchishu.dzbl = 5;
        mysxchishu.mphf = renwujs.rw[myid].mphf;
        mysx1 = new shuxing();
        mysx2.hp = 1;
        mysx2.shd = 1;
        mysx2.mp = 1;
        mysx2.atk = 1;
        mysx2.dps = 1;
        mysx2.dzbl = 1;
        mysx2.mphf = 1;
        drsxchishu.hp = 500;
        drsxchishu.shd = 0;
        drsxchishu.mp = 120;
        drsxchishu.atk = 10;
        drsxchishu.dps = 5f;
        drsxchishu.dzbl = 10;
        drsxchishu.mphf = 5;
        drsx1 = new shuxing();
        drsx2.hp = 1;
        drsx2.shd = 1;
        drsx2.mp = 1;
        drsx2.atk = 1;
        drsx2.dps = 1;
        drsx2.dzbl = 1;
        drsx2.mphf = 1;
    }
}
