using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class DisplayDialogue : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;

    private bool is_show = true;
    private string root_path = "./Assets/Dialogue/";
    System.IO.StreamReader file;

    public Text TextWindow;
    public string dialogue_filename;

    int i ;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        init();
        while (is_show)
        {
            string str;
            if((str = file.ReadLine()) != null){ 
                TextWindow.text = str;
                Debug.Log(str);
            }
            else{
                is_show = false;
            }
        }
        // end the dialogue
        this.enabled = false;
    }

    void init(){
        Debug.Log("hellow, welcome to dialogue");
        Debug.Log("Loading " + dialogue_filename);
        string path = root_path + dialogue_filename;
        file = new System.IO.StreamReader(@path);
        TextWindow.gameObject.SetActive(true);
        is_show = true;
    }

}
