using System.Collections;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    public GameObject targetObject; // Inspector���� ���� ������Ʈ
    public ParticleSystem[] particleSystems; // ���� ���� ��ƼŬ �ý����� �Ҵ��� �� �ִ� �迭
    public float scaleDownDuration = 5.0f; // �������� �۾����� �� �ɸ��� �ð�
    private bool isScalingDown = false;

    private void Update()
    {
        // targetObject�� ��Ȱ��ȭ�Ǹ� ��� ��ƼŬ �ý��۵� �������� õõ�� �۾������� ��Ȱ��ȭ
        if (!targetObject.activeSelf)
        {
            if (!isScalingDown)
            {
                StartCoroutine(ScaleDownParticleSystems());
                isScalingDown = true;
            }
        }
    }

    private IEnumerator ScaleDownParticleSystems()
    {
        float initialTime = Time.time;
        Vector3 initialScale = new Vector3(2.5f, 2.5f, 2.5f);
        float elapsedTime = 0.0f;

        while (elapsedTime < scaleDownDuration)
        {
            float scaleProgress = elapsedTime / scaleDownDuration;
            foreach (ParticleSystem ps in particleSystems)
            {
                ps.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, scaleProgress);
            }

            elapsedTime = Time.time - initialTime;
            yield return null;
        }

        // �������� ������ �۾����� ��ƼŬ �ý����� ��Ȱ��ȭ
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.gameObject.SetActive(false);
        }
    }
}





