using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DronePlayerFollowTutorial : MonoBehaviour
{
    [SerializeField] Transform[] TutorialPos;
    [SerializeField] float speed = 5.0f;
    int TutorialNum = 0;
    bool cafeNum2 = false;

    public GameObject drone;
    public GameObject dronePos;


    void Update()
    {
        MoveCoffeeDrone();
    }
    public void MoveCoffeeDrone()
    {
        if (TutorialNum <= 5)
        {
            drone.transform.position = Vector3.MoveTowards
           (drone.transform.position, TutorialPos[TutorialNum].transform.position, speed * Time.deltaTime);

            drone.transform.LookAt(TutorialPos[TutorialNum].transform.position);

            if (drone.transform.position == TutorialPos[TutorialNum].transform.position)
            {
                TutorialNum++;
            }
            if (TutorialNum ==5)
            {
                TutorialNum = 1;
            }
        }
    }
}
