using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeCoffeeShopGetTumbler : MonoBehaviour
{
    public GameObject getObj;
    public GameObject getUi;
    // 성공 사운드
    public AudioSource tumblerSound;
    public void GetTime()
    {//집에서 찾기미션 ui
        Destroy(getUi, 0.5f);
    }
    public GameObject watercoffee;

    public void CoffeeGet()
    { // 컵에 커피 받고 잡으면 컵을 Destory 한다
        if (watercoffee.activeSelf == true)
        {
            Destroy(gameObject, 1f);
            tumblerSound=GetComponent<AudioSource>();
            tumblerSound.Play();
        }
    }
    // 일회용 컵에 커피 받고 잡으면 컵을 Destory 한다 
    public void CoffeeGet2()
    {
        if (watercoffee.activeSelf == true)
        {
            Destroy(gameObject, 1f);
        }
    }
}
