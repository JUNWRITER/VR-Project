using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothHandAnimation : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;
    [SerializeField] private InputActionReference triggerActionRef;
    [SerializeField] private InputActionReference gripActionRef;

    private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
    private static readonly int GripAnimation = Animator.StringToHash("Grip");

    private void Update()
    {
        float triggerValue = triggerActionRef.action.ReadValue<float>();
        handAnimator.SetFloat(TriggerAnimation, triggerValue);

        float gripValue = gripActionRef.action.ReadValue<float>();
        handAnimator.SetFloat(GripAnimation, gripValue);

    }
}
