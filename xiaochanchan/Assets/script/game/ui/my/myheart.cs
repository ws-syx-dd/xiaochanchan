using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myheart : MonoBehaviour
{   
    public static List<GameObject> heart=new List<GameObject>();
    public static int heartcount = 0;
    // Start is called before the first frame update
    void Start()
    {
       foreach(Transform i in transform)
        {
            Debug.Log(i.name);
            heart.Add(i.gameObject);
        }
       heartcount=heart.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
