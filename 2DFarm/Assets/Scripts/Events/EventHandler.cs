using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolUp, bool isUsingToolDown, bool isUsingToolLeft, bool isUsingToolRight,
    bool isLiftingToolUp, bool isLiftingToolDown, bool isLiftingToolLeft, bool isLiftingToolRight,
    bool isPickingUp, bool isPickingDown, bool isPickingLeft, bool isPickingRight,
    bool isSwingingToolUp, bool isSwingingToolDown, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight);

public static class EventHandler
{
    public static event Action DropSelectedItemEvent;
    public static void CallDropSelectedItemEvent()
    {
        if (DropSelectedItemEvent != null)
        {
            DropSelectedItemEvent();
        }
    }

    public static event Action RemoveSelectedItemFromInventoryEvent;
    public static void CallRemoveSelectedItemFromInventoryEvent()
    {
        if (RemoveSelectedItemFromInventoryEvent != null)
            RemoveSelectedItemFromInventoryEvent();
    }

    public static event Action<Vector3, HarvestActionEffect> HarvestActionEffectEvent;
    public static void CallHarvestActionEvent(Vector3 effectPosition, HarvestActionEffect harvestActionEffect)
    {
        if(HarvestActionEffectEvent != null)
        {
            HarvestActionEffectEvent(effectPosition, harvestActionEffect);
        }
    }

    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (InventoryUpdatedEvent != null)
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

    public static event Action<int, Season, int, string, int, int, int> AdvanceGameMinuteEvent;

    public static void CallAdvanceGameMinuteEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameMinuteEvent != null)
        {
            AdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    public static event Action<int, Season, int, string, int, int, int> AdvanceGameHourEvent;

    public static void CallAdvanceGameHourEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameHourEvent != null)
        {
            AdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    public static event Action<int, Season, int, string, int, int, int> AdvanceGameDayEvent;

    public static void CallAdvanceGameDayEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameDayEvent != null)
        {
            AdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    public static event Action<int, Season, int, string, int, int, int> AdvanceGameSeasonEvent;

    public static void CallAdvanceGameSeasonEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameSeasonEvent != null)
        {
            AdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    public static event Action<int, Season, int, string, int, int, int> AdvanceGameYearEvent;
    public static void CallAdvanceGameYearEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameYearEvent != null)
        {
            AdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    //Scene Load Events

    public static event Action BeforeSceneUnloadFadeOutEvent;

    public static void CallBeforeSceeneUnloadFadeOutEvent()
    {
        if(BeforeSceneUnloadFadeOutEvent != null)
        {
            BeforeSceneUnloadFadeOutEvent();
        }
    }

    public static event Action BeforeSceneUnloadEvent;

    public static void CallBeforeSceeneUnloadEvent()
    {
        if (BeforeSceneUnloadEvent != null)
        {
            BeforeSceneUnloadEvent();
        }
    }

    public static event Action AfterSceneLoadEvent;

    public static void CallAfterSceneLoadEvent()
    {
        if (AfterSceneLoadEvent != null)
        {
            AfterSceneLoadEvent();
        }
    }

    public static event Action AfterSceneLoadFadeInEvent;

    public static void CallAfterSceneLoadFadeInEvent()
    {
        if (AfterSceneLoadFadeInEvent != null)
        {
            AfterSceneLoadFadeInEvent();
        }
    }
    public static event Action InstantiateCropPrefabsEvent;
    public static void CallInstantiateCropPrefabsEvent()
    {
        if(InstantiateCropPrefabsEvent != null)
        {
            InstantiateCropPrefabsEvent();
        }
    }
}