using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CheckDialogue : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;
    private GameObject[] controllers;
    private GameObject target_obj;
    private ObjAttribute target_attr;
    private GameObject script_obj;
    private DisplayDialogue win_fun;
    int i ;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        get_grab_item();
        if(GM.get_state() != target_attr.scene){
            Debug.Log("Wrong scene");
            this.enabled = false;
        }
        else{
            Debug.Log("Correct scene");
            GM.set_talking();
            win_fun.enabled = true;
            win_fun.dialogue_filename = target_attr.dialogue_filename;
            this.enabled = false;
        }
    }
    private void init(){
        // get current game state (store in GameManager)
        GM_obj = GameObject.Find("GameManager");
        GM = GM_obj.GetComponent<GameManager>();
        script_obj = GameObject.Find("Script");
        win_fun = script_obj.GetComponent<DisplayDialogue>();
    }
    // get the grabbed item on controller
    private void get_grab_item(){
        Debug.Log("Game state : " + GM.get_state());
        controllers = GameObject.FindGameObjectsWithTag("GameController");
        for(i = 0 ; i < controllers.Length ; i++){
            target_obj = controllers[i].GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
            if(target_obj != null){
                break;
            }
        }
        target_attr = target_obj.GetComponent<ObjAttribute>();
        Debug.Log("Obj scene : " + target_attr.scene);
    }
}
