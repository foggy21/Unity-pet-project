using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControl : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    [Range(0f, 25f)]
    [SerializeField] private float speedOfCharacterMoving;
    [Range(1f, 3f)]
    [SerializeField] private float multyplyingSpeedRotation;
    [Range(0f, 1f)]
    [SerializeField] private float maximumAllowedRotationInQuaternion;

    private Vector3 rawInputMovement = Vector3.zero;

    private void FixedUpdate()
    {
        if (rawInputMovement != Vector3.zero)
        {
            MoveCharacterInDirection(rawInputMovement);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 movementDirection = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(movementDirection.x, 0, movementDirection.y);
    }
    
    private void MoveCharacterInDirection(Vector3 direction)
    {
        transform.Translate(direction * speedOfCharacterMoving * Time.deltaTime);
    }

    public void Look(InputAction.CallbackContext context)
    {
        float movementHorizontal = context.ReadValue<Vector2>().x;
        RotateCameraInHorizontalDirection(movementHorizontal);
        ClampRotationOfObject(cameraTarget);
    }

    private void RotateCameraInHorizontalDirection(float movementDirection)
    {
        cameraTarget.Rotate(Vector3.up * movementDirection * multyplyingSpeedRotation * Time.deltaTime);
    }

    private void ClampRotationOfObject(Transform objectTransform)
    {
        Quaternion currentRotationOfCameraTarget = objectTransform.rotation;
        currentRotationOfCameraTarget.y = Mathf.Clamp(currentRotationOfCameraTarget.y, -maximumAllowedRotationInQuaternion, maximumAllowedRotationInQuaternion);
        objectTransform.rotation = currentRotationOfCameraTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.position);
        Gizmos.DrawLine(Camera.main.transform.position - Camera.main.transform.right, Camera.main.transform.position);
        Gizmos.DrawLine(Camera.main.transform.position + Camera.main.transform.right, Camera.main.transform.position);
        Gizmos.DrawLine(Camera.main.transform.position - Camera.main.transform.forward, Camera.main.transform.position);
    }
}
