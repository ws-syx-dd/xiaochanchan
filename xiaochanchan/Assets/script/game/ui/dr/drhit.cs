using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class drhit : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI hittext;
    public static Animator hitanimtor;
    void Start()
    {
        hittext = GetComponent<TextMeshProUGUI>();
        hitanimtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    public static void Animatorstart(float i)
    {
        hittext.text = i + "";
        hitanimtor.Play("shouji", -1, 0f);
        drfighter.donghua.Play("hit", 1, 0f);
    }
}
