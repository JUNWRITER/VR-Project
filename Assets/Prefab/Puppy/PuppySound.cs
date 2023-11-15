using UnityEngine;

public class PuppySound : MonoBehaviour
{
    public GameObject targetObject; // Inspector 창에서 원하는 오브젝트를 할당할 변수
    private AudioSource audioSource;
    private bool hasPlayedSound = false;

    private void Start()
    {
        // targetObject에서 AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (targetObject != null && !targetObject.activeSelf && !hasPlayedSound)
        {
            // 오브젝트가 비활성화되었고 아직 사운드가 재생되지 않은 경우
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true;
            }
        }
    }
}






