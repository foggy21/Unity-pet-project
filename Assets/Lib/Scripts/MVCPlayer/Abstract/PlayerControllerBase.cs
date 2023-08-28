using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerControllerBase
{
    protected PlayerModelBase playerModel;

    protected Vector3 direcitonOfMovement;
    protected Vector3 direcitonOfRotation;

    public abstract void OnMove(InputAction.CallbackContext context);

    public abstract void OnLook(InputAction.CallbackContext context);

    public PlayerControllerBase(PlayerModelBase playerModel)
    {
        this.playerModel = playerModel;
    }
}
