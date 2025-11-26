using System.Collections;
using System.Collections.Generic;
//using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class steamchushi : MonoBehaviour
{
    //// Start is called before the first frame update
    //public Image touxiang;
    //public TextMeshProUGUI minzi;
    //public CSteamID steamid;

    //void Start()
    //{   
    //    SteamAPI.Init();
    //    steamid=SteamUser.GetSteamID();
    //    minzi.text=SteamFriends.GetPersonaName();
    //    touxiangshengcheng();
       
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    //public void touxiangshengcheng()
    //{
    //    int avatar = SteamFriends.GetLargeFriendAvatar(steamid);
    //    uint w, h;
    //    SteamUtils.GetImageSize(avatar,out w, out h);
    //    byte[] image=new byte[w*h*4];
    //    SteamUtils.GetImageRGBA(avatar, image, (int)(w * h * 4));
    //    Texture2D avatartextue=new Texture2D((int)w,(int)h, TextureFormat.RGBA32, false);
    //    avatartextue.LoadRawTextureData(image);
    //    avatartextue.Apply();
    //    touxiang.sprite=Sprite.Create(avatartextue,new Rect(0,0,avatartextue.width,avatartextue.height),Vector2.one*0.5f);
    //}
}
