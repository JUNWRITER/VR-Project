using UnityEngine;

public class WallQuest : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject; // Inspector 창에서 지정할 대상 오브젝트

    private void Update()
    {
        // 대상 오브젝트가 활성화되었는지 확인하고, 비활성화되면 이 스크립트가 있는 오브젝트도 비활성화합니다.
        if (targetObject != null && !targetObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}

