using UnityEngine;

public class PuppySound : MonoBehaviour
{
    public GameObject targetObject; // Inspector â���� ���ϴ� ������Ʈ�� �Ҵ��� ����
    private AudioSource audioSource;
    private bool hasPlayedSound = false;

    private void Start()
    {
        // targetObject���� AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (targetObject != null && !targetObject.activeSelf && !hasPlayedSound)
        {
            // ������Ʈ�� ��Ȱ��ȭ�Ǿ��� ���� ���尡 ������� ���� ���
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true;
            }
        }
    }
}






