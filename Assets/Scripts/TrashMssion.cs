using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMisson : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToActivate; // 활성화할 오브젝트들을 설정합니다.

    [SerializeField]
    private List<Transform> objectsToScale; // 스케일을 조절할 오브젝트들을 설정합니다.

    [SerializeField]
    private float activationDelay = 2.0f; // 활성화 딜레이 (초)

    [SerializeField]
    private float scaleDuration = 3.0f; // 스케일 변경에 걸리는 시간 (초)

    private bool activationStarted = false;
    private bool isDisabling = false; // 오브젝트를 비활성화 중인지 여부를 나타내는 변수
    private float activationTimer = 0.0f;
    private float scaleTimer = 0.0f;
    private int currentObjectIndex = 0;
    private bool hasActivated;

    private void Update()
    {
        if (!activationStarted)
        {
            activationTimer += Time.deltaTime;
            if (activationTimer >= activationDelay)
            {
                activationStarted = true;

                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }
            }
        }
        else if (isDisabling)
        {
            if (currentObjectIndex < objectsToScale.Count)
            {
                ScaleObject(objectsToScale[currentObjectIndex]);
            }
        }
    }

    private void ScaleObject(Transform objToScale)
    {
        scaleTimer += Time.deltaTime;
        float t = Mathf.Clamp01(scaleTimer / scaleDuration);
        Vector3 newScale = Vector3.Lerp(objToScale.localScale, Vector3.zero, t);
        objToScale.localScale = newScale;

        if (t >= 1.0f)
        {
            objToScale.gameObject.SetActive(false);
            currentObjectIndex++;

            if (currentObjectIndex >= objectsToScale.Count)
            {
                isDisabling = false;
            }
        }
    }

    private void OnBecameVisible()
    {
        if (!activationStarted)
        {
            hasActivated = true;

            // 활성화 시작
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            // 스케일 조절 시작
            isDisabling = true;
        }
    }
}


