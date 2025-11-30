using TMPro;
using UnityEngine;
using Unity.Netcode;

public class gamemanager : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject my;
    public GameObject dr;
    public TextMeshProUGUI myzb;
    public TextMeshProUGUI drzb;
    public TextMeshProUGUI myid;
    public TextMeshProUGUI drid;
    private bool qr = false;
    private void Start()
    {
        myzb.gameObject.SetActive(false);
        drzb.gameObject.SetActive(false);
        dr.SetActive(false);




        NetworkManager.Singleton.OnClientConnectedCallback += id =>
        {
            if (id == 1)
            {
                Debug.Log("加入");
                //qr = true;
                chuandiServerRpc();

            }
        };
    }
    private void Update()
    {
        ulong id = NetworkManager.Singleton.LocalClientId;
        if (qr)
        {
            ClientRpc();
            qr = !qr;
        }
    }

    [ServerRpc]
    private void chuandiServerRpc()
    {
        ClientRpc();
    }
    [ClientRpc]
    private void ClientRpc()
    {
        dr.SetActive(true);
    }
    [ServerRpc(RequireOwnership =false)]
    private void zbServerRpc(ulong id)
    {
        zbClientRpc(id);
    }
    [ClientRpc]
    private void zbClientRpc(ulong id)
    {
        if (NetworkManager.Singleton.LocalClientId == id)
        {   
            myzb.gameObject.SetActive (true);
            myzb.text = "已准备";
        }
        else
        {   
            drzb.gameObject.SetActive (true);
            drzb.text = "已准备";
        }
    }

    public void zhunbei()
    {
        Debug.Log(NetworkManager.Singleton.LocalClientId);
        zbServerRpc(NetworkManager.Singleton.LocalClientId);
    }

}
