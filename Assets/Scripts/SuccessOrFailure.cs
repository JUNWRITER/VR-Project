using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.XR.CoreUtils;
using System;
using Unity.VisualScripting;
using System.Runtime.ConstrainedExecution;

public class SuccessOrFailure : MonoBehaviour
{
    //���� ���� ��� OnTriggerEnter �̸�~
    GameObject[] success;
    GameObject[] puzzle;
    public GameObject aPileOfGarbage;

    //������ idcard
    GameObject idcard;
    Transform idcardTr;

    // ������ ������ ī��
    GameObject clear;

    //���н� Fade����...?? �ʿ�??
    public GameObject player, fade;
    // ���н� ����
    public GameObject stop;
    public GameObject[] puzzleBad;

    // �Ҹ����
    AudioSource puzzleAudio;

    [SerializeField]
    [Range(0.01f, 10f)] public float time;

    float sceneOffTime = 1f;

    public GameObject finishBadText;

    //FinalEndingBad��ũ��Ʈ ��������1
    FinalEndingBad finishBadSC;

    public void Awake()
    {
        // �±׷� �������� ��������
        success = GameObject.FindGameObjectsWithTag("SuccessOrFailure");//8����
        // ����������
        puzzle = GameObject.FindGameObjectsWithTag("Puzzle");//0����

        //FinalEndingBad��ũ��Ʈ ��������2
        finishBadSC = finishBadText.GetComponent<FinalEndingBad>();

        // Ȱ��ȭ�� ���� ��� ��Ȱ��ȭ
        for (int i = 0; i < puzzle.Length; i++)
        {
            puzzle[i].SetActive(false);
            //Debug.Log("22");

        }
        // ���� Ȱ��ȭ�� ���� ��� ��Ȱ��ȭ
        for (int i = 0; i < puzzleBad.Length; i++)
        {
            puzzleBad[i].SetActive(false);
            //Debug.Log("11" + i);
        }

        // �Ҹ�
        puzzleAudio = puzzle[0].GetComponent<AudioSource>();

        //idcard Ȱ��ȭ
        idcardTr = gameObject.transform.Find("ID2");
        idcard = idcardTr.gameObject;

        // ������ �ϼ��� ���� 
        clear = puzzle[0].transform.Find("IDCard").gameObject;
        clear.SetActive(false);
    }

    //------------------------------------------------------------------------
    void Off()
    {
        puzzle[0].SetActive(false);
    }
    void On()
    {
        puzzleAudio.Play();
        puzzle[i].SetActive(true);
        Debug.Log("i���� " + i);//= 9���� ����
        if (i >= 9)
        {
            Invoke("Clear", 1f);
        }
    }
    void Clear()
    {
        clear.SetActive(true);
    }

    // ���� ��Ȱ��ȭ�� ����
    int activeObjectCountSetA = 7;
    // activeObjectCount Ȱ��ȭ
    int activeObjectCount;
    // ������ ����
    int puzzleCount;

    int i = 1;
    void Update()
    {
        //��Ȱ��ȭ�� ����
        activeObjectCount = success.Count(obj => obj.activeSelf);

        //���� Ȱ��ȭ ����
        puzzleCount = puzzle.Count(obj1 => !obj1.activeSelf);

        if (activeObjectCount == activeObjectCountSetA)
        {
            puzzle[0].SetActive(true);
            puzzle[1].SetActive(true);

            // ���� �̼�Ȱ��ȭ ������ puzzleCount���??????��ȣ
            if (activeObjectCount < puzzleCount)
            {
                //puzzleCount�� i��° �迭 Ȱ��ȭ
                Invoke("On", 0.4f);

                activeObjectCountSetA--;

                if (i <= 8)
                {
                    Invoke("Off", 4.5f);
                }
                if (i >= 9)
                {
                    Invoke("Off", 8);
                }
                ++i;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        activeObjectCount = success.Count(obj => obj.activeSelf);
        //��Ȱ��ȭ�� ����

        // �����ִ� �±��� ��( ��, �������� ���� �����Ѱ�)
        if (activeObjectCount >= 1)
        {
            //Debug.Log($"���� {activeObjectCount}");
            aPileOfGarbage.SetActive(true);
            // �ٽ�? ��
            Invoke("FadeBadText", sceneOffTime);
        }
        else if (activeObjectCount == 0)
        {
            //ebug.Log($"���� {activeObjectCount}");
            idcard.SetActive(true);// IDī��
        }
    }

    // ����
    void FadeBadText()
    {
        stop.GetComponent<PlayerStop>().Stop();
        finishBadSC.FadeOnOff1();
        Invoke("PuzzleBad", 4);
    }

    // ������ ���� ���н� ������
    void PuzzleBad()
    {
        // ������ ����(�迭�� ��� 0����)
        i--;
        for (int m = 0; i > m; m++)
        {
            puzzleBad[m].SetActive(true);
            Debug.Log("m" + m);
        }
    }
}