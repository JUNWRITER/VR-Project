using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovePlayer : MonoBehaviour
{
    public GameObject playerMoveHere;
    public GameObject oculusJoystickImage0;
    public GameObject oculusJoystickImage1;
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(playerMoveHere);
        oculusJoystickImage0.SetActive(false);
        oculusJoystickImage1.SetActive(true);
    }
}
