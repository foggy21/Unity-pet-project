using UnityEngine;
using UnityEngine.InputSystem;

namespace MVP
{
    public class PlayerView : PlayerViewBase
    {
        [SerializeField] private CameraSettings targetCamera;
        private Rigidbody rigidbodyOfCharacter;

        private void Start()
        {
            rigidbodyOfCharacter = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 rotationOfCamera = playerPresenter.GetRotationOfCamera();
            targetCamera.transform.Rotate(rotationOfCamera * Time.deltaTime);

            Vector3 positionOfCharacter = playerPresenter.GetPositionOfCharacter();
            rigidbodyOfCharacter.MovePosition(rigidbodyOfCharacter.position + positionOfCharacter * Time.deltaTime);

            rigidbodyOfCharacter.rotation = Quaternion.Slerp(rigidbodyOfCharacter.rotation, targetCamera.transform.rotation, Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            playerPresenter.UpdateCharacterMovement(context);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            playerPresenter.UpdateCameraLook(context);
        }
    }
}

