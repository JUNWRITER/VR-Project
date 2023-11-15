using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnding : MonoBehaviour
{
    public GameObject one, two, three, zero;
    
    public void FadeOnOff()
    {
        Invoke("Zero", 5);
        Invoke("One", 5);
        Destroy(one, 8);
        Invoke("Two", 8);
        Destroy(two,11);
        Invoke("Three", 11);
    }
    private void Zero()
    {
        if (zero != null)
            zero.SetActive(true);
    }
    private void One()
    {
        if (one != null) 
        one.SetActive(true);
    }
    private void Two()
    {
        if (two != null)
            two.SetActive(true);
    }
    private void Three()
    {
        if (three != null)
            three.SetActive(true);
    }
}
