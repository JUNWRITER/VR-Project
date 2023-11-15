using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMisson : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToActivate; // Ȱ��ȭ�� ������Ʈ���� �����մϴ�.

    [SerializeField]
    private List<Transform> objectsToScale; // �������� ������ ������Ʈ���� �����մϴ�.

    [SerializeField]
    private float activationDelay = 2.0f; // Ȱ��ȭ ������ (��)

    [SerializeField]
    private float scaleDuration = 3.0f; // ������ ���濡 �ɸ��� �ð� (��)

    private bool activationStarted = false;
    private bool isDisabling = false; // ������Ʈ�� ��Ȱ��ȭ ������ ���θ� ��Ÿ���� ����
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

            // Ȱ��ȭ ����
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            // ������ ���� ����
            isDisabling = true;
        }
    }
}


