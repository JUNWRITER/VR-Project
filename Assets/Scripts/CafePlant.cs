using UnityEngine;

public class CafePlant : MonoBehaviour
{
    public GameObject targetObjectToDeactivate;  // 비활성화할 오브젝트
    public GameObject[] objectsToActivate;        // 활성화할 여러 오브젝트를 배열로 저장
    public float scaleSpeed = 0.01f;              // 스케일 변화 속도
    public Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);  // 목표 스케일

    private bool isScaling = false;
    private float scaleProgress = 0f;

    void Update()
    {
        if (targetObjectToDeactivate != null && !targetObjectToDeactivate.activeSelf && !isScaling)
        {
            isScaling = true;

            // 모든 오브젝트들을 초기 스케일 0에서 시작하도록 설정합니다.
            foreach (GameObject obj in objectsToActivate)
            {
                obj.transform.localScale = Vector3.zero;
                obj.SetActive(true);
            }
        }

        if (isScaling)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                // 스케일을 천천히 변경
                obj.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, scaleProgress);

                scaleProgress += scaleSpeed * Time.deltaTime;

                // 스케일이 목표 스케일에 도달하면 스케일링을 중지합니다.
                if (scaleProgress >= 1.0f)
                {
                    isScaling = false;
                }
            }
        }
    }
}








