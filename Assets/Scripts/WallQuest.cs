using UnityEngine;

public class WallQuest : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject; // Inspector â���� ������ ��� ������Ʈ

    private void Update()
    {
        // ��� ������Ʈ�� Ȱ��ȭ�Ǿ����� Ȯ���ϰ�, ��Ȱ��ȭ�Ǹ� �� ��ũ��Ʈ�� �ִ� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        if (targetObject != null && !targetObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}

