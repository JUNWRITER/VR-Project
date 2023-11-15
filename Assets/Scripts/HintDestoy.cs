using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDestoy : MonoBehaviour
{
    public void HintDsetoys()
    {
        gameObject.SetActive(true);
        Destroy(gameObject, 3.0f);
    }
}
