using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    private AnimationOverrides animationOverrides;

    //Movement Parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isLiftingToolDown;
    private bool isLiftingToolLeft;
    private bool isLiftingToolRight;
    private bool isLiftingToolUp;
    private bool isRunning;
    private bool isUsingToolDown;
    private bool isUsingToolLeft;
    private bool isUsingToolRight;
    private bool isUsingToolUp;
    private bool isSwingingToolDown;
    private bool isSwingingToolLeft;
    private bool isSwingingTooldRight;
    private bool isSwingingToolUp;
    private bool isWalking;
    private bool isPickingUp;
    private bool isPickingDown;
    private bool isPickingRight;
    private bool isPickingLeft;
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidBody2D;

    private Camera mainCamera;

#pragma warning disable 414
    private Direction playerDirection;
#pragma warning restore 414

    private List<CharacterAttribute> characterAttributeCustomisationList;
    private float movementSpeed;

    [Tooltip("Should be populated in the prefab with the equipped item sprite renderer")]
    [SerializeField] private SpriteRenderer equippedItemSpriteRenderer;

    private CharacterAttribute armsCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;

    private bool _playerInputIsDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        rigidBody2D = GetComponent<Rigidbody2D>();

        animationOverrides = GetComponentInChildren<AnimationOverrides>();

        armsCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.arms, PartVariantColor.none, PartVariantType.none);

        characterAttributeCustomisationList = new List<CharacterAttribute>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        #region Player Input

        if (!PlayerInputIsDisabled)
        {
            ResetAnimationTriggers();

            PlayerMovementInput();

            PlayerWalkInput();

            EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
                isUsingToolUp, isUsingToolDown, isUsingToolLeft, isUsingToolRight,
                isLiftingToolUp, isLiftingToolDown, isLiftingToolLeft, isLiftingToolRight,
                isPickingUp, isPickingDown, isPickingLeft, isPickingRight,
                isSwingingToolUp, isSwingingToolDown, isSwingingToolLeft, isSwingingTooldRight,
                false, false, false, false);
        }

        #endregion


    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    
    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);

        rigidBody2D.MovePosition(rigidBody2D.position + move);
    } 

    private void ResetAnimationTriggers()
    {
        isLiftingToolDown = false;
        isLiftingToolLeft = false;
        isLiftingToolRight = false;
        isLiftingToolUp = false;
        isUsingToolDown = false;
        isUsingToolLeft = false;
        isUsingToolRight = false;
        isUsingToolUp = false;
        isSwingingToolDown = false;
        isSwingingToolLeft = false;
        isSwingingTooldRight = false;
        isSwingingToolUp = false;
        isPickingUp = false;
        isPickingDown = false;
        isPickingRight = false;
        isPickingLeft = false;
        toolEffect = ToolEffect.none;
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if (xInput != 0 && yInput !=0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            //Player Direction For Save Game
            if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            if (yInput > 0)
            {
                playerDirection = Direction.up;
            }
            if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
        }
        else if (xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }

    private void PlayerWalkInput()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
    private void ResetMovement()
    {
        xInput = 0f;
        yInput = 0f;
        isRunning = false;
        isWalking = false;
        isIdle = true;
    }
    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();

        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
                isUsingToolUp, isUsingToolDown, isUsingToolLeft, isUsingToolRight,
                isLiftingToolUp, isLiftingToolDown, isLiftingToolLeft, isLiftingToolRight,
                isPickingUp, isPickingDown, isPickingLeft, isPickingRight,
                isSwingingToolUp, isSwingingToolDown, isSwingingToolLeft, isSwingingTooldRight,
                false, false, false, false);

    }

    public void EnablePlayerInput()
    {
        PlayerInputIsDisabled = false;
    }

    public void DisablePlayerInput()
    {
        PlayerInputIsDisabled = true;
    }

    public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }

    public void ClearCarriedItem()
    {
        equippedItemSpriteRenderer.sprite = null;
        equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        armsCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(armsCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParamaters(characterAttributeCustomisationList);

        isCarrying = false;
    }

    public void ShowCarriedItem(int itemCode)
    {
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);
        if(itemDetails != null)
        {
            equippedItemSpriteRenderer.sprite = itemDetails.itemSprite;
            equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);

            armsCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(armsCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParamaters(characterAttributeCustomisationList);

            isCarrying = true;
        }
    }
}
