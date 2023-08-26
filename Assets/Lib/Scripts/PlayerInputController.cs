using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraTarget;
    [Range(0f, 25f)]
    [SerializeField] private float speedOfCharacterMoving;
    [Range(0f, 20f)]
    [SerializeField] private float speedOfCharacterRotation;
    [Range(1f, 100f)]
    [SerializeField] private float multyplyingSpeedRotation;

    private Vector3 playerInputMovementDirection = Vector3.zero;
    private Rigidbody characterRigidbody;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCharacterInDirection(playerInputMovementDirection);
    }

    private void MoveCharacterInDirection(Vector3 direction)
    {
        Vector3 relativeDirectionOfMovementToCamera = GetRelativeInputToCamera(cameraTarget.transform, direction);
        characterRigidbody.MovePosition(characterRigidbody.position + relativeDirectionOfMovementToCamera * speedOfCharacterMoving * Time.fixedDeltaTime);
        if (direction != Vector3.zero)
        {
            RotateCharacterRelativeToCameraRotation(cameraTarget.transform.rotation);
        }
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

    private void RotateCharacterRelativeToCameraRotation(Quaternion cameraRotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, speedOfCharacterRotation * Time.fixedDeltaTime);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputOfDirection = context.ReadValue<Vector2>();
        playerInputMovementDirection = new Vector3(inputOfDirection.x, 0, inputOfDirection.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        float inputOfRotation = context.ReadValue<Vector2>().x;
        if (inputOfRotation != 0)
            inputOfRotation = normalizeInputOfRotation(inputOfRotation);
        RotateCameraInHorizontalDirection(inputOfRotation);
    }

    private void RotateCameraInHorizontalDirection(float inputOfRotation)
    {
        cameraTarget.transform.Rotate(Vector3.up * inputOfRotation * multyplyingSpeedRotation * Time.deltaTime);
    }

    private float normalizeInputOfRotation(float inputOfRotation)
    {
        return inputOfRotation / Mathf.Abs(inputOfRotation);
    }
}
