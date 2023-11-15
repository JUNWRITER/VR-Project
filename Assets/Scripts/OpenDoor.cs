using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    GameObject hintObj;
    public string hintUIName;

    public int time;

    int num = 0;
    private void Awake()
    {
        //�θ� ã�� ��Ȱ��ȭ �� �ڽ� ������Ʈ ã��
        hintObj = GameObject.Find("HintUI").transform.Find(hintUIName).gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (num < 1)
        {
            hintObj.SetActive(true);
            Invoke("Off", time);
            num++;
        }
    }

    public void Off()
    {
        hintObj.SetActive(false);
    }
}
