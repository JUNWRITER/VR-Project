using UnityEngine;

public class DirtStop : MonoBehaviour
{
    public GameObject targetObject; // 인스펙터 창에서 오브젝트를 지정할 변수
    public Material targetMaterial; // 인스펙터 창에서 머티리얼을 지정할 변수

    void Update()
    {
        // targetObject의 활성화 여부를 확인하고 알파값을 조정합니다.
        if (targetObject != null && targetMaterial != null)
        {
            if (!targetObject.activeSelf)
            {
                // 오브젝트가 비활성화되면 알파값을 1로 변경합니다.
                Color currentColor = targetMaterial.color;
                currentColor.a = 1f;
                targetMaterial.color = currentColor;
            }            
        }
    }
}





