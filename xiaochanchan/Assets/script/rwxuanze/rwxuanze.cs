using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rwxuanze : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pr;
    public List<Transform> list=new List<Transform>();
    public Image Image;
    public Transform zqxuanze;
    public GameObject rwxz;
    public rwtitle rwtitle;
    public Animator animator;
    void Start()
    {   
        Image.gameObject.SetActive(false);
        rwxz.SetActive(false);
        TextAsset ls = Resources.Load<TextAsset>("js/cundang");
        cundangjs.cundang = JsonUtility.FromJson<cundangjs.cundangclass>(ls.text);
        foreach(Transform t in pr)
        {
            list.Add(t);
            int lssum = list.Count - 1;
            if (!cundangjs.cundang.renwujiesuo[lssum])t.GetComponent<Image>().color = new Color(60/255f,60/255f,60/255f);
            t.GetComponent<Button>().onClick.AddListener(() => genggai(t,lssum));
        }     
    }
    public void genggai(Transform t,int id)
    {
        if (!cundangjs.cundang.renwujiesuo[id])
        {
            animator.Play("rwxuanzetext");
            return;
        }
        rwxz.SetActive(true);
        zqxuanze = t;
        Image.gameObject.SetActive (true);
        Image.sprite=t.GetComponent<Image>().sprite;
        Debug.Log("ÇÐ»»Îªid:" + id);
        rwtitle.textupdata(id);
        aa(id);
    }
    public void tiaozhuan()
    {
        SceneManager.LoadScene("fighter");
    }
    public static void aa(int id)
    {
        sxchushi.myid = id;
    }
}
