using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEndingBad : MonoBehaviour
{
    public GameObject[] badText;
    int count = 0;

    public void FadeOnOff1()
    {
        Invoke("One", 4);
        Destroy(badText[0], 10);
        Destroy(badText[6], 10);
        Invoke("YesOrNo", 10);
      
    }
    public void FadeOnOff2()
    {
        Destroy(badText[5], 0.1f);
        Invoke("Two", 0.1f);
        Destroy(badText[1], 3);
        Invoke("Three", 3);
        Destroy(badText[2], 6);
        Invoke("Four", 6);
    }
    private void One()
    {
        if (badText[0] != null)
            badText[0].SetActive(true);

        if (badText[6] != null)
            badText[6].SetActive(true);

        badText[4].SetActive(true);
    }
    private void Two()
    {
        if (badText[1] != null)
            badText[1].SetActive(true);
    }
    private void Three()
    {
        if (badText[2] != null)
            badText[2].SetActive(true);
    }
    private void Four()
    {
        if (badText[3] != null)
            badText[3].SetActive(true);
    }
    private void YesOrNo()
    {
        if (badText[5] != null)
            badText[5].SetActive(true);
    }

    public void OnRetry()
    {
        Debug.Log("aaaa");
        // 현재 씬 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
