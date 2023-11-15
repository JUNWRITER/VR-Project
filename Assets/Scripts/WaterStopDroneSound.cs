using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStopDroneSound : MonoBehaviour
{
    public Animator plantAm;
    public GameObject water1;
    public GameObject water2;
    public GameObject splashSound;
    public AudioSource droneSound;

    public void Update()
    {
        if (plantAm.enabled)
        {
            water1.SetActive(false);
            water2.SetActive(false);
            droneSound.enabled = true;
            Destroy(splashSound,0.5f);
        }
    }
}
