using UnityEngine;

public class LightrPole : MonoBehaviour
{
    [SerializeField] private Material targetMaterial; // �ν����� â���� ������ ��� ��Ƽ����
    [SerializeField] private float animationSpeed = 1.0f; // �ִϸ��̼� �ӵ�
    private bool increasingAlpha = true; // ������ �����ϰ� �ִ��� ����
    private float minAlpha = 0.0f; // �ּ� ����
    private float maxAlpha = 1.0f; // �ִ� ����

    private void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("Target Material not set!");
            enabled = false; // ��ũ��Ʈ�� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        // ������ ���� �� ���ҽ�Ű�� ����
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

        // ���ο� ������ ����
        Color newColor = targetMaterial.color;
        newColor.a = newAlpha;
        targetMaterial.color = newColor;
    }
}

