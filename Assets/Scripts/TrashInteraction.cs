using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteraction : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDisable; // 비활성화할 오브젝트들을 인스펙터에서 설정합니다.

    [SerializeField]
    private List<MeshRenderer> thirdObjectRenderers; // 제3의 오브젝트의 메쉬 렌더러들을 인스펙터에서 설정합니다.

    private bool hasInteracted = false;
    private bool isDisabling = false; // 오브젝트를 비활성화 중인지 여부를 나타내는 변수
    public float disableSpeed = 1.0f; // 비활성화 속도
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!hasInteracted && AllThirdObjectRenderersEnabled())
        {
            hasInteracted = true; // 이미 상호 작용함을 표시
            isDisabling = true; // 비활성화를 시작합니다.

            float disableInterval = 0.5f; // 각 오브젝트의 비활성화 시작 간격
            float currentInterval = 0.0f;

            // 모든 비활성화할 오브젝트에 대해 Coroutine을 시작합니다.
            foreach (GameObject obj in objectsToDisable)
            {
                StartCoroutine(DisableObject(obj, currentInterval));
                currentInterval += disableInterval;
            }

            //meshRenderer.enabled = false;

        }
    }

    private bool AllThirdObjectRenderersEnabled()
    {
        foreach (MeshRenderer renderer in thirdObjectRenderers)
        {
            if (!renderer.enabled)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator DisableObject(GameObject obj, float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        Vector3 initialScale = obj.transform.localScale;

        while (obj.transform.localScale.magnitude > 0.01f)
        {
            float deltaTime = Time.deltaTime;
            float scaleSpeed = 1.0f / disableSpeed;
            Vector3 newScale = obj.transform.localScale - Vector3.one * scaleSpeed * deltaTime;

            if (newScale.x <= 0.0f && newScale.y <= 0.0f && newScale.z <= 0.0f)
            {
                newScale = Vector3.zero;
            }

            obj.transform.localScale = newScale;
            yield return null;
        }

        obj.SetActive(false);
    }
}





