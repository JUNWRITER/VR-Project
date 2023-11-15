using UnityEngine;

public class LightSoundController : MonoBehaviour
{
    public Light targetLight; // Inspector â���� ������ Light ������Ʈ
    public AudioSource sound;  // Inspector â���� ������ AudioSource ������Ʈ
    private bool isLightActive = true; // Light ���¸� �����ϱ� ���� ����

    private void Start()
    {
        // Light�� �ʱ� ���� ����
        isLightActive = targetLight.enabled;
    }

    private void Update()
    {
        // ���� Light ���¿� ���� ���¸� ���Ͽ� ��ȭ ���θ� Ȯ��
        if (targetLight.enabled != isLightActive)
        {
            // Light�� ��Ȱ��ȭ�Ǹ� ���带 ���
            if (!targetLight.enabled)
            {
                sound.PlayOneShot(sound.clip);
            }

            // Light ���� ������Ʈ
            isLightActive = targetLight.enabled;
        }
    }
}

