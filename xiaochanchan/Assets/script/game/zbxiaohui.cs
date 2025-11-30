using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class zbxiaohui : MonoBehaviour
{
    // Start is called before the first frame update
    public int xh;
    public int index;
    public GameObject zbtext;
    void Start()
    {
        gameObject.GetComponent<Button>()?.onClick.AddListener(() => xiaohui());
        zbtext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void xiaohui()
    {
        if (zblan.zbl[xh] >= 0 && !zbdr.zb[zblan.zbl[xh]].nothuishou)
        {
            Animator an = gameObject.GetComponent<Animator>();
            bool zt = an.GetBool("xiaohui");
            if (!zt) an.SetBool("xiaohui", true);
            else
            {
                Debug.Log("销毁--序号为:"+zblan.zbl[xh]);

                zblan.zblimg[xh].sprite = null;
                zblan.zbltext[xh].text = null;
                int zhi = zblan.zbl[xh];
                zblan.zbl[xh] = -1;
                zb ls = zbdr.zb[zhi];
                Debug.Log("销毁" );
                zhuangbeichi.xiaoguo(0, ls, -1, zbdr.zbleve[ls.id]);
                an.SetBool("xiaohui", false);
                return;
            }
        }
        
    }
    void xiaohuiend()
    {
        Animator an = gameObject.GetComponent<Animator>();
        an.SetBool("xiaohui",false);
    }
    public void xianshi()//zbtext显示
    {   
        if(index==0&&zblan.zbl[xh]>=0)zbtext.SetActive(true);
        else if (index == 1 && zblan.Drzbl[xh]>=0) zbtext.SetActive(true);

    }
    public void xiaoshi()//zbtext消失
    {
        zbtext.SetActive(false);
    }
    public static void allxiaohui()
    {
        for(int i=0;i<6;i++)
        {
            if (zblan.zbl[i] >= 0)
            {
                zblan.zblimg[i].sprite = null;
                zblan.zbltext[i].text = null;
                zb ls = zbdr.zb[zblan.zbl[i]];
                zblan.zbl[i] = -1;
                Debug.Log("销毁" + ls.leixing + " " + ls.fangshi + " " );
                zhuangbeichi.xiaoguo(0, ls, -1, zbdr.zbleve[ls.id]);
            }
        }
    }

}
