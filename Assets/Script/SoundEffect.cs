using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public AudioClip[] ClipList;

    public void playOpenDoor()
    {
        m_AudioSource.clip = ClipList[0];
        m_AudioSource.Play();
    }
    public void playTouchObject()
    {
        m_AudioSource.clip = ClipList[1];
        m_AudioSource.Play();
    }
    public void playGrabObject()
    {
        m_AudioSource.clip = ClipList[2];
        m_AudioSource.Play();
    }

}
