using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStar : MonoBehaviour
{
    public GameObject star;
    void Start()
    {
        Invoke("StarOn", 1.7f);

    }

    void StarOn()
    {
        star.SetActive(true);
    }

}
