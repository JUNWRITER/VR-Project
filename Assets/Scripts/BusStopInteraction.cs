using UnityEngine;

public class BusStopInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash"))
        {
            // "Trash" 태그를 가진 오브젝트가 아니라면 무시합니다.
            return;
        }

        if (!other.gameObject.activeSelf)
        {
            // 이미 비활성화된 "Trash" 오브젝트라면 무시합니다.
            return;
        }

        // "Trash" 오브젝트를 비활성화합니다.
        other.gameObject.SetActive(false);
    }
}




