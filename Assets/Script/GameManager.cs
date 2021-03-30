using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Reference website : https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html?_ga=2.266262607.1952254344.1616490663-554022353.1614679359

public enum GameState {
    TALKING,
    SCENE0,
    SCENE1,
    SCENE2,
    SCENE3,
    SCENE3_5,
    SCENE4,
    SCENE4_1,
    SCENE4_2,
    SCENE4_3,
    OTHER,
    DISABLE
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    // default display time
    public float dis_time;
    [SerializeField]
    private GameState stage_state;
    [SerializeField]
    private GameState current_state;
    private Dictionary<GameState,string> hint_path_dir = new Dictionary<GameState,string>();
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        set_scene(GameState.SCENE0);
        //initial dir content
        hint_path_dir.Add(GameState.SCENE1,"hint/Scene1.txt");
        hint_path_dir.Add(GameState.SCENE2,"hint/Scene2.txt");
        hint_path_dir.Add(GameState.SCENE3,"hint/Scene3.txt");
    }
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        // SceneManager.LoadScene("Room");
    }

    public GameState get_state(){
        return current_state;
    }

    public void set_scene(GameState next_state){
        switch (next_state)
        {
            case GameState.OTHER:
                current_state = stage_state;
                Debug.Log("Set up scene back to : " + current_state);
                break;
            default:
                stage_state = next_state;
                current_state = next_state;
                Debug.Log("Change scene to : " + current_state);
                break;
        }
    }

    public void set_talking(){
        current_state = GameState.TALKING;
        Debug.Log("Change to : " + current_state);
    }

    public string get_hint_path(){
        string path ;
        hint_path_dir.TryGetValue(current_state,out path);
        Debug.Log("Hint file path : "+ (path == null));
        return path;
    }
}
