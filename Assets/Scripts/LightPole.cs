using UnityEngine;

public class LightrPole : MonoBehaviour
{
    [SerializeField] private Material targetMaterial; // 인스펙터 창에서 지정한 대상 머티리얼
    [SerializeField] private float animationSpeed = 1.0f; // 애니메이션 속도
    private bool increasingAlpha = true; // 투명도를 증가하고 있는지 여부
    private float minAlpha = 0.0f; // 최소 투명도
    private float maxAlpha = 1.0f; // 최대 투명도

    private void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("Target Material not set!");
            enabled = false; // 스크립트를 비활성화
        }
    }

    private void Update()
    {
        // 투명도를 증가 및 감소시키는 로직
        float currentAlpha = targetMaterial.color.a;
        float newAlpha;

        if (increasingAlpha)
        {
            newAlpha = Mathf.MoveTowards(currentAlpha, maxAlpha, animationSpeed * Time.deltaTime);
            if (newAlpha >= maxAlpha)
            {
                increasingAlpha = false;
            }
        }
        else
        {
            newAlpha = Mathf.MoveTowards(currentAlpha, minAlpha, animationSpeed * Time.deltaTime);
            if (newAlpha <= minAlpha)
            {
                increasingAlpha = true;
            }
        }

        // 새로운 투명도를 적용
        Color newColor = targetMaterial.color;
        newColor.a = newAlpha;
        targetMaterial.color = newColor;
    }
}

