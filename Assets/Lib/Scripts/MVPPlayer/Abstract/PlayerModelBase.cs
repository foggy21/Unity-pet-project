using UnityEngine;

namespace MVP
{
    public abstract class PlayerModelBase
    {
        private Rigidbody rigidbodyOfCharacter;
        private CameraSettings cameraOfCharacter;

        protected abstract float SpeedOfMovement { get; set; }
        protected abstract float SpeedOfRotationOfCamera { get; set; }
        protected abstract float SpeedOfRotationOfCharacter { get; set; }

        public abstract Vector3 NewRotationOfCamera { get; }
        public abstract Vector3 NewPositionOfCharacter { get; }
        public abstract Quaternion NewRotationOfCharacter { get; }

        public Rigidbody RigidbodyOfCharacter { get =>  rigidbodyOfCharacter; set { if (rigidbodyOfCharacter == null) rigidbodyOfCharacter = value; } }

        public CameraSettings CameraOfCharacter { get =>  cameraOfCharacter; set { if (cameraOfCharacter == null) cameraOfCharacter = value; } }

        public abstract void MoveCharacterInDirection(Vector3 direction);
        public abstract void RotateCameraInDirection(Vector3 direction);
    }
}

