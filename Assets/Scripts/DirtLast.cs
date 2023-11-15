using UnityEngine;

public class DirtStop : MonoBehaviour
{
    public GameObject targetObject; // �ν����� â���� ������Ʈ�� ������ ����
    public Material targetMaterial; // �ν����� â���� ��Ƽ������ ������ ����

    void Update()
    {
        // targetObject�� Ȱ��ȭ ���θ� Ȯ���ϰ� ���İ��� �����մϴ�.
        if (targetObject != null && targetMaterial != null)
        {
            if (!targetObject.activeSelf)
            {
                // ������Ʈ�� ��Ȱ��ȭ�Ǹ� ���İ��� 1�� �����մϴ�.
                Color currentColor = targetMaterial.color;
                currentColor.a = 1f;
                targetMaterial.color = currentColor;
            }            
        }
    }
}





