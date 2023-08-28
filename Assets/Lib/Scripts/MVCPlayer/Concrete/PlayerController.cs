using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerControllerBase
{
    public PlayerController(PlayerModelBase playerModel) : base(playerModel) { }

    public override void OnLook(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            float playerInputOfLook = context.ReadValue<Vector2>().x;
            direcitonOfRotation = Vector3.up * (playerInputOfLook / Mathf.Abs(playerInputOfLook));
            playerModel.LookCharacterInDirection(direcitonOfRotation);
        }
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Here");
        Vector2 playerInputOfMovement = context.ReadValue<Vector2>();
        direcitonOfMovement = new Vector3(playerInputOfMovement.x, 0, playerInputOfMovement.y);
        playerModel.MoveCharacterInDirection(direcitonOfMovement);
    }
}
