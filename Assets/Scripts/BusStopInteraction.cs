using UnityEngine;

public class BusStopInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash"))
        {
            // "Trash" �±׸� ���� ������Ʈ�� �ƴ϶�� �����մϴ�.
            return;
        }

        if (!other.gameObject.activeSelf)
        {
            // �̹� ��Ȱ��ȭ�� "Trash" ������Ʈ��� �����մϴ�.
            return;
        }

        // "Trash" ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        other.gameObject.SetActive(false);
    }
}




