using UnityEngine;

public class HomeAd : MonoBehaviour
{
    public GameObject[] planes; // 3���� Plane�� ������ �迭
    private int activePlaneIndex = 0; // ���� Ȱ��ȭ�� Plane�� �ε���

    private float switchInterval = 2.0f; // Plane ��ȯ ���� (��: 2��)
    private float timer = 0f;

    private void Start()
    {
        // ó������ ù ��° Plane�� Ȱ��ȭ
        SetActivePlane(0);
    }

    private void Update()
    {
        // switchInterval �ð����� ���� Plane���� ��ȯ
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            int nextPlaneIndex = (activePlaneIndex + 1) % planes.Length;
            SetActivePlane(nextPlaneIndex);
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    private void SetActivePlane(int index)
    {
        // ���� Ȱ��ȭ�� Plane�� ��Ȱ��ȭ
        planes[activePlaneIndex].SetActive(false);

        // ���ο� Plane�� Ȱ��ȭ�ϰ� �ε��� ������Ʈ
        activePlaneIndex = index;
        planes[activePlaneIndex].SetActive(true);
    }
}

