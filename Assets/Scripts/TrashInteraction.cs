using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteraction : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDisable; // ��Ȱ��ȭ�� ������Ʈ���� �ν����Ϳ��� �����մϴ�.

    [SerializeField]
    private List<MeshRenderer> thirdObjectRenderers; // ��3�� ������Ʈ�� �޽� ���������� �ν����Ϳ��� �����մϴ�.

    private bool hasInteracted = false;
    private bool isDisabling = false; // ������Ʈ�� ��Ȱ��ȭ ������ ���θ� ��Ÿ���� ����
    public float disableSpeed = 1.0f; // ��Ȱ��ȭ �ӵ�
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!hasInteracted && AllThirdObjectRenderersEnabled())
        {
            hasInteracted = true; // �̹� ��ȣ �ۿ����� ǥ��
            isDisabling = true; // ��Ȱ��ȭ�� �����մϴ�.

            float disableInterval = 0.5f; // �� ������Ʈ�� ��Ȱ��ȭ ���� ����
            float currentInterval = 0.0f;

            // ��� ��Ȱ��ȭ�� ������Ʈ�� ���� Coroutine�� �����մϴ�.
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





