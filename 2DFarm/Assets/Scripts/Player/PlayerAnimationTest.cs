using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputX;
    public float inputY;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isUsingToolLeft;
    public bool isUsingToolRight;
    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isLiftingToolLeft;
    public bool isLiftingToolRight;
    public bool isPickingUp;
    public bool isPickingDown;
    public bool isPickingLeft;
    public bool isPickingRight;
    public bool isSwingingToolUp;
    public bool isSwingingToolDown;
    public bool isSwingingToolLeft;
    public bool isSwingingToolRight;
    public bool idleUp;
    public bool idleDown;
    public bool idleLeft;
    public bool idleRight;

    private void Update()
    {
        EventHandler.CallMovementEvent(inputX, inputY,
                isWalking, isRunning, isIdle, isCarrying,
                toolEffect,
                isUsingToolUp, isUsingToolDown, isUsingToolLeft, isUsingToolRight,
                isLiftingToolUp, isLiftingToolDown, isLiftingToolLeft, isLiftingToolRight,
                isPickingUp, isPickingDown, isPickingLeft, isPickingRight,
                isSwingingToolUp, isSwingingToolDown, isSwingingToolLeft, isSwingingToolRight,
                idleUp, idleDown, idleLeft, idleRight);
    }
}
