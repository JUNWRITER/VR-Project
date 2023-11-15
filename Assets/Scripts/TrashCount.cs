using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrashCount : MonoBehaviour
{
    //성공 여부 계산 OnTriggerEnter 이면~
    GameObject[] trash; //쓰레기

    // 숫자 3 2 1
    public GameObject image1, image2, image3;
    // Sprite one, two, three;

    public string trTag ; 

    public void Awake()
    {
        // 쓰레기 태그로 가져오기
        trash = GameObject.FindGameObjectsWithTag(trTag);

        // 숫자 가져오기(오브젝트 찾기)
        //image1 = transform.Find("Image1-1").gameObject;
        //image2 = transform.Find("Image1-2").gameObject;
        //image3 = transform.Find("Image1-3").gameObject;

        // 이미지 가져오는 방법
        //one = image1.GetComponent<UnityEngine.UI.Image>().sprite;    
        //two = image2.GetComponent<Sprite>();
        //three = image3.GetComponent<Sprite>();
    }

    void OnTriggerStay(Collider other)
    {
        int trashCount = trash.Count(obj => obj.activeSelf);
        //비활성화의 갯수

        // 남아있는 태그의 수( 즉, 적을수록 많이 성공한것)enabled
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
