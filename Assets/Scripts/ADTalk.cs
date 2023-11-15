using UnityEngine;

public class ADTalk : MonoBehaviour
{
    public AudioSource audioSource; // ���带 ����ϴ� AudioSource
    public GameObject targetObject; // �ν����� â���� ������ ��� ������Ʈ

    private bool hasPlayed = false; // ���尡 ����Ǿ����� ���θ� ��Ÿ���� ����

    private void Update()
    {
        if (!hasPlayed && !targetObject.activeSelf)
        {
            // AudioSource Ȱ��ȭ
            audioSource.enabled = true;

            // ���� ���
            audioSource.Play();

            // ���尡 �� �� ����Ǿ����� ǥ��
            hasPlayed = true;
        }
    }
}



