using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class AdvertisementController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private MeshRenderer meshRenderer;
    [SerializeField]
    public Material targetMaterial;
    private float initialAlpha;
    private float currentAlpha;
    private float targetAlpha = 1.0f;
    private float alphaChangeSpeed = 1f;
    private bool isGrabbed = false;
    [SerializeField]
    private List<GameObject> objectsToDisable; // 비활성화할 오브젝트들을 인스펙터에서 설정합니다.
    private bool isDisabling = false;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);

        Renderer objectRenderer = GetComponent<Renderer>();
        initialAlpha = objectRenderer.material.color.a;
        ChangeAlpha(targetMaterial, 0.0f);

        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isGrabbed)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, alphaChangeSpeed * Time.deltaTime);
            ChangeAlpha(targetMaterial, currentAlpha);
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        ChangeAlpha(targetMaterial, 1.0f);
        isGrabbed = true;

        // 사운드 재생 코드 추가
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        StartCoroutine(DisableMeshRendererWithDelay(5.0f));
        StartCoroutine(DisableObjectsWithDelay(0.5f));
        StartCoroutine(DisableAdvertisementWithDelay(15.0f));
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        meshRenderer.enabled = false;
    }

    private void ChangeAlpha(Material material, float alphaValue)
    {
        Color color = material.color;
        color.a = 1.0f - alphaValue; // 알파값을 1에서 뺌으로써 작아지도록 변경
        material.color = color;
    }

    private IEnumerator DisableMeshRendererWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        meshRenderer.enabled = false;
    }

    private IEnumerator DisableObjectsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject obj in objectsToDisable)
        {
            StartCoroutine(ScaleDownAndDisable(obj, 0.2f));
            yield return new WaitForSeconds(0.5f); // 시간 간격 추가
        }
    }

    private IEnumerator ScaleDownAndDisable(GameObject obj, float scaleSpeed)
    {
        Vector3 initialScale = obj.transform.localScale;

        while (obj.transform.localScale.magnitude > 0.01f)
        {
            float deltaTime = Time.deltaTime;
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

    private IEnumerator DisableAdvertisementWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}







