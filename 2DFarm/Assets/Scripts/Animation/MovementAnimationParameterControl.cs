using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolUp, bool isUsingToolDown, bool isUsingToolLeft, bool isUsingToolRight,
    bool isLiftingToolUp, bool isLiftingToolDown, bool isLiftingToolLeft, bool isLiftingToolRight,
    bool isPickingUp, bool isPickingDown, bool isPickingLeft, bool isPickingRight,
    bool isSwingingToolUp, bool isSwingingToolDown, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        animator.SetFloat(Settings.inputX, inputX);
        animator.SetFloat(Settings.inputY, inputY);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);
        animator.SetInteger(Settings.toolEffect, (int)toolEffect);

        if (isUsingToolRight)
            animator.SetTrigger(Settings.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Settings.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Settings.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Settings.isUsingToolDown);

        if (isLiftingToolRight)
            animator.SetTrigger(Settings.isLiftingToolRight);
        if (isLiftingToolLeft)
            animator.SetTrigger(Settings.isLiftingToolLeft);
        if (isLiftingToolUp)
            animator.SetTrigger(Settings.isLiftingToolUp);
        if (isLiftingToolDown)
            animator.SetTrigger(Settings.isLiftingToolDown);

        if (isSwingingToolRight)
            animator.SetTrigger(Settings.isSwingingToolRight);
        if (isSwingingToolLeft)
            animator.SetTrigger(Settings.isSwingingToolLeft);
        if (isSwingingToolUp)
            animator.SetTrigger(Settings.isSwingingToolUp);
        if (isSwingingToolDown)
            animator.SetTrigger(Settings.isSwingingToolDown);

        if (isPickingRight)
            animator.SetTrigger(Settings.isPickingRight);
        if (isPickingLeft)
            animator.SetTrigger(Settings.isPickingLeft);
        if (isPickingUp)
            animator.SetTrigger(Settings.isPickingUp);
        if (isPickingDown)
            animator.SetTrigger(Settings.isPickingDown);

        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            animator.SetTrigger(Settings.idleDown);
    }

    private void AnimationEventPlayFootstepSound()
    {

    }
}
