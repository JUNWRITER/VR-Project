using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UICameraMove : MonoBehaviour
{
    // 카메라 따라가는 UI
    public Transform targetTr; // 카메라

    Transform uiTr;// UI자신
    
    //거리
    //[Range(2.0f, 20.0f)]
    public float distance;
    // y축 이동 높이
    //[Range(2.0f, 20.0f)]
    public float heigh;

    //반응 속도
    public float damping ;

    //카메라 LookAt의 Offset 값
    public float targetOffset = 2.0f;

    //smoothDamp
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        //uiTr = GetComponent<Transform>();
        uiTr = gameObject.GetComponent<Transform>();
    }
    void LateUpdate()
    {
        // 추적해야 할 대상의 뒤쪽으로 distance만큼 이동
        // 높이를 heigh만큼 이동
        Vector3 pos = targetTr.position + (targetTr.forward * distance) + (Vector3.up * heigh);

        //SmoothDamp을 이용한 위치 보간
        uiTr.position = Vector3.SmoothDamp(uiTr.position, pos, ref velocity, damping);

        //ui를 피벗 좌표를 향해 회전
        uiTr.LookAt(targetTr.position);
    }
}
