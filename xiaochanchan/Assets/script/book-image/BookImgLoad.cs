using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookImgLoad : MonoBehaviour
{
    [SerializeField]
    private int sum;
    [SerializeField]
    private int conut;
    [SerializeField]
    private float detaly;
    [SerializeField]
    private GameObject card;
    [SerializeField]
    private ScrollRect scrollRect;
    [SerializeField]
    public static int dangqianzhuangbei = 0;
    private Vector2 ImgSize;
    private LinkedList<GameObject> list = new LinkedList<GameObject>();
    private float pianyiy = 1;
    public static List<int>[] zhuangbei = new List<int>[6];
    public List<GameObject> anniu=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            zhuangbei[i] = new List<int>();
            int index = i;
            anniu[i].GetComponent<Button>().onClick.AddListener(() => qiehuan(index));

         }
        TextAsset ls=Resources.Load<TextAsset>("js/zbtext");
        zbdr.zb = JsonUtility.FromJson<zblist>(ls.text).list;
        Sprite[] lsimg = Resources.LoadAll<Sprite>("img/zb");
        List<Sprite> sprites = new List<Sprite>(lsimg);
        zbdr.zbimgall = sprites;
        conut=zbdr.zb.Count;
        foreach(zb dqzb in zbdr.zb)
        {
            int index=dqzb.id;
            int money=dqzb.money;
            zhuangbei[0].Add(index);
            switch (money)
            {
                case 1:
                    zhuangbei[1].Add(index);
                    break;
                case 2:
                    zhuangbei[2].Add(index);
                    break;
                case 3:
                    zhuangbei[3].Add(index);
                    break;
                case 5:
                    zhuangbei[4].Add(index);
                    break;
                case 10:
                    zhuangbei[5].Add(index);
                    break;
            }
        }
        Startload(0).Forget();
    }
    private void OnEnable()
    {
        OnEnableload().Forget();
    }
    void OnScrollRectValueChanged(Vector2 vector)
    {
        float deltaY = vector.y - pianyiy;
        if (Mathf.Abs(deltaY) >= detaly)
        {
            // 计算需要移动的行数（取整方向要正确）
            int moveRows = Mathf.RoundToInt(deltaY / detaly);
            // 修复当前行计算
            int currentH = Mathf.RoundToInt((1 - vector.y) / detaly);
            Debug.Log($"滑动方向: {(deltaY > 0 ? "向下" : "向上")}, 移动{moveRows}行, 当前h={currentH}, 偏移量={vector.y}");
            if (moveRows > 0) // 向下滑动
            {
                for (int row = 0; row < moveRows; row++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (list.Count == 0) break;
                        GameObject ls = list.Last.Value;
                        // 修复目标行计算
                        int targetH = currentH - moveRows + row;
                        ls.transform.localPosition = new Vector3((i % 3) * 3.5f, targetH * -4, 0);
                        ls.name = (targetH * 3 + i).ToString();
                        wupingpanduan(ls, (targetH * 3 + i));
                        list.RemoveLast();
                        list.AddFirst(ls);
                    }
                }
            }
            else if (moveRows < 0) // 向上滑动
            {
                moveRows = Mathf.Abs(moveRows);
                for (int row = 0; row < moveRows; row++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (list.Count == 0) break;
                        GameObject ls = list.First.Value;
                        // 修复目标行计算
                        int targetH = currentH + 3 + row - 1;
                        ls.GetComponent<RectTransform>().localPosition = new Vector3((i % 3) * 3.5f, targetH * -4f, 0);
                        ls.name = (targetH * 3 + i).ToString();
                        wupingpanduan(ls, (targetH * 3 + i));
                        list.RemoveFirst();
                        list.AddLast(ls);
                    }
                }
            }
            // 立即更新偏移量
            pianyiy = vector.y;
            Debug.Log($"滑动后偏移量: {pianyiy}, 当前h={Mathf.RoundToInt((1 - pianyiy) / detaly)}");
        }
    }

    private async UniTask Startload(int index)
    {   
        gameObject.transform.position = new Vector3(transform.position.x, 0, 0);
        foreach(GameObject gameObject in list)
        {
           Destroy(gameObject);
        }
        list.Clear();
        scrollRect.onValueChanged.RemoveAllListeners();
        conut = zhuangbei[index].Count;
        pianyiy = 1;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(10, (4 *(conut + 2)/3)-1f);
        ImgSize = card.GetComponent<RectTransform>().sizeDelta;
        detaly = (15* 0.255f) / (rectTransform.sizeDelta.y - (10.5f));
        for (int i = 0; i < Mathf.Min(sum, zhuangbei[index].Count); i++)
        {
            await UniTask.Yield();
            GameObject ls = Instantiate(card, transform);
            ls.GetComponent<RectTransform>().localPosition= new Vector3((i % 3) * 3.5f, (i / 3) *-4f, 0);
            ls.name = i.ToString();
            list.AddLast(ls);
            wupingpanduan(ls, i);
        }
        scrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
        return;
    }
    private async UniTask OnEnableload()
    {
        for (int i = 0; i < list.Count; i++)
        {
            await UniTask.Yield();
            GameObject ls = list.Last.Value;
            int index = int.Parse(ls.name);
            wupingpanduan(ls, index);
            list.AddFirst(ls);
            list.RemoveLast();
        }
        return;
    }
    private void wupingpanduan(GameObject ls, int index)
    {
        ls.GetComponent<BookCard>().ThisUpdata(index);
    }
    public void back()
    {
        SceneManager.LoadScene("strat");
    }
    public void qiehuan(int i)
    {
        dangqianzhuangbei = i;
        Debug.Log(zhuangbei[dangqianzhuangbei].Count);
        Debug.Log(zhuangbei[dangqianzhuangbei]);
        Startload(i).Forget();

    }
}
