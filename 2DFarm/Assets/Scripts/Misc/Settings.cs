using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    //Player Animation Parameters
    public static int inputX;
    public static int inputY;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isUsingToolLeft;
    public static int isUsingToolRight;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isLiftingToolLeft;
    public static int isLiftingToolRight;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int isSwingingToolLeft;
    public static int isSwingingToolRight;
    public static int isPickingUp;
    public static int isPickingDown;
    public static int isPickingLeft;
    public static int isPickingRight;

    //Shared Animation Parameters
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;

    static Settings()
    {
        //Player Animation Parameters
        inputX = Animator.StringToHash("xInput");
        inputY = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolLeft = Animator.StringToHash("isLiftingTooldLeft");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isSwingingToolUp = Animator.StringToHash("isSwingingTooldUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingRight = Animator.StringToHash("isPickingRight");

        //Shared Animation Parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }
}
