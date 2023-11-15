using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource background;
    //public AudioSource homeGet;

    public void SetMusicVolume(float volume)
    {
        //오디오 볼륨조절
        background.volume = volume;
    }
    //public void HomeGet()
    //{
    //    homeGet = GetComponent<AudioSource>();
    //}
}
