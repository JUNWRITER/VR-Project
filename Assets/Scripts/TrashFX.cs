using System.Collections;
using UnityEngine;

public class TrashFX : MonoBehaviour
{
    [SerializeField] private GameObject ObjectX; // 모니터링할 오브젝트
    [SerializeField] private GameObject ObjectO; // 활성화할 오브젝트
    [SerializeField] private float activationDelay = 10.0f; // 활성화 후 비활성화까지의 대기 시간
    [SerializeField] private float growthTime = 2.0f; // 스케일이 0.8까지 커지는 데 걸리는 시간

    private bool isActivated = false;

    private void Update()
    {
        if (!isActivated && ObjectX != null && !ObjectX.activeSelf)
        {
            // ObjectX가 비활성화되었을 때 ObjectO를 활성화
            if (ObjectO != null)
            {
                StartCoroutine(ActivateAndGrowObjectO());
            }
        }
    }

    private IEnumerator ActivateAndGrowObjectO()
    {
        ObjectO.SetActive(true);
        isActivated = true;

        float elapsedTime = 0.0f;
        Vector3 initialScale = ObjectO.transform.localScale;
        Vector3 targetScale = new Vector3(0.8f, 0.8f, 0.8f);

        while (elapsedTime < growthTime)
        {
            ObjectO.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / growthTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectO.transform.localScale = targetScale;

        // 지정된 시간 후에 ObjectO를 비활성화
        yield return new WaitForSeconds(activationDelay - growthTime);
        ObjectO.SetActive(false);
    }
}




