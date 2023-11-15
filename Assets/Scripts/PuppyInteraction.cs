using UnityEngine;

public class PuppyInteraction : MonoBehaviour
{
    private Animator animator;
    private bool isGripping = false;
    private bool hasReachedTarget = false;

    [SerializeField] private Transform targetTransform; // 오브젝트의 이동 위치
    [SerializeField] private float arrivalDistance = 0.1f; // 도착 거리
    [SerializeField] private Material targetMaterial; // 다른 오브젝트의 머티리얼

    private float waitTime = 7.5f; // 대기 시간
    private float moveTime = 7.0f; // 이동 시간
    private Vector3 initialPosition; // 초기 위치
    private float currentTime = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAlpha(targetMaterial, 0.0f);

        // 초기 위치 저장
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isGripping)
        {
            if (targetTransform != null)
            {
                Vector3 targetPosition = targetTransform.position;
                float speed = 4f; // 이동 속도
                float step = speed * Time.deltaTime;

                // 5초 동안 대기
                if (currentTime < waitTime)
                {
                    currentTime += Time.deltaTime;
                    // 대기 중
                }
                else
                {
                    // 타겟 위치로 이동
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                    // 타겟 위치에 도착하면
                    if (!hasReachedTarget && Vector3.Distance(transform.position, targetPosition) <= arrivalDistance)
                    {
                        gameObject.SetActive(false);
                        hasReachedTarget = true;
                        // 비활성화 시 머티리얼의 알파 값을 변경
                        ChangeAlpha(targetMaterial, 0.5f);
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // 트리거 진입한 오브젝트가 "YourTag" 태그를 가지고 있는지 확인
        if (other.CompareTag("Puppy"))
        {
            animator.SetBool("Grip", true);
            isGripping = true;

            // 3초 후에 플레이어 비활성화
            StartCoroutine(DisablePlayersAfterDelay(0.8f));
        }
    }

    private System.Collections.IEnumerator DisablePlayersAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Puppy");
        foreach (GameObject player in players)
        {
            // 3초 후에 player 오브젝트를 비활성화
            player.SetActive(false);
        }
    }

    private void ChangeAlpha(Material material, float alphaValue)
    {
        Color color = material.color;
        color.a = alphaValue;
        material.color = color;
    }
}















