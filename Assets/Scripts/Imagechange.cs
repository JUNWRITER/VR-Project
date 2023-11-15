using UnityEngine;
using UnityEngine.UI;

public class imagechnge : MonoBehaviour
{
    public GameObject targetObject; // 비활성화를 모니터링할 대상 오브젝트
    public Image imageComponent; // 이미지를 변경할 UI Image 컴포넌트
    public Sprite newSprite; // 새로운 이미지

    private void Update()
    {
        // 대상 오브젝트가 활성화되어 있지 않다면
        if (!targetObject.activeSelf)
        {
            // UI Image의 이미지를 새 이미지로 변경
            imageComponent.sprite = newSprite;
        }
    }
}

