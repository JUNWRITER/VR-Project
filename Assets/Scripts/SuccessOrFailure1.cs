using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuccessOrFailure1 : MonoBehaviour
{
    //���� ���� ��� OnTriggerEnter �̸�~
    GameObject[] success;
    public GameObject aPileOfGarbage;

    //���н� Fade����
    public GameObject player, fade;

    // ���н� ����
    GameObject stop;

    [SerializeField]
    [Range(0.01f, 10f)] public float time;

    float sceneOffTime = 1f;

   // public GameObject finishText;
    public GameObject finishBadText;

    //FinalEnding��ũ��Ʈ ��������1
   // FinalEnding finishSC;
    FinalEndingBad finishBadSC;

    public void Awake()
    {
        // �±׷� �������� ��������
        success = GameObject.FindGameObjectsWithTag("SuccessOrFailure");

        //FinalEnding��ũ��Ʈ ��������2
       // finishSC = finishText.GetComponent<FinalEnding>();
        finishBadSC = finishBadText.GetComponent<FinalEndingBad>();

        stop = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter(Collider other)
    {
        int activeObjectCount = success.Count(obj => obj.activeSelf);
        //��Ȱ��ȭ�� ����

        // �����ִ� �±��� ��( ��, �������� ���� �����Ѱ�)
        if (activeObjectCount >= 5)//5678
        {
            //Debug.Log($"���� {activeObjectCount}");
            aPileOfGarbage.SetActive(true);

            Invoke("FadeBadText", sceneOffTime);
        }
        //else if (activeObjectCount <= 4)//1234
        //{
        //    Debug.Log($"���� {activeObjectCount}");
        //}
    }

    void FadeBadText()
    {
        stop.GetComponent<PlayerStop>().Stop();
        finishBadSC.FadeOnOff1();
    }
}
