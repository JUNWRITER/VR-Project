using UnityEngine;

public class ADTalk : MonoBehaviour
{
    public AudioSource audioSource; // 사운드를 재생하는 AudioSource
    public GameObject targetObject; // 인스펙터 창에서 지정할 대상 오브젝트

    private bool hasPlayed = false; // 사운드가 재생되었는지 여부를 나타내는 변수

    private void Update()
    {
        if (!hasPlayed && !targetObject.activeSelf)
        {
            // AudioSource 활성화
            audioSource.enabled = true;

            // 사운드 재생
            audioSource.Play();

            // 사운드가 한 번 재생되었음을 표시
            hasPlayed = true;
        }
    }
}



