using UnityEngine;

public class TrashBefx : MonoBehaviour
{
    public GameObject[] targetObjects; // 인스펙터 창에서 지정한 대상 오브젝트 배열
    public ParticleSystem[] particleSystems; // 파티클 시스템 배열
    private bool[] hasPlayed; // 각 파티클 시스템이 재생되었는지 여부를 나타내는 배열

    private void Awake()
    {
        // 배열 초기화
        hasPlayed = new bool[particleSystems.Length];
    }

    private void Update()
    {
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (i < particleSystems.Length && targetObjects[i] != null && !targetObjects[i].activeSelf && !hasPlayed[i])
            {
                // 대상 오브젝트가 비활성화되고, 해당 파티클 시스템이 아직 재생되지 않았을 때
                // 해당 파티클 시스템을 활성화하고 재생
                particleSystems[i].gameObject.SetActive(true);
                particleSystems[i].Play();
                hasPlayed[i] = true; // 해당 파티클 시스템이 한 번만 재생되었음을 표시
            }
        }
    }
}


