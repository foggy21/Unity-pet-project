using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraTarget;
    [Range(0f, 25f)]
    [SerializeField] private float speedOfCharacterMoving;
    [Range(0f, 50f)]
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
        Vector3 localDirectionOfCharacter = GetLocalDirectionOfCharacterFromGlobal(direction);
        characterRigidbody.MovePosition(characterRigidbody.position + localDirectionOfCharacter * speedOfCharacterMoving * Time.fixedDeltaTime);
        if (direction != Vector3.zero)
            RotateCharacterRelativeToCamera(cameraTarget.transform);
    }

    private Vector3 GetLocalDirectionOfCharacterFromGlobal(Vector3 globalDirection)
    {
        Vector3 localDirection = transform.TransformDirection(globalDirection);
        return localDirection;
    }

    private void RotateCharacterRelativeToCamera(Transform camera)
    {
        characterRigidbody.rotation = Quaternion.Lerp(characterRigidbody.rotation, camera.rotation, speedOfCharacterRotation * Time.fixedDeltaTime);
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
            inputOfRotation = magnitudeInputOfRotation(inputOfRotation);
        RotateCameraInHorizontalDirection(inputOfRotation);
    }

    private void RotateCameraInHorizontalDirection(float inputOfRotation)
    {
        cameraTarget.transform.Rotate(Vector3.up * inputOfRotation * multyplyingSpeedRotation * Time.deltaTime);
    }

    private float magnitudeInputOfRotation(float inputOfRotation)
    {
        return inputOfRotation / Mathf.Abs(inputOfRotation);
    }
}
