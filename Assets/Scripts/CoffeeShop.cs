using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeShop : MonoBehaviour
{
    public Animator anim;
    public GameObject robotText;
    public GameObject a, b, c;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (a.activeSelf == false && b.activeSelf == false && c.activeSelf == false)
        {
            Invoke("CoffeeShop", 1f);
            anim.SetBool("CoffeeShop", true);
            robotText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("CoffeeShop", false);
        robotText.SetActive(false);
    }

    public void CoffeeShopUI()
    {
        anim.SetBool("CoffeeShop", true);
    }
}
