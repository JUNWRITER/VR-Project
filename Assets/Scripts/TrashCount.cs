using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrashCount : MonoBehaviour
{
    //���� ���� ��� OnTriggerEnter �̸�~
    GameObject[] trash; //������

    // ���� 3 2 1
    public GameObject image1, image2, image3;
    // Sprite one, two, three;

    public string trTag ; 

    public void Awake()
    {
        // ������ �±׷� ��������
        trash = GameObject.FindGameObjectsWithTag(trTag);

        // ���� ��������(������Ʈ ã��)
        //image1 = transform.Find("Image1-1").gameObject;
        //image2 = transform.Find("Image1-2").gameObject;
        //image3 = transform.Find("Image1-3").gameObject;

        // �̹��� �������� ���
        //one = image1.GetComponent<UnityEngine.UI.Image>().sprite;    
        //two = image2.GetComponent<Sprite>();
        //three = image3.GetComponent<Sprite>();
    }

    void OnTriggerStay(Collider other)
    {
        int trashCount = trash.Count(obj => obj.activeSelf);
        //��Ȱ��ȭ�� ����

        // �����ִ� �±��� ��( ��, �������� ���� �����Ѱ�)enabled
        if (trashCount == 2)
        {

            image3.SetActive(false);
            image2.SetActive(true);
        }
        else if (trashCount == 1)
        {

            image2.SetActive(false);
            image1.SetActive(true);
        }
        else if (trashCount == 0)
        {
            image1.SetActive(false);
        }

    }
}
