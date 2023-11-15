using System.Linq;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public Material skybox;
    public float lerpSpeed = 0.1f; // 조절 가능한 보간 속도

    private float targetAT;
    private float currentAT;
    GameObject[] skyObjects; // Sky 태그를 가진 오브젝트를 저장할 변수


    private void Awake()
    {
        // 초기 AtmosphereThickness 값을 가져옵니다.
        currentAT = RenderSettings.skybox.GetFloat("_AtmosphereThickness");
        targetAT = currentAT;

        // Sky 태그를 가지고 있는 오브젝트의 목록을 Awake 함수에서 가져옵니다.
        skyObjects = GameObject.FindGameObjectsWithTag("SuccessOrFailure");

    }

    private void Update()
    {
        // Sky 태그를 가지고 있는 오브젝트의 갯수를 변수에 저장
        int SkyObjectsCount = skyObjects.Count(obj => obj.activeSelf);

        // 목표 AtmosphereThickness 값을 초기화
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

        // AtmosphereThickness 값을 부드럽게 변화시킵니다.
        currentAT = Mathf.Lerp(currentAT, targetAT, lerpSpeed);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", currentAT);
    }
}





















