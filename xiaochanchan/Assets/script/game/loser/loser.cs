using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loser : MonoBehaviour
{
    public static int cengshu=0;
    public static int shengyumoney=0;
    [SerializeField]
    private TextMeshProUGUI cengshutitle;
    [SerializeField]
    private TextMeshProUGUI cengshumax;
    [SerializeField]
    private TextMeshProUGUI cengshucount;
    [SerializeField]
    private TextMeshProUGUI cengshusum;
    [SerializeField]
    private TextMeshProUGUI SYMtitle;
    [SerializeField]
    private TextMeshProUGUI SYMcount;
    [SerializeField]
    private TextMeshProUGUI SYMsum;
    [SerializeField]
    private TextMeshProUGUI ZJsumcount;//总计
    [SerializeField]
    private TextMeshProUGUI mojingsum;
    
    // Start is called before the first frame update
    void Start()
    {
        string filepath = Path.Combine(Application.persistentDataPath, "cundang.json");
        string ls = File.ReadAllText(filepath);
        cundangjs.cundang = JsonUtility.FromJson<cundangjs.cundangclass>(ls);
        shengyumoney = moneyscript.money;
       WenBenUpdata(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void again()
    {
        for (int i = 0; i < 8; i++)
        {
            Debug.Log(drbuff.buffimage[i]);
        }
        SceneManager.LoadScene("rwxuanze");
    }
    public void end()
    {
        SceneManager.LoadScene("strat");
    }
    public void WenBenUpdata()
    {   
        int maxcenshu=cundangjs.cundang.maxcengshu;
        int mojing=cundangjs.cundang.mojing;
        cengshutitle.text = $"已到达第{cengshu}层";
        cengshucount.text = $"10*{cengshu}";
        cengshusum.text = $"{cengshu * 10}";
        cengshumax.text = $"最高到达:第{maxcenshu}层";//暂时没写
        SYMtitle.text = $"剩余金钱:{shengyumoney}";
        SYMcount.text = $"2*{shengyumoney}";
        SYMsum.text = $"{shengyumoney * 2}";
        ZJsumcount.text = $"{cengshu * 10 + shengyumoney * 2}";
        mojingsum.text = $"魔晶：({mojing}+{cengshu * 10 + shengyumoney * 2})={mojing + cengshu * 10 + shengyumoney * 2}";
        cundangjs.cundang.mojing += cengshu * 10 + shengyumoney * 2;
        if(cengshu>maxcenshu) cundangjs.cundang.maxcengshu = cengshu;
        string updata=JsonUtility.ToJson(cundangjs.cundang);
        string filepath = Path.Combine(Application.persistentDataPath, "cundang.json");
        File.WriteAllText( filepath,updata);

    }
}
