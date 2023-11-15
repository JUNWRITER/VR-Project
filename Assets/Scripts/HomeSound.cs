using UnityEngine;

public class HomeSound : MonoBehaviour
{
    public GameObject[] targetObjects; // ���� ���� ��� ������Ʈ�� �迭�� ����
    public AudioClip soundClip; // ����� ���� Ŭ��

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource�� ��ũ��Ʈ�� ����� ������Ʈ�� ���� ���, �� AudioSource�� �߰��մϴ�.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            if (!targetObject.activeSelf)
            {
                // ��� ������Ʈ�� ��Ȱ��ȭ�Ǹ� ���带 ����մϴ�.
                if (audioSource && soundClip)
                {
                    audioSource.PlayOneShot(soundClip);
                }
            }
        }
    }
}

