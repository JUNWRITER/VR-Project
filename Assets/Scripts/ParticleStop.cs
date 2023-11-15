using System.Collections;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    public GameObject targetObject; // Inspector에서 정할 오브젝트
    public ParticleSystem[] particleSystems; // 여러 개의 파티클 시스템을 할당할 수 있는 배열
    public float scaleDownDuration = 5.0f; // 스케일이 작아지는 데 걸리는 시간
    private bool isScalingDown = false;

    private void Update()
    {
        // targetObject가 비활성화되면 모든 파티클 시스템도 스케일을 천천히 작아지도록 비활성화
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

        // 스케일이 완전히 작아지면 파티클 시스템을 비활성화
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.gameObject.SetActive(false);
        }
    }
}





