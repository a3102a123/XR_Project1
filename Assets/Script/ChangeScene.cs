//reference from : https://forum.unity.com/threads/scene-fade-out.620518/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string next_scene;
    public GameState next_scene_state;
    [SerializeField]
    private Image fadeImage;
 
    [SerializeField]
    private float delay;
 
    [SerializeField]
    private Color Fadeout_color;
 
    [SerializeField]
    private Color Fadein_color;
 
    public bool sceneFading;

    float begin_time;
    float current_time;
    Color Image_color;
 
    //----------------------------------
    
    bool init_flag = true;
    private void Update()
    {
        if(GameManager.GM.get_state() == next_scene_state){
            // SceneManager.LoadScene(next_scene);
            if(init_flag){
                begin_time = Time.time;
                fadeImage.gameObject.SetActive(true);
                init_flag = false;
                Image_color = fadeImage.color;
                Debug.Log(Image_color);
            }
        }
        else{
            this.enabled = false;
            return;
        }
        current_time = Time.time;
        float t = current_time - begin_time;
        if(t < delay)
            fadeImage.color = Color.Lerp(Image_color, Fadeout_color, t/delay);
        else{
            SceneManager.LoadScene(next_scene);
            this.enabled = false;
        }
    }
}
