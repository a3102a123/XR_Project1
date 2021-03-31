using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private GameObject GM_obj;
    private GameManager GM;

    private GameState Now = GameState.SCENE1;
    public AudioSource m_AudioSource;
    public AudioSource cellphone;
    public AudioClip[] ClipList;

    private bool playing = false;
    public void Start()
    {
        GM_obj = GameObject.Find("GameManager");
        GM = GM_obj.GetComponent<GameManager>();
        Now = GM.get_state();
    }
    public void Update()
    {
        Now = GM.get_state();
        if (Now != GameState.DISABLE && Now != GameState.OTHER && Now != GameState.TALKING)
        {
            if (Now == GameState.SCENE2)
            {
                if (!playing)
                {
                    playPhoneRing();
                    playing = true;
                }
            }

        }
    }
    public void playOpenDoor()
    {
        m_AudioSource.clip = ClipList[0];
        m_AudioSource.volume = 1.0f;
        m_AudioSource.Play();
    }
    public void playTouchObject()
    {
        m_AudioSource.clip = ClipList[1];
        m_AudioSource.volume = 0.5f;
        m_AudioSource.Play();
    }
    public void playGrabObject()
    {
        m_AudioSource.clip = ClipList[2];
        m_AudioSource.volume = 0.5f;
        m_AudioSource.Play();
    }
    public void playPhoneRing()
    {
        cellphone.loop = true;
        cellphone.clip = ClipList[3];
        cellphone.volume = 0.1f;
        cellphone.Play();
    }
    public void DisablePhoneRing()
    {
        cellphone.enabled = false;
    }

}
