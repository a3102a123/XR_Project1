using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class DisplayDialogue : MonoBehaviour
{
    private bool is_show = false;
    private bool is_read = false;
    private string root_path = "./Assets/Dialogue/";
    private string path;
    System.IO.StreamReader file;

    public Text TextWindow;
    public string dialogue_filename;
    public GameState next_state;

    int i ;
    string str;
    // Update is called once per frame
    void Update()
    {
        if(!is_show)
            init();
        if(is_show)
        {
            if(is_read){
                if(next_state != GameState.OTHER){
                    if((str = file.ReadLine()) != null){ 
                        is_read = false;
                        TextWindow.text = str;
                        Debug.Log(str);
                        // Debug.Log("wait begin" + Time.time);
                        Invoke("wait",GameManager.GM.dis_time);
                    }
                    else{
                        is_show = false;
                    }
                }
                else{
                    if(!file.EndOfStream){ 
                        //count line number of dialogue file & store dialogue
                        int  line_num = 0,idx;
                        List<string> str_arr = new List<string>();
                        while((str = file.ReadLine()) != null){
                            line_num++;
                            str_arr.Add(str);
                        }
                        // random select dialogue
                        idx = Random.Range(0,line_num);
                        TextWindow.text = str_arr[idx];
                        Debug.Log(str_arr[idx]);
                        Debug.Log("choice / other line num : " + idx + "/" + line_num);
                        Invoke("wait",GameManager.GM.dis_time);
                        is_read = false;
                    }
                    else{
                        is_show = false;
                    }
                }
            }
        }
        // end the dialogue
        if(!is_show){
            stop();
        }
    }

    void init(){
        // Debug.Log("hellow, welcome to dialogue");
        Debug.Log("Loading " + dialogue_filename);
        path = root_path + dialogue_filename;
        file = new System.IO.StreamReader(@path);
        TextWindow.gameObject.SetActive(true);
        is_show = true;
        is_read = true;
    }

    void stop(){
        Debug.Log( dialogue_filename + " Finish! Next scene is : " + next_state);
        GameManager.GM.set_scene(next_state);
        TextWindow.gameObject.SetActive(false);
        file.Close();
        this.enabled = false;
    }

    //controller trigger dialogue continue
    void continue_read(){
        Debug.Log("In continue read");
        is_read = true;
    }

    //default dialogue display time,continue when time out
    void wait(){
        is_read = true;
        Debug.Log("In wait");
        // Debug.Log("wait end" + Time.time);
    }
}
