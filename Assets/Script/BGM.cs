using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;
    public AudioSource mAudioSource;
    public AudioClip[] BGMs;

    private GameState Now = GameState.SCENE1;

    private bool playing = false;
    public void Start()
    {
        GM_obj = GameObject.Find("GameManager");
        GM = GM_obj.GetComponent<GameManager>();
        Now = GM.get_state();
    }
    public void ChangeScene()
    {
        Now = GM.get_state();
        playing = false;
    }
    public void Update()
    {
        if (Now == GameState.SCENE0)
        {
            if (!playing)
            {
                mAudioSource.clip = BGMs[0];
                mAudioSource.Play();
                Debug.Log("Playing Scene0");
                playing = true;
            }
        }
        if (Now == GameState.SCENE1)
        {
            if (!playing)
            {
                mAudioSource.clip = BGMs[0];
                mAudioSource.Play();
                Debug.Log("Playing Scene1");
                playing = true;
            }
        }
        if (Now == GameState.SCENE2)
        {
            if (!playing)
            {
                mAudioSource.clip = BGMs[1];
                mAudioSource.volume = 0.1f;
                mAudioSource.Play();
                Debug.Log("Playing Scene2");
                playing = true;
            }
        }        
        if (Now == GameState.SCENE3)
        {
            if (!playing)
            {
                mAudioSource.clip = BGMs[0];
                mAudioSource.Play();
                Debug.Log("Playing Scene3");
                playing = true;
            }
        }        
        if (Now == GameState.SCENE4)
        {
            if (!playing)
            {
                mAudioSource.clip = BGMs[1];
                mAudioSource.Play();
                Debug.Log("Playing Scene4");
                playing = true;
            }
        }
    }
}
