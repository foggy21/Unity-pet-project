using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [Range(0f, 200f)]
    [SerializeField] private float speedOfRotation;
    [Range(0f, 1f)]
    [SerializeField] private float maximumAllowedRotationInQuaternion;
    [SerializeField] private PlayerInput playerInput;


    public void Look(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        int deltaInputX = value.x > 0 ? 1 : (value.x < 0 ? -1 : 0);
        transform.Rotate(Vector3.up * deltaInputX * speedOfRotation * Time.deltaTime);
        Quaternion clampedRotation = transform.rotation;
        clampedRotation.y = Mathf.Clamp(clampedRotation.y, -maximumAllowedRotationInQuaternion, maximumAllowedRotationInQuaternion);
        transform.rotation = clampedRotation;
    }

    private void OnEnable()
    {
        playerInput.actions["Look"].performed += Look;
    }


    private void OnDisable()
    {
        playerInput.actions["Look"].performed -= Look;
    }
}
