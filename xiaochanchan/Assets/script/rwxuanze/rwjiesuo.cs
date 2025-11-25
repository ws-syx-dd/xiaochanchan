using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rwjiesuo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pr;
    public List<Transform> list = new List<Transform>();
    public Image Image;
    public Transform zqxuanze;
    public GameObject rwxz;
    public rwtitle rwtitle;
    public TextMeshProUGUI mojingcount;
    public int id;
    void Start()
    {
        Image.gameObject.SetActive(false);
        rwxz.SetActive(false);
        string filepath = Application.streamingAssetsPath + "/cundang.json";
        string ls = File.ReadAllText(filepath);
        cundangjs.cundang = JsonUtility.FromJson<cundangjs.cundangclass>(ls);
        mojingcount.text = $"{cundangjs.cundang.mojing}";
        foreach (Transform t in pr)
        {
            list.Add(t);
            int lssum = list.Count - 1;
            if (!cundangjs.cundang.renwujiesuo[lssum]) t.GetComponent<Image>().color = new Color(60 / 255f, 60 / 255f, 60 / 255f);
            t.GetComponent<Button>().onClick.AddListener(() => genggai(t, lssum));
        }
    }
    public void genggai(Transform t, int id)
    {   
        this.id = id;
        rwxz.SetActive(true);
        zqxuanze = t;
        Image.gameObject.SetActive(true);
        Image.sprite = t.GetComponent<Image>().sprite;
        rwtitle.textupdata(id);
    }
    public void jiesuo()
    {
        if (cundangjs.cundang.mojing >= 100)
        {
            cundangjs.cundang.mojing -= 100;
            cundangjs.cundang.renwujiesuo[id]=true;
            string updata = JsonUtility.ToJson(cundangjs.cundang);
            string filepath = Path.Combine(Application.streamingAssetsPath, "cundang.json");
            mojingcount.text = $"{cundangjs.cundang.mojing}";
            list[id].GetComponent<Image>().color=new Color(1,1,1, 1);
            rwxz.SetActive(false);
            File.WriteAllText(filepath, updata);
        }
    }
}
