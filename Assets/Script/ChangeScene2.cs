using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene2 : MonoBehaviour
{
    private GameObject script_obj;
    private ChangeScene change_scene;
    private DisplayDialogue win_fun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log("this.enabled");
      Debug.Log(GameManager.GM.get_state());
      if(GameManager.GM.get_state() == GameState.SCENE3_5){
          Debug.Log("change2");
          script_obj = GameObject.Find("Script");
          change_scene = script_obj.GetComponent<ChangeScene>();
          change_scene.enable_scene_state = GameState.SCENE4;
          win_fun = script_obj.GetComponent<DisplayDialogue>();
          win_fun.dialogue_filename = "scene3_5.txt";
          win_fun.next_state = GameState.SCENE4;
          win_fun.enabled = true;
      }
      this.enabled = false;
      return;
    }
}
