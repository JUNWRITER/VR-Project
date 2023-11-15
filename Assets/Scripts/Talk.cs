using UnityEngine;

public class Talk : MonoBehaviour
{
    public AudioSource audioSource; // ���带 ����ϴ� AudioSource

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Player �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            // AudioSource Ȱ��ȭ
            audioSource.enabled = true;

            // ���� ���
            audioSource.Play();
        }
    }
}











