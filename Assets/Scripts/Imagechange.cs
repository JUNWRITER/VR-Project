using UnityEngine;
using UnityEngine.UI;

public class imagechnge : MonoBehaviour
{
    public GameObject targetObject; // ��Ȱ��ȭ�� ����͸��� ��� ������Ʈ
    public Image imageComponent; // �̹����� ������ UI Image ������Ʈ
    public Sprite newSprite; // ���ο� �̹���

    private void Update()
    {
        // ��� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �ʴٸ�
        if (!targetObject.activeSelf)
        {
            // UI Image�� �̹����� �� �̹����� ����
            imageComponent.sprite = newSprite;
        }
    }
}

