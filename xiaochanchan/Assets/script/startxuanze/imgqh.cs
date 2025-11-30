
using UnityEngine;
using UnityEngine.SceneManagement;

public class imgqh : MonoBehaviour
{
    public Sprite img1;
    public Sprite img2;
    private Vector3 size;
    private void Start()
    {
        size = transform.localScale;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void qh1_2()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = img2;
        gameObject.transform.localScale = new Vector3(size.x * 1.1f, size.y * 1.1f, size.z);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void qh2_1()
    {
        gameObject.GetComponent <SpriteRenderer>().sprite = img1;
        gameObject.transform.localScale = new Vector3(size.x/1.1f, size.y/1.1f,size.z);
        transform.GetChild(0).gameObject.SetActive(false);

    }
    public void onlyfighter()
    {
        SceneManager.LoadScene("rwxuanze");
    }
    public void playerfighter()
    {
        SceneManager.LoadScene("fangjian");
    }
    public void gotujian()
    {
        SceneManager.LoadScene("tujian");
    }
    public void gohome()
    {
        SceneManager.LoadScene("home");
    }
}
