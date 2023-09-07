using UnityEngine;

namespace MVC
{
    public class PlayerView : PlayerViewBase
    {
        private Rigidbody rigidbodyOfCharacter;

        private void Start()
        {
            rigidbodyOfCharacter = GetComponent<Rigidbody>();
        }

        public override void SetLook(Vector3 rotation)
        {
            transform.Rotate(rotation * Time.deltaTime);
        }

        public override void SetLook(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public override void SetPositionOfCharacter(Vector3 position)
        {
            rigidbodyOfCharacter.MovePosition(position * Time.deltaTime);
        }
    }
}