using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class citiaoall : MonoBehaviour
{
    public static citiaoall citiao;
    [SerializeField]
    private GameObject yuzhi;
    public List<citiaoonly> citiaoonlies = new List<citiaoonly>();
    public TextMeshProUGUI moneytext;
    // Start is called before the first frame update
    private void Awake()
    {
        if(citiao == null)citiao=this;
    }
    private void OnEnable()
    {
        string filepath = Path.Combine(Application.persistentDataPath, "cundang.json");//此文件位置不在编辑器内 其存在于C:/Users/wssyxdd/AppData/LocalLow/DefaultCompany/xiaochanchan
        //Debug.Log(filepath);
        string text = File.ReadAllText(filepath);
        cundangjs.cundang = JsonUtility.FromJson<cundangjs.cundangclass>(text);
        moneytext.text=cundangjs.cundang.mojing+"";
        for (int i = 0; i < cundangjs.cundang.citiaocout.Length; i++)
        {
            GameObject ls = Instantiate(yuzhi, transform);
            ls.transform.localPosition = new Vector3(0, -i*1.5f, 0);
            ls.name =i+"";
            citiaoonlies.Add(ls.GetComponent<citiaoonly>());
            citiaoonlies[i].id = i;
            citiaoonlies[i].chushihua();

        }
    }
    private void OnDisable()
    {
        for(int i = 0; i < citiaoonlies.Count; i++)
        {
            cundangjs.cundang.citiaocout[i] = citiaoonlies[i].count;
            Destroy(citiaoonlies[i].gameObject);
        }
        citiaoonlies.Clear();
        string updata = JsonUtility.ToJson(cundangjs.cundang);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "cundang.json"), updata);
        transform.parent.gameObject.SetActive(false);
    }
    public void MoneyUpdate()
    {
        moneytext.text = cundangjs.cundang.mojing+"";
    }


    // Update is called once per frame

}
