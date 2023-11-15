using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlantTrash : MonoBehaviour
{
    [SerializeField] private List<GameObject> targetObjects; // ���� ���� ������Ʈ�� ����Ʈ�� ����
    [SerializeField] private GameObject imageObject; // �̹����� ���Ե� �ڽ� ������Ʈ
    [SerializeField] private float scaleSpeed = 0.5f; // ������ ��ȭ �ӵ�
    [SerializeField] private float delayBetweenScale = 0.5f; // ������Ʈ������ ������ ���� �ð� ����

    private bool isScalingDown = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = targetObjects[0].transform.localScale; // ù ��° ������Ʈ�� �������� �������� ���
    }

    private void Update()
    {
        if (imageObject != null && !imageObject.activeSelf && !isScalingDown)
        {
            isScalingDown = true;
            StartCoroutine(ScaleDownAndDisableObjects());
        }
    }

    private IEnumerator ScaleDownAndDisableObjects()
    {
        for (int i = 0; i < targetObjects.Count; i++)
        {
            yield return new WaitForSeconds(i * delayBetweenScale); // �ð� ���� ����

            float timer = 0f;
            while (timer < 1f)
            {
                timer += Time.deltaTime * scaleSpeed;
                targetObjects[i].transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer);
                yield return null;
            }

            // �������� �۾��� �� ������Ʈ�� ��Ȱ��ȭ
            targetObjects[i].SetActive(false);
        }
    }
}

