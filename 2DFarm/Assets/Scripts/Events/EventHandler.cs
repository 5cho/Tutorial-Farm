using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolUp, bool isUsingToolDown, bool isUsingToolLeft, bool isUsingToolRight,
    bool isLiftingToolUp, bool isLiftingToolDown, bool isLiftingToolLeft, bool isLiftingToolRight,
    bool isPickingUp, bool isPickingDown, bool isPickingLeft, bool isPickingRight,
    bool isSwingingToolUp, bool isSwingingToolDown, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight);

public static class EventHandler
{
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if(InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
        }
    }
    
    //Movement Event
    public static event MovementDelegate MovementEvent;

    //Movement Event Call For Publishers
    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolUp, bool isUsingToolDown, bool isUsingToolLeft, bool isUsingToolRight,
    bool isLiftingToolUp, bool isLiftingToolDown, bool isLiftingToolLeft, bool isLiftingToolRight,
    bool isPickingUp, bool isPickingDown, bool isPickingLeft, bool isPickingRight,
    bool isSwingingToolUp, bool isSwingingToolDown, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        if (MovementEvent != null)
            MovementEvent(inputX, inputY,
                isWalking, isRunning, isIdle, isCarrying,
                toolEffect,
                isUsingToolUp, isUsingToolDown, isUsingToolLeft, isUsingToolRight,
                isLiftingToolUp, isLiftingToolDown, isLiftingToolLeft, isLiftingToolRight,
                isPickingUp, isPickingDown, isPickingLeft, isPickingRight,
                isSwingingToolUp, isSwingingToolDown, isSwingingToolLeft, isSwingingToolRight,
                idleUp, idleDown, idleLeft, idleRight);
    }
}