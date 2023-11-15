using UnityEngine;

public class IntheTrash : MonoBehaviour
{
    [SerializeField] private GameObject thirdObject;
    private MeshRenderer thirdObjectMeshRenderer;
    private AudioSource thirdObjectAudioSource;
    private bool soundPlayed = false;

    private void Start()
    {
        thirdObjectMeshRenderer = thirdObject.GetComponent<MeshRenderer>();
        thirdObjectAudioSource = thirdObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!soundPlayed && other.CompareTag("TrashCan"))
        {

            if (thirdObjectMeshRenderer != null)
            {
                thirdObjectMeshRenderer.enabled = true;
            }

            if (thirdObjectAudioSource != null)
            {
                thirdObjectAudioSource.PlayOneShot(thirdObjectAudioSource.clip);
                soundPlayed = true;
            }

            // 모든 작업이 완료된 후 해당 오브젝트를 비활성화합니다.
            gameObject.SetActive(false);
        }
    }
}













