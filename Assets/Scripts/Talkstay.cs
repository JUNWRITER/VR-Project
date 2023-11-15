using UnityEngine;

public class Talkstay : MonoBehaviour
{
    public AudioSource audioSource; // 사운드를 재생하는 AudioSource
    private bool hasPlayed = false; // 사운드가 재생되었는지 여부를 나타내는 변수

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 Player 태그를 가진 경우
        if (other.CompareTag("Player") && !hasPlayed)
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
