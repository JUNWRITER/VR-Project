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
    //성공 여부 계산 OnTriggerEnter 이면~
    GameObject[] success;
    GameObject[] puzzle;
    public GameObject aPileOfGarbage;

    //성공시 idcard
    GameObject idcard;
    Transform idcardTr;

    // 성공시 합쳐진 카드
    GameObject clear;

    //실패시 Fade실행...?? 필요??
    public GameObject player, fade;
    // 실패시 멈춤
    public GameObject stop;
    public GameObject[] puzzleBad;

    // 소리재생
    AudioSource puzzleAudio;

    [SerializeField]
    [Range(0.01f, 10f)] public float time;

    float sceneOffTime = 1f;

    public GameObject finishBadText;

    //FinalEndingBad스크립트 가져오기1
    FinalEndingBad finishBadSC;

    public void Awake()
    {
        // 태그로 가져오기 성공갯수
        success = GameObject.FindGameObjectsWithTag("SuccessOrFailure");//8부터
        // 퍼즐조각들
        puzzle = GameObject.FindGameObjectsWithTag("Puzzle");//0부터

        //FinalEndingBad스크립트 가져오기2
        finishBadSC = finishBadText.GetComponent<FinalEndingBad>();

        // 활성화된 퍼즐 모두 비활성화
        for (int i = 0; i < puzzle.Length; i++)
        {
            puzzle[i].SetActive(false);
            //Debug.Log("22");

        }
        // 실패 활성화된 퍼즐 모두 비활성화
        for (int i = 0; i < puzzleBad.Length; i++)
        {
            puzzleBad[i].SetActive(false);
            //Debug.Log("11" + i);
        }

        // 소리
        puzzleAudio = puzzle[0].GetComponent<AudioSource>();

        //idcard 활성화
        idcardTr = gameObject.transform.Find("ID2");
        idcard = idcardTr.gameObject;

        // 마지막 완성된 퍼즐 
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
        Debug.Log("i갯수 " + i);//= 9개가 만점
        if (i >= 9)
        {
            Invoke("Clear", 1f);
        }
    }
    void Clear()
    {
        clear.SetActive(true);
    }

    // 현재 비활성화가 몇개라면
    int activeObjectCountSetA = 7;
    // activeObjectCount 활성화
    int activeObjectCount;
    // 퍼즐의 갯수
    int puzzleCount;

    int i = 1;
    void Update()
    {
        //비활성화의 갯수
        activeObjectCount = success.Count(obj => obj.activeSelf);

        //퍼즐 활성화 갯수
        puzzleCount = puzzle.Count(obj1 => !obj1.activeSelf);

        if (activeObjectCount == activeObjectCountSetA)
        {
            puzzle[0].SetActive(true);
            puzzle[1].SetActive(true);

            // 현재 미션활성화 갯수가 puzzleCount라면??????기호
            if (activeObjectCount < puzzleCount)
            {
                //puzzleCount의 i번째 배열 활성화
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
        //비활성화의 갯수

        // 남아있는 태그의 수( 즉, 적을수록 많이 성공한것)
        if (activeObjectCount >= 1)
        {
            //Debug.Log($"실패 {activeObjectCount}");
            aPileOfGarbage.SetActive(true);
            // 다시? 뜸
            Invoke("FadeBadText", sceneOffTime);
        }
        else if (activeObjectCount == 0)
        {
            //ebug.Log($"성공 {activeObjectCount}");
            idcard.SetActive(true);// ID카드
        }
    }

    // 실패
    void FadeBadText()
    {
        stop.GetComponent<PlayerStop>().Stop();
        finishBadSC.FadeOnOff1();
        Invoke("PuzzleBad", 4);
    }

    // 성공한 퍼즐 실패시 보여줌
    void PuzzleBad()
    {
        // 성공한 갯수(배열로 계산 0부터)
        i--;
        for (int m = 0; i > m; m++)
        {
            puzzleBad[m].SetActive(true);
            Debug.Log("m" + m);
        }
    }
}