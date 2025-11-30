using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class fangjian : NetworkBehaviour
{
    private GameObject dqfangjian;
    public GameObject yuzhi;
    public GameObject pr;
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        ulong id = NetworkManager.Singleton.LocalClientId;
        
        if (IsClient)
        {
            //fangjianjiazai();

        }
    }
    private void Start()
    {
    }

    public void xuanze(GameObject ls)
    {
        if (dqfangjian != null)
        {
            dqfangjian.GetComponent<Image>().color = Color.white;
        }
        dqfangjian = ls;
        dqfangjian.GetComponent<Image>().color = new Color(255, 0, 170, 255);
    }
    public void chuangzao()
    {
        NetworkManager.Singleton.StartHost();
    
        NetworkManager.SceneManager.LoadScene("zdzhunbei", LoadSceneMode.Single);
    }
    public void shuxing()
    {
        NetworkManager.Singleton.StartClient();
    }
    //private void fangjianjiazai()
    //{
    //    GameObject ls = Instantiate(yuzhi, pr.transform);
    //    ls.GetComponent<Button>().onClick.AddListener(() => xuanze(ls));
    //    ls.GetComponentInChildren<TextMeshProUGUI>().text = "·¿¼ä1";
    //}
    public void jiaru()
    {
        NetworkManager.Singleton.StartClient();
    }

}
