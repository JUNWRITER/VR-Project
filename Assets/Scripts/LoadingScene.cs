using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{// 씬 로딩 작업
    public Slider slider;
    public string SceneName;

    private float time;

    void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());   
        Debug.Log("1-1");
    }
    IEnumerator LoadAsynSceneCoroutine()
    {
        Debug.Log("1-2");
        //로딩의 진행상황 확인
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        //로딩의 여부확인
        while (operation.isDone)
        {
            time =+ Time.time;
            slider.value = time / 10f;
            if (time > 10)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
