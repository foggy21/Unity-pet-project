using UnityEngine;

namespace MVP
{
    public class PlayerModel : PlayerModelBase
    {
        private float speedOfMovement = 5f;
        private float speedOfRotationOfCamera = 60f;
        private float speedOfRotationOfCharacter = 20f;

        private Vector3 newRotationOfCamera;
        private Vector3 newPositionOfCharacter;
        private Quaternion newRotationOfCharacter;

        protected override float SpeedOfMovement { get => speedOfMovement; set => speedOfMovement = value; }
        protected override float SpeedOfRotationOfCamera { get => speedOfRotationOfCamera; set => speedOfRotationOfCamera = value; }
        protected override float SpeedOfRotationOfCharacter { get => speedOfRotationOfCharacter; set => speedOfRotationOfCharacter = value; }

        public override Vector3 NewRotationOfCamera => newRotationOfCamera;
        public override Vector3 NewPositionOfCharacter => newPositionOfCharacter;
        public override Quaternion NewRotationOfCharacter => newRotationOfCharacter;

        public override void RotateCameraInDirection(Vector3 direction)
        {
            newRotationOfCamera = direction * SpeedOfRotationOfCamera;
        }

        public override void MoveCharacterInDirection(Vector3 direction)
        {
            Vector3 relativeDirectionOfMovementToCamera = GetRelativeInputToCamera(CameraOfCharacter.transform, direction);
            newPositionOfCharacter = relativeDirectionOfMovementToCamera * speedOfMovement;
        }

        private Vector3 GetRelativeInputToCamera(Transform camera, Vector3 direction)
        {
            Vector3 cameraForward = NormolizeDirectionOfCamera(camera.forward);
            Vector3 cameraRight = NormolizeDirectionOfCamera(camera.right);
            Vector3 relativeDirectionOfCamera = cameraForward * direction.z + cameraRight * direction.x;
            return relativeDirectionOfCamera;
        }

        private Vector3 NormolizeDirectionOfCamera(Vector3 directionOfCamera)
        {
            directionOfCamera.y = 0;
            return directionOfCamera.normalized;
        }
    }
}