using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dranimator : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<RuntimeAnimatorController> Controller = new List<RuntimeAnimatorController>();
    public static Animator donghuang;
    void Start()
    {
        RuntimeAnimatorController[] ls = Resources.LoadAll<RuntimeAnimatorController>("animator/dr");
        Controller = ls.ToList();
        donghuang = gameObject.GetComponent<Animator>();
        animatorupdata();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void animatorupdata()
    {   
        donghuang.runtimeAnimatorController=Controller[drfighter.dqboci];
        
    }
}
