using System.Linq;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public Material skybox;
    public float lerpSpeed = 0.1f; // ���� ������ ���� �ӵ�

    private float targetAT;
    private float currentAT;
    GameObject[] skyObjects; // Sky �±׸� ���� ������Ʈ�� ������ ����


    private void Awake()
    {
        // �ʱ� AtmosphereThickness ���� �����ɴϴ�.
        currentAT = RenderSettings.skybox.GetFloat("_AtmosphereThickness");
        targetAT = currentAT;

        // Sky �±׸� ������ �ִ� ������Ʈ�� ����� Awake �Լ����� �����ɴϴ�.
        skyObjects = GameObject.FindGameObjectsWithTag("SuccessOrFailure");

    }

    private void Update()
    {
        // Sky �±׸� ������ �ִ� ������Ʈ�� ������ ������ ����
        int SkyObjectsCount = skyObjects.Count(obj => obj.activeSelf);

        // ��ǥ AtmosphereThickness ���� �ʱ�ȭ
        if (SkyObjectsCount == 8)
        {
            targetAT = 2.25f;
        }
        else if (SkyObjectsCount == 7)
        {
            targetAT = 2.0f;
        }
        else if (SkyObjectsCount == 6)
        { 
            targetAT = 1.8f;
        }
        else if (SkyObjectsCount == 5)
        {
            targetAT = 1.6f;
        }
        else if (SkyObjectsCount == 4)
        {
            targetAT = 1.4f;
        }
        else if (SkyObjectsCount == 3)
        {
            targetAT = 1.3f;
        }
        else if (SkyObjectsCount == 2)
        {
            targetAT = 1.2f;
        }
        else if (SkyObjectsCount == 1)
        {
            targetAT = 1.0f;
        }

        // AtmosphereThickness ���� �ε巴�� ��ȭ��ŵ�ϴ�.
        currentAT = Mathf.Lerp(currentAT, targetAT, lerpSpeed);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", currentAT);
    }
}





















