using UnityEngine;
using UnityEngine.InputSystem;

namespace MVP
{
    public class PlayerPresenter : PlayerPresenterBase
    {
        public PlayerPresenter(PlayerModelBase playerModel, PlayerViewBase playerView) : base(playerModel, playerView) { }

        public override void UpdateCameraLook(InputAction.CallbackContext context)
        {
            float playerInputOfLookHorizontally = context.ReadValue<Vector2>().x;
            Vector3 directionOfRotation = Vector3.up * playerInputOfLookHorizontally;
            playerModel.RotateCameraInDirection(directionOfRotation);
        }

        public override void UpdateCharacterMovement(InputAction.CallbackContext context)
        {
            Vector2 playerInputOfMovement = context.ReadValue<Vector2>();
            Vector3 movementDirection = new Vector3(playerInputOfMovement.x, 0, playerInputOfMovement.y);
            playerModel.MoveCharacterInDirection(movementDirection);
        }

    }
}
