using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeCoffeeShopGetTumbler : MonoBehaviour
{
    public GameObject getObj;
    public GameObject getUi;
    // ���� ����
    public AudioSource tumblerSound;
    public void GetTime()
    {//������ ã��̼� ui
        Destroy(getUi, 0.5f);
    }
    public GameObject watercoffee;

    public void CoffeeGet()
    { // �ſ� Ŀ�� �ް� ������ ���� Destory �Ѵ�
        if (watercoffee.activeSelf == true)
        {
            Destroy(gameObject, 1f);
            tumblerSound=GetComponent<AudioSource>();
            tumblerSound.Play();
        }
    }
    // ��ȸ�� �ſ� Ŀ�� �ް� ������ ���� Destory �Ѵ� 
    public void CoffeeGet2()
    {
        if (watercoffee.activeSelf == true)
        {
            Destroy(gameObject, 1f);
        }
    }
}
