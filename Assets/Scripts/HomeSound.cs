using UnityEngine;

public class HomeSound : MonoBehaviour
{
    public GameObject[] targetObjects; // 여러 개의 대상 오브젝트를 배열로 관리
    public AudioClip soundClip; // 재생할 사운드 클립

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource가 스크립트가 연결된 오브젝트에 없는 경우, 새 AudioSource를 추가합니다.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            if (!targetObject.activeSelf)
            {
                // 대상 오브젝트가 비활성화되면 사운드를 재생합니다.
                if (audioSource && soundClip)
                {
                    audioSource.PlayOneShot(soundClip);
                }
            }
        }
    }
}

