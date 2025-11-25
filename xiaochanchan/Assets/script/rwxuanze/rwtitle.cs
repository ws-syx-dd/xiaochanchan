using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rwtitle : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public TextMeshProUGUI rwname;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI mptext;
    public TextMeshProUGUI atktext;
    public TextMeshProUGUI dpstext;
    public TextMeshProUGUI mphftext;
    public TextMeshProUGUI bdtext;//被动
    public TextMeshProUGUI dzjstext;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void textupdata(int i)
    {
        id = i;
        rw lsrw = renwujs.rw[i];
        rwname.text = lsrw.name;
        hptext.text = lsrw.hp+"";
        mptext.text = lsrw.mp + "";
        atktext.text = "攻击力:" + lsrw.atk;
        dpstext.text = "攻速:" + lsrw.dps;
        mphftext.text = "能量回复:" + lsrw.mphf;
        bdtext.text =lsrw.bdjieshao;
        dzjstext.text=lsrw.dzjieshao;

        
    }
    public void fanhui()
    {
        if (gameObject.activeSelf) gameObject.SetActive(false);
        else SceneManager.LoadScene("strat");
    }
        

    

}
