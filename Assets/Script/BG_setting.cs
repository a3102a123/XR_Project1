using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BG_setting : MonoBehaviour
{
    public GameObject player;
    public Text TextWindow;
    [SerializeField]
    private Image fadeImage;

    [SerializeField]
    private float delay;

    [SerializeField]
    private Color Fadeout_color;

    float begin_time;
    float current_time;
    Color Image_color;
    private GameObject script_obj;
    private DisplayDialogue win_fun;

    //----------------------------------

    bool init_flag = true;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GM.get_state() == GameState.SCENE4)
        {
            //player.transform.localPosition = Vector3.zero;
            player.transform.position = new Vector3(-2f, 0.173f, 0f);
        }
        else if(GameManager.GM.get_state() == GameState.SCENE4_2)
        {
            init("Good_End.txt", GameState.SCENE4_2);
            fade_out();
            show_end();
        }
        else if (GameManager.GM.get_state() == GameState.SCENE4_3)
        {
            init("Bad_End.txt", GameState.SCENE4_3);
            fade_out();
            show_end();
        }
    }

    void init(string file_name, GameState state)
    {
        if (init_flag)
        {
            begin_time = Time.time;
            fadeImage.gameObject.SetActive(true);
            init_flag = false;
            Image_color = fadeImage.color;
            //find displaydialogue function
            script_obj = GameObject.Find("Script");
            win_fun = script_obj.GetComponent<DisplayDialogue>();
            //set up function argv
            win_fun.dialogue_filename = file_name;
            win_fun.next_state = state;
            //set up GM to infinite display
            GameManager.GM.dis_time = 100000;
            //set up text window
            TextWindow.fontSize = 80;
            TextWindow.rectTransform.sizeDelta = new Vector2(700, 1000);
            win_fun.enabled = true;
        }
    }
    void fade_out()
    {
        current_time = Time.time;
        t = current_time - begin_time;
        if (t < delay)
            fadeImage.color = Color.Lerp(Image_color, Fadeout_color, t / delay);
    }

    void show_end()
    {
        //let text fade out with image & show in the end
        if (t < delay)
            TextWindow.color = Color.Lerp(Image_color, Fadeout_color, t / delay);
        else
            TextWindow.color = Color.white;
    }
}


