using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{// �� �ε� �۾�
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
        //�ε��� �����Ȳ Ȯ��
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        //�ε��� ����Ȯ��
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
