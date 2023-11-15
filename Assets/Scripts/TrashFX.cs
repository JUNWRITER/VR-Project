using System.Collections;
using UnityEngine;

public class TrashFX : MonoBehaviour
{
    [SerializeField] private GameObject ObjectX; // ����͸��� ������Ʈ
    [SerializeField] private GameObject ObjectO; // Ȱ��ȭ�� ������Ʈ
    [SerializeField] private float activationDelay = 10.0f; // Ȱ��ȭ �� ��Ȱ��ȭ������ ��� �ð�
    [SerializeField] private float growthTime = 2.0f; // �������� 0.8���� Ŀ���� �� �ɸ��� �ð�

    private bool isActivated = false;

    private void Update()
    {
        if (!isActivated && ObjectX != null && !ObjectX.activeSelf)
        {
            // ObjectX�� ��Ȱ��ȭ�Ǿ��� �� ObjectO�� Ȱ��ȭ
            if (ObjectO != null)
            {
                StartCoroutine(ActivateAndGrowObjectO());
            }
        }
    }

    private IEnumerator ActivateAndGrowObjectO()
    {
        ObjectO.SetActive(true);
        isActivated = true;

        float elapsedTime = 0.0f;
        Vector3 initialScale = ObjectO.transform.localScale;
        Vector3 targetScale = new Vector3(0.8f, 0.8f, 0.8f);

        while (elapsedTime < growthTime)
        {
            ObjectO.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / growthTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectO.transform.localScale = targetScale;

        // ������ �ð� �Ŀ� ObjectO�� ��Ȱ��ȭ
        yield return new WaitForSeconds(activationDelay - growthTime);
        ObjectO.SetActive(false);
    }
}




