using UnityEngine;

public class TrashBefx : MonoBehaviour
{
    public GameObject[] targetObjects; // �ν����� â���� ������ ��� ������Ʈ �迭
    public ParticleSystem[] particleSystems; // ��ƼŬ �ý��� �迭
    private bool[] hasPlayed; // �� ��ƼŬ �ý����� ����Ǿ����� ���θ� ��Ÿ���� �迭

    private void Awake()
    {
        // �迭 �ʱ�ȭ
        hasPlayed = new bool[particleSystems.Length];
    }

    private void Update()
    {
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (i < particleSystems.Length && targetObjects[i] != null && !targetObjects[i].activeSelf && !hasPlayed[i])
            {
                // ��� ������Ʈ�� ��Ȱ��ȭ�ǰ�, �ش� ��ƼŬ �ý����� ���� ������� �ʾ��� ��
                // �ش� ��ƼŬ �ý����� Ȱ��ȭ�ϰ� ���
                particleSystems[i].gameObject.SetActive(true);
                particleSystems[i].Play();
                hasPlayed[i] = true; // �ش� ��ƼŬ �ý����� �� ���� ����Ǿ����� ǥ��
            }
        }
    }
}


