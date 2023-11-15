using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeGet : MonoBehaviour
{
    //[SerializeField] float getTime = 3.0f;
    public GameObject getObj;
    public GameObject getUi;

    AudioSource sound;
    private void Awake()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    public void GetTime()
    {
        sound.PlayOneShot(sound.clip);
        Destroy(getObj, 1f);
        Destroy(getUi, 1f);
    }
}
