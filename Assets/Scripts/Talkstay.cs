using UnityEngine;

public class Talkstay : MonoBehaviour
{
    public AudioSource audioSource; // ���带 ����ϴ� AudioSource
    private bool hasPlayed = false; // ���尡 ����Ǿ����� ���θ� ��Ÿ���� ����

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Player �±׸� ���� ���
        if (other.CompareTag("Player") && !hasPlayed)
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
