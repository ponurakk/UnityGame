using UnityEngine.UI;
using UnityEngine;

public class togglePause : MonoBehaviour
{
    public GameObject panel;
    public Sprite p;
    public Sprite un;
    public Image imagee;
    private bool pause = false;

    void Start()
    {
        imagee.sprite = un;
        pause = false;
    }

    public void click()
    {
        if (pause)
        {
            Time.timeScale = 0;
            pause = false;
            imagee.sprite = p;
        }
        else if (!pause)
        {
            Time.timeScale = 1;
            pause = true;
            imagee.sprite = un;
        }
    }
}
