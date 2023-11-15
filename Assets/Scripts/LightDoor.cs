using UnityEngine;

public class LightDoor : MonoBehaviour
{
    public Light targetLight; // 다른 오브젝트의 Light를 가리키도록 할 public 변수
    public AudioSource sound;  // Inspector 창에서 연결할 AudioSource 컴포넌트

    private bool isLightActive = true;
    private float rotationSpeed = 90.0f; // 더 높은 회전 속도로 설정
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool hasPlayedSound = false; // 사운드가 한 번만 재생되도록 추적하는 변수

    private void Start()
    {
        if (targetLight == null)
        {
            Debug.LogError("대상 Light를 할당하지 않았습니다.");
            enabled = false; // 이 스크립트를 비활성화
            return;
        }

        // Light의 상태를 감지하는 이벤트 리스너 추가
        targetLight.enabled = isLightActive;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, 90.0f, 0f); // 목표 회전 각도 설정
    }

    private void Update()
    {
        if (isLightActive && !targetLight.enabled && !isRotating)
        {
            // Light가 비활성화되면서 1초 뒤에 회전을 시작
            Invoke("StartRotation", 1.5f);
        }

        if (isRotating)
        {
            // 회전 진행
            RotateTowardsTargetRotation();
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        // 사운드 재생 (한 번만)
        if (sound != null && !hasPlayedSound)
        {
            sound.PlayOneShot(sound.clip);
            hasPlayedSound = true;
        }
    }

    private void RotateTowardsTargetRotation()
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
        {
            // 목표 회전 각도에 도달하면 회전을 멈춤
            isRotating = false;
        }
    }
}







