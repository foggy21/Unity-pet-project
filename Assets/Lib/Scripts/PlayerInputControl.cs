
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControl : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    [Range(1f, 3f)]
    [SerializeField] private float multyplyingSpeedRotation;
    [Range(0f, 1f)]
    [SerializeField] private float maximumAllowedRotationInQuaternion;

    public void Look(InputAction.CallbackContext context)
    {
        float mouseMovementHorizontal = context.ReadValue<Vector2>().x;
        RotateCameraInMouseDirection(mouseMovementHorizontal);
        ClampRotationOfCamera();
    }

    private void RotateCameraInMouseDirection(float mouseMovementHorizontal)
    {
        cameraTarget.Rotate(Vector3.up * mouseMovementHorizontal * multyplyingSpeedRotation * Time.deltaTime);
    }

    private void ClampRotationOfCamera()
    {
        Quaternion currentRotationOfCamera = cameraTarget.rotation;
        currentRotationOfCamera.y = Mathf.Clamp(currentRotationOfCamera.y, -maximumAllowedRotationInQuaternion, maximumAllowedRotationInQuaternion);
        cameraTarget.rotation = currentRotationOfCamera;
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
