using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public CameraSettings TargetCamera { get => this; }

    [SerializeField] private Transform actor;

    [Range(-10f, 10f)]
    [SerializeField] private float verticalPosition;
    [Range(-10f, 10f)]
    [SerializeField] private float horizontalPosition;

    private void Update()
    {
        if (actor != null)
            LockCameraOntoActor(actor);
        else
            Debug.LogError("Don't set actor for camera, please set it");

    }

    private void OnDrawGizmos()
    {
        if (actor != null)
            LockCameraOntoActor(actor);
        else
            Debug.LogWarning("Don't set actor for camera, please set it before start");
    }

    private void LockCameraOntoActor(Transform actor)
    {
        transform.position = new Vector3(actor.position.x + horizontalPosition, actor.position.y + verticalPosition, actor.position.z);
    }
}
