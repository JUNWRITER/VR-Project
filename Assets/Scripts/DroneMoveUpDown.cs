using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class DroneMoveUpDown : MonoBehaviour
{
    public GameObject drone;
    Vector3 dronePos;
    float speed = 1;

    private void Start()
    {
        //불러오기
       dronePos = drone.transform.position;
    }

    private void Update()
    {
        //위아래로 왔다갔다
        float droneYPos = dronePos.y + Mathf.Sin(Time.time * speed) * 0.1f;
        drone.transform.position = new Vector3(drone.transform.position.x, droneYPos, drone.transform.position.z);
    }
}
