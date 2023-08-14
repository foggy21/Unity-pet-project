using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Range(0f, 500f)]
    [SerializeField] private float speedOfRotation;
    [Range(0f, 1f)]
    [SerializeField] private float maximumAllowedRotationInQuaternion;
    
    void Update()
    {
        float mousePositionX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.down * speedOfRotation * mousePositionX * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Quaternion clampedRotation = transform.rotation;
        clampedRotation.y = Mathf.Clamp(clampedRotation.y, -maximumAllowedRotationInQuaternion, maximumAllowedRotationInQuaternion);
        transform.rotation = clampedRotation;
    }

}