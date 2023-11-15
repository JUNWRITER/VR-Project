using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UICameraMove : MonoBehaviour
{
    // ī�޶� ���󰡴� UI
    public Transform targetTr; // ī�޶�

    Transform uiTr;// UI�ڽ�
    
    //�Ÿ�
    //[Range(2.0f, 20.0f)]
    public float distance;
    // y�� �̵� ����
    //[Range(2.0f, 20.0f)]
    public float heigh;

    //���� �ӵ�
    public float damping ;

    //ī�޶� LookAt�� Offset ��
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
        // �����ؾ� �� ����� �������� distance��ŭ �̵�
        // ���̸� heigh��ŭ �̵�
        Vector3 pos = targetTr.position + (targetTr.forward * distance) + (Vector3.up * heigh);

        //SmoothDamp�� �̿��� ��ġ ����
        uiTr.position = Vector3.SmoothDamp(uiTr.position, pos, ref velocity, damping);

        //ui�� �ǹ� ��ǥ�� ���� ȸ��
        uiTr.LookAt(targetTr.position);
    }
}
