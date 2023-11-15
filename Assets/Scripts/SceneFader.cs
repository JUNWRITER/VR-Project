using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SceneFader : MonoBehaviour
{
    public GameObject player;
    public GameObject fade;

    private Image fades;

    [SerializeField]
    [Range(0.01f, 10f)] public float time;

    public float playerMoveTime = 3.0f;

    public float x,y,z = 0;

    private void Awake()
    {
        fades = GetComponent<Image>();
    }

    public void SceneOff()
    {
        StartCoroutine(Fade(0, 1));
        Invoke("PlayerMove", 2.0f);
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / time;

            Color color = fades.color;
            color.a = Mathf.Lerp(start, end, percent);
            fades.color = color;

            yield return null;
        }
    }

    public void PlayerMove()
    {
        Debug.Log("스위치 홈");
        player.transform.position = new Vector3(x, y, z);
        player.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        StartCoroutine(Fade(1, 0));
    }
}