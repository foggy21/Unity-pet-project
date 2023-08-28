using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerModelBase
{
    protected PlayerViewBase playerView;
    protected CameraSettings camera;

    protected abstract float SpeedOfMovement { get; set; }

    protected abstract float SpeedOfRotation { get; set; }

    protected abstract Rigidbody RigidbodyOfCharacter { get; }

    protected abstract CameraSettings Camera { get; }

    public abstract void MoveCharacterInDirection(Vector3 direction);

    public abstract void LookCharacterInDirection(Vector3 direction);

    public PlayerModelBase(PlayerViewBase playerView, CameraSettings camera)
    {
        this.playerView = playerView;
        this.camera = camera;
    }
}
