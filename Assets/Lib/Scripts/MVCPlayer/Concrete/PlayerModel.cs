using UnityEngine;

public class PlayerModel : PlayerModelBase
{
    private float speedOfMovement = 5f;
    private float speedOfRotation = 60f;

    public PlayerModel(PlayerViewBase playerView, CameraSettings camera) : base(playerView, camera) { }

    protected override float SpeedOfMovement { get => speedOfMovement; set => speedOfMovement = value; }
    protected override float SpeedOfRotation { get => speedOfRotation; set => speedOfRotation = value; }
    protected override Rigidbody RigidbodyOfCharacter { get => playerView.GetComponent<Rigidbody>(); }
    protected override CameraSettings Camera { get => camera; }

    public override void LookCharacterInDirection(Vector3 direction)
    {
        Vector3 newRotation = direction * speedOfRotation;
        playerView.SetLook(newRotation);
    }

    public override void MoveCharacterInDirection(Vector3 direction)
    {
        Vector3 relativeDirectionOfMovementToCamera = GetRelativeDirecionOfMovementToCamera(Camera.transform, direction);
        Vector3 newPositionOfCharacter = RigidbodyOfCharacter.position + relativeDirectionOfMovementToCamera * speedOfMovement;
        playerView.SetPositionOfCharacter(newPositionOfCharacter);
        RotateCameraRelativeToDirectionOfMovement(Camera.transform.rotation);
    }

    private Vector3 GetRelativeDirecionOfMovementToCamera(Transform camera, Vector3 direction)
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

    private void RotateCameraRelativeToDirectionOfMovement(Quaternion cameraRotation)
    {
        Quaternion newRotation = Quaternion.Slerp(RigidbodyOfCharacter.rotation, cameraRotation, speedOfRotation * Time.fixedDeltaTime);
        playerView.SetLook(newRotation);
    }
}
