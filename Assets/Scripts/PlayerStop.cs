using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStop : MonoBehaviour
{
    GameObject stop;
    public void Awake()
    {
        stop = GameObject.Find("Hand 1 1");
    }
    public void Stop()
    {
        Invoke("MoveStop", 1);
    }

    void MoveStop()
    {

        // øÚ¡˜¿” ∏ÿ√„
        stop.GetComponent<SnapTurnProviderBase>().enabled = false;
        stop.GetComponent<ContinuousMoveProviderBase>().enabled = false;
    }
}
