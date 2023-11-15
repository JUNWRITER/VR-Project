using UnityEngine;

public class LightSoundController : MonoBehaviour
{
    public Light targetLight; // Inspector 창에서 연결할 Light 컴포넌트
    public AudioSource sound;  // Inspector 창에서 연결할 AudioSource 컴포넌트
    private bool isLightActive = true; // Light 상태를 추적하기 위한 변수

    private void Start()
    {
        // Light의 초기 상태 저장
        isLightActive = targetLight.enabled;
    }

    private void Update()
    {
        // 현재 Light 상태와 이전 상태를 비교하여 변화 여부를 확인
        if (targetLight.enabled != isLightActive)
        {
            // Light가 비활성화되면 사운드를 재생
            if (!targetLight.enabled)
            {
                sound.PlayOneShot(sound.clip);
            }

            // Light 상태 업데이트
            isLightActive = targetLight.enabled;
        }
    }
}

