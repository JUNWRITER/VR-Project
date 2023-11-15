using UnityEngine;

public class LightDoor : MonoBehaviour
{
    public Light targetLight; // �ٸ� ������Ʈ�� Light�� ����Ű���� �� public ����
    public AudioSource sound;  // Inspector â���� ������ AudioSource ������Ʈ

    private bool isLightActive = true;
    private float rotationSpeed = 90.0f; // �� ���� ȸ�� �ӵ��� ����
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool hasPlayedSound = false; // ���尡 �� ���� ����ǵ��� �����ϴ� ����

    private void Start()
    {
        if (targetLight == null)
        {
            Debug.LogError("��� Light�� �Ҵ����� �ʾҽ��ϴ�.");
            enabled = false; // �� ��ũ��Ʈ�� ��Ȱ��ȭ
            return;
        }

        // Light�� ���¸� �����ϴ� �̺�Ʈ ������ �߰�
        targetLight.enabled = isLightActive;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, 90.0f, 0f); // ��ǥ ȸ�� ���� ����
    }

    private void Update()
    {
        if (isLightActive && !targetLight.enabled && !isRotating)
        {
            // Light�� ��Ȱ��ȭ�Ǹ鼭 1�� �ڿ� ȸ���� ����
            Invoke("StartRotation", 1.5f);
        }

        if (isRotating)
        {
            // ȸ�� ����
            RotateTowardsTargetRotation();
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        // ���� ��� (�� ����)
        if (sound != null && !hasPlayedSound)
        {
            sound.PlayOneShot(sound.clip);
            hasPlayedSound = true;
        }
    }

    private void RotateTowardsTargetRotation()
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
        {
            // ��ǥ ȸ�� ������ �����ϸ� ȸ���� ����
            isRotating = false;
        }
    }
}







