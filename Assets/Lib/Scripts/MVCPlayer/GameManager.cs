using UnityEngine;
using UnityEngine.InputSystem;

namespace MVC 
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerInputManager playerInputManager;

        private PlayerModel playerModel;
        private PlayerController playerController;
        private PlayerView playerView;

        private CameraSettings targetCamera;

        void Awake()
        {
            targetCamera = playerInputManager.playerPrefab.GetComponentInChildren<CameraSettings>();
            playerView = playerInputManager.playerPrefab.GetComponentInChildren<PlayerView>();
        }

        private void Start()
        {
            playerModel = new PlayerModel(playerView, targetCamera);
            playerController = new PlayerController(playerModel);

            //Failed to input data with new input system when controller isn't MonoBehaviour.
        }
    }
}