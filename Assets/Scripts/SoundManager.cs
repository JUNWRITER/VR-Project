using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource background;
    //public AudioSource homeGet;

    public void SetMusicVolume(float volume)
    {
        //����� ��������
        background.volume = volume;
    }
    //public void HomeGet()
    //{
    //    homeGet = GetComponent<AudioSource>();
    //}
}
