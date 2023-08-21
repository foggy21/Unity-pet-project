using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraTarget;
    [Range(0f, 25f)]
    [SerializeField] private float speedOfCharacterMoving;
    [Range(1f, 10f)]
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
        Quaternion finalCharacterRotation = camera.rotation;
        RotateCharacterOnAxis(finalCharacterRotation);
    }

    private void RotateCharacterOnAxis(Quaternion finalCharacterRotation)
    {
        float currentInterpolateParametr = 0;
        currentInterpolateParametr += speedOfCharacterRotation * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, finalCharacterRotation, currentInterpolateParametr);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputOfDirection = context.ReadValue<Vector2>();
        playerInputMovementDirection = new Vector3(inputOfDirection.x, 0, inputOfDirection.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        float inputOfRotation = context.ReadValue<Vector2>().x;
        RotateCameraInHorizontalDirection(inputOfRotation);
    }

    private void RotateCameraInHorizontalDirection(float movementDirection)
    {
        cameraTarget.transform.Rotate(Vector3.up * movementDirection * multyplyingSpeedRotation * Time.deltaTime);
    }
}
