using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStopOffice : MonoBehaviour
{
    GameObject finishText;// ���� TEXT

    void Start()
    {
        finishText = GameObject.Find("FinishText");

        gameObject.GetComponent<SnapTurnProviderBase>().enabled = false;
        gameObject.GetComponent<ContinuousMoveProviderBase>().enabled = false;

        //finishText.SetActive(false);
        
        Invoke("FinishText", 1f);
    }

    public void FinishText()
    {// ���� TEXT�� �������ڴ�
        finishText.GetComponent<FinalEnding>().FadeOnOff();
    }
}