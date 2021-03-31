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
    public void Update()
    {
        GameState round = GM.get_state();
        if (round != GameState.DISABLE && round != GameState.OTHER && round != GameState.TALKING)
        {
            if(Now != round)
            {
                Now = round;
                if (round != GameState.SCENE4_1)
                {
                    mAudioSource.Stop();
                    playing = false;
                }
            }
            if (Now == GameState.SCENE0)
            {
                if (!playing)
                {
                    mAudioSource.clip = BGMs[0];
                    mAudioSource.volume = 0.15f;
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
                    mAudioSource.volume = 0.1f;
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
                    mAudioSource.volume = 0.8f;
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
                    mAudioSource.volume = 0.15f;
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
                    mAudioSource.volume = 0.15f;
                    mAudioSource.Play();
                    Debug.Log("Playing Scene4");
                    playing = true;
                }
            }
            if (Now == GameState.SCENE3_5)
            {
                if (!playing)
                {
                    mAudioSource.clip = BGMs[2];
                    mAudioSource.volume = 0.15f;
                    mAudioSource.Play();
                    Debug.Log("Playing Scene3_5");
                    playing = true;
                }
            }
            if (Now == GameState.SCENE4_2)
            {
                if (!playing)
                {
                    mAudioSource.clip = BGMs[3];
                    mAudioSource.volume = 0.5f;
                    mAudioSource.Play();
                    Debug.Log("Playing Scene4_2");
                    playing = true;
                }
            }
            if (Now == GameState.SCENE4_3)
            {
                if (!playing)
                {
                    mAudioSource.clip = BGMs[2];
                    mAudioSource.volume = 0.05f;
                    mAudioSource.Play();
                    Debug.Log("Playing Scene4_3");
                    playing = true;
                }
            }
        }
    }
}
