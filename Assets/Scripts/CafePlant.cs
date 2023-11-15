using UnityEngine;

public class CafePlant : MonoBehaviour
{
    public GameObject targetObjectToDeactivate;  // ��Ȱ��ȭ�� ������Ʈ
    public GameObject[] objectsToActivate;        // Ȱ��ȭ�� ���� ������Ʈ�� �迭�� ����
    public float scaleSpeed = 0.01f;              // ������ ��ȭ �ӵ�
    public Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);  // ��ǥ ������

    private bool isScaling = false;
    private float scaleProgress = 0f;

    void Update()
    {
        if (targetObjectToDeactivate != null && !targetObjectToDeactivate.activeSelf && !isScaling)
        {
            isScaling = true;

            // ��� ������Ʈ���� �ʱ� ������ 0���� �����ϵ��� �����մϴ�.
            foreach (GameObject obj in objectsToActivate)
            {
                obj.transform.localScale = Vector3.zero;
                obj.SetActive(true);
            }
        }

        if (isScaling)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                // �������� õõ�� ����
                obj.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, scaleProgress);

                scaleProgress += scaleSpeed * Time.deltaTime;

                // �������� ��ǥ �����Ͽ� �����ϸ� �����ϸ��� �����մϴ�.
                if (scaleProgress >= 1.0f)
                {
                    isScaling = false;
                }
            }
        }
    }
}








