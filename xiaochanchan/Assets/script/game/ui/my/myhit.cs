using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Start is called before the first frame update
    public  TextMeshProUGUI hittext;
    public  Animator hitanimtor;
    void Start()
    {
    }

    // Update is called once per frame
    public void Animatorstart(float i)
    {
        hittext.text = i + "";
        hitanimtor.Play("shouji",-1,0f);
    }
    public void animatorend()
    {
        Destroy(gameObject);
    }
}
