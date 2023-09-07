using UnityEngine;

namespace MVP
{
    public abstract class PlayerViewBase : MonoBehaviour
    {
        protected PlayerPresenterBase playerPresenter;

        public void Initialize(PlayerPresenterBase playerPresenter)
        {
            this.playerPresenter = playerPresenter;
        }
    }
}