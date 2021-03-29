using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;
    public GameObject CS;

    public void Start()
    {
        GM_obj = GameObject.Find("GameManager");
        GM = GM_obj.GetComponent<GameManager>();
    }
    
    public void NextStage()
    {
        GameState Now = GM.get_state();
        GM.set_scene(Now + 1);
        CS.GetComponent<ChangeScene>().enabled = true;
    }
}
