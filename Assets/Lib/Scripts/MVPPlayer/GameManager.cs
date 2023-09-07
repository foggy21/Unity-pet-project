using UnityEngine;
using UnityEngine.InputSystem;

namespace MVP
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerInputManager playerInputManager;

        private PlayerView playerView;
        private PlayerPresenter playerPresenter;
        private PlayerModel playerModel;

        private CameraSettings targetCamera;

        private void Start()
        {
            playerInputManager.playerJoinedEvent.AddListener(InitializePlayer);
        }


        private void InitializePlayer(PlayerInput playerInput)
        {
            InitializeWrapOfPlayer(playerInput);
            InitializePlayerModel();

            playerPresenter = new PlayerPresenter(playerModel, playerView);

            playerView.Initialize(playerPresenter);
        }

        private void InitializeWrapOfPlayer(PlayerInput playerInput)
        {
            GameObject playerWrapped = playerInput.transform.parent.gameObject;
            targetCamera = playerWrapped.GetComponentInChildren<CameraSettings>();
            playerView = playerWrapped.GetComponentInChildren<PlayerView>();
        }

        private void InitializePlayerModel()
        {
            playerModel = new PlayerModel();
            playerModel.RigidbodyOfCharacter = playerView.GetComponent<Rigidbody>();
            playerModel.CameraOfCharacter = targetCamera;
        }
    }
}


