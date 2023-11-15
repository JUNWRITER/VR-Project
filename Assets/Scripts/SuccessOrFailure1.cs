using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuccessOrFailure1 : MonoBehaviour
{
    //성공 여부 계산 OnTriggerEnter 이면~
    GameObject[] success;
    public GameObject aPileOfGarbage;

    //실패시 Fade실행
    public GameObject player, fade;

    // 실패시 멈춤
    GameObject stop;

    [SerializeField]
    [Range(0.01f, 10f)] public float time;

    float sceneOffTime = 1f;

   // public GameObject finishText;
    public GameObject finishBadText;

    //FinalEnding스크립트 가져오기1
   // FinalEnding finishSC;
    FinalEndingBad finishBadSC;

    public void Awake()
    {
        // 태그로 가져오기 성공갯수
        success = GameObject.FindGameObjectsWithTag("SuccessOrFailure");

        //FinalEnding스크립트 가져오기2
       // finishSC = finishText.GetComponent<FinalEnding>();
        finishBadSC = finishBadText.GetComponent<FinalEndingBad>();

        stop = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter(Collider other)
    {
        int activeObjectCount = success.Count(obj => obj.activeSelf);
        //비활성화의 갯수

        // 남아있는 태그의 수( 즉, 적을수록 많이 성공한것)
        if (activeObjectCount >= 5)//5678
        {
            //Debug.Log($"실패 {activeObjectCount}");
            aPileOfGarbage.SetActive(true);

            Invoke("FadeBadText", sceneOffTime);
        }
        //else if (activeObjectCount <= 4)//1234
        //{
        //    Debug.Log($"성공 {activeObjectCount}");
        //}
    }

    void FadeBadText()
    {
        stop.GetComponent<PlayerStop>().Stop();
        finishBadSC.FadeOnOff1();
    }
}
