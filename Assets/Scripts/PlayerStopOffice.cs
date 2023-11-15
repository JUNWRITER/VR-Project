using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStopOffice : MonoBehaviour
{
    GameObject finishText;// 엔딩 TEXT

    void Start()
    {
        finishText = GameObject.Find("FinishText");

        gameObject.GetComponent<SnapTurnProviderBase>().enabled = false;
        gameObject.GetComponent<ContinuousMoveProviderBase>().enabled = false;

        //finishText.SetActive(false);
        
        Invoke("FinishText", 1f);
    }

    public void FinishText()
    {// 엔딩 TEXT를 가져오겠다
        finishText.GetComponent<FinalEnding>().FadeOnOff();
    }
}