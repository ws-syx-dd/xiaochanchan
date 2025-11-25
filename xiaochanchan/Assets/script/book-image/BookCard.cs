using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookCard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI money;
    [SerializeField]
    private Image cardcolor;
    public void ThisUpdata(int index)
    {
        if (index >= BookImgLoad.zhuangbei[BookImgLoad.dangqianzhuangbei].Count)
        {
            gameObject.SetActive(false);
            return;
        }
        else if(index>=0)
        {
            int i = BookImgLoad.zhuangbei[BookImgLoad.dangqianzhuangbei][index];
            gameObject.SetActive(true);
            image.sprite = zbdr.zbimgall[i];
            name.text = zbdr.zb[i].name;
            title.text = zbdr.zb[i].jieshao;
            money.text = zbdr.zb[i].money + "";
            switch (zbdr.zb[i].money)
            {
                case 1:
                    gameObject.GetComponent<Image>().color = Color.white;
                    break;
                case 2:
                    gameObject.GetComponent<Image>().color = Color.green;
                    break;
                case 3:
                    gameObject.GetComponent<Image>().color = new Color(0, 150, 255, 255);
                    break;
                case 5:
                    gameObject.GetComponent<Image>().color = Color.yellow;
                    break;
                case 10:
                    gameObject.GetComponent<Image>().color = Color.red;
                    break;

            }
        }
    }
}
