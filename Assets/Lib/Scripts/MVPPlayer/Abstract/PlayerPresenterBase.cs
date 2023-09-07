using UnityEngine;
using UnityEngine.InputSystem;

namespace MVP
{
    public abstract class PlayerPresenterBase
    {
        protected PlayerModelBase playerModel;
        protected PlayerViewBase playerView;

        public PlayerPresenterBase (PlayerModelBase playerModel, PlayerViewBase playerView)
        {
            this.playerModel = playerModel;
            this.playerView = playerView;
        }

        public abstract void UpdateCharacterMovement(InputAction.CallbackContext context);
        public abstract void UpdateCameraLook(InputAction.CallbackContext context);

        public Vector3 GetRotationOfCamera()
        {
            return playerModel.NewRotationOfCamera;
        }

        public Vector3 GetPositionOfCharacter()
        {
            return playerModel.NewPositionOfCharacter;
        }

        public Quaternion GetRotationOfCharacter()
        {
            return playerModel.NewRotationOfCharacter;
        }
    }
}


