using UnityEngine;

public abstract class PlayerViewBase : MonoBehaviour
{
    public abstract void SetPositionOfCharacter(Vector3 position);

    public abstract void SetLook(Vector3 rotation);

    public abstract void SetLook(Quaternion rotation);
}
