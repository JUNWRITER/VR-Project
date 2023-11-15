using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DronePlayerFollow : MonoBehaviour
{
    [SerializeField] Transform[] cafePos;
    [SerializeField] float speed = 5.0f;
    int cafeNum = 0;
    //bool cafeNum2 = false;

    public GameObject drone;
    public GameObject dronePos;

    public GameObject waterCoffee;

    void Update()
    {
        MoveCoffeeDrone();
        MoveOfficeDrone();
    }
    public void MoveCoffeeDrone()
    {
        if (cafeNum <= 3)
        {
            drone.transform.position = Vector3.MoveTowards
           (drone.transform.position, cafePos[cafeNum].transform.position, speed * Time.deltaTime);

            drone.transform.LookAt(cafePos[cafeNum].transform.position);

            if (drone.transform.position == cafePos[cafeNum].transform.position)
            {
                cafeNum++;
            }
        }
    }
    public void MoveOfficeDrone()
    {
        //if (cafeNum2 = true && cafeNum > 4 && cafeNum <= 7)
            if (cafeNum > 4 && cafeNum <= 7)
            {
                drone.transform.position = Vector3.MoveTowards
                (drone.transform.position, cafePos[cafeNum].transform.position, speed * Time.deltaTime);

                drone.transform.LookAt(cafePos[cafeNum].transform.position);

                if (drone.transform.position == cafePos[cafeNum].transform.position)
                {
                    cafeNum++;
                }
            }
    }

    public void CoffeeShopCup()
    {
        if (waterCoffee.activeSelf == true)
            cafeNum = 5;
    }
}
