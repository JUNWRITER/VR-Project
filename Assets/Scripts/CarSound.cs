using UnityEngine;

public class CarSound : MonoBehaviour
{
    public Light myLight; // ���� �̸��� �����Ͽ� ��ȣ�� ����
    public AudioClip soundClip;

    private AudioSource audioSource;
    private bool hasPlayedSound = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (myLight != null && !hasPlayedSound)
        {
            if (!myLight.isActiveAndEnabled)
            {
                PlaySoundOnce();
            }
        }
    }

    private void PlaySoundOnce()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
            hasPlayedSound = true;
        }
    }
}

