using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;
    public GameObject CS;

    public GameObject pic1, pic2;

    private int count = 0;
    private int LINE_COUNT = 10;

    private string[] Lines = {  "在這個故事裏頭", "你將會扮演一位即將決定大學志願的高中生", "阿軒","你可以在他的房間內探索" ,"觸碰到可互動的物體時，會有黃色提示外框","此時可用Grip抓取並觸發事件",
                                "同時外框會變成紅色","在遊戲中，你必須去感受阿軒的苦惱","並且幫他做出決定。","那麼，就讓我們開始吧!"};
    public Text TextWindow;

    public void Start()
    {
        GM_obj = GameObject.Find("GameManager");
        GM = GM_obj.GetComponent<GameManager>();
    }

    public void NextStage()
    {
        if (count < LINE_COUNT)
        {
            TextWindow.text = Lines[count];
            if (count == 4)
            {
                pic1.SetActive(true);
            }
            if (count == 6)
            {
                pic1.SetActive(false);
                pic2.SetActive(true);
            }
            if (count == 7)
            {
                pic2.SetActive(false);
            }
            count++;
        }
        else
            count++;
        if (count > LINE_COUNT)
        {
            TextWindow.text = "";
            GameState Now = GM.get_state();
            GM.set_scene(GameState.SCENE1);
            CS.GetComponent<ChangeScene>().enabled = true;
        }
    }
}
