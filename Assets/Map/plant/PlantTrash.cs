using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlantTrash : MonoBehaviour
{
    [SerializeField] private List<GameObject> targetObjects; // 여러 개의 오브젝트를 리스트로 관리
    [SerializeField] private GameObject imageObject; // 이미지가 포함된 자식 오브젝트
    [SerializeField] private float scaleSpeed = 0.5f; // 스케일 변화 속도
    [SerializeField] private float delayBetweenScale = 0.5f; // 오브젝트마다의 스케일 간의 시간 간격

    private bool isScalingDown = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = targetObjects[0].transform.localScale; // 첫 번째 오브젝트의 스케일을 기준으로 사용
    }

    private void Update()
    {
        if (imageObject != null && !imageObject.activeSelf && !isScalingDown)
        {
            isScalingDown = true;
            StartCoroutine(ScaleDownAndDisableObjects());
        }
    }

    private IEnumerator ScaleDownAndDisableObjects()
    {
        for (int i = 0; i < targetObjects.Count; i++)
        {
            yield return new WaitForSeconds(i * delayBetweenScale); // 시간 간격 적용

            float timer = 0f;
            while (timer < 1f)
            {
                timer += Time.deltaTime * scaleSpeed;
                targetObjects[i].transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer);
                yield return null;
            }

            // 스케일이 작아진 후 오브젝트를 비활성화
            targetObjects[i].SetActive(false);
        }
    }
}

