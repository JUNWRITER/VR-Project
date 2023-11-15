using UnityEngine;

public class Talk : MonoBehaviour
{
    public AudioSource audioSource; // 사운드를 재생하는 AudioSource

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 Player 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            // AudioSource 활성화
            audioSource.enabled = true;

            // 사운드 재생
            audioSource.Play();
        }
    }
}











