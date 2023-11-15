using UnityEngine;

public class HomeAd : MonoBehaviour
{
    public GameObject[] planes; // 3개의 Plane을 저장할 배열
    private int activePlaneIndex = 0; // 현재 활성화된 Plane의 인덱스

    private float switchInterval = 2.0f; // Plane 전환 간격 (예: 2초)
    private float timer = 0f;

    private void Start()
    {
        // 처음에는 첫 번째 Plane만 활성화
        SetActivePlane(0);
    }

    private void Update()
    {
        // switchInterval 시간마다 다음 Plane으로 전환
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            int nextPlaneIndex = (activePlaneIndex + 1) % planes.Length;
            SetActivePlane(nextPlaneIndex);
            timer = 0f; // 타이머 초기화
        }
    }

    private void SetActivePlane(int index)
    {
        // 현재 활성화된 Plane을 비활성화
        planes[activePlaneIndex].SetActive(false);

        // 새로운 Plane을 활성화하고 인덱스 업데이트
        activePlaneIndex = index;
        planes[activePlaneIndex].SetActive(true);
    }
}

