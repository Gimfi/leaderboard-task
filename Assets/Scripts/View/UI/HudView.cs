using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;
using View.UI.Constants;
using Zenject;

namespace View.UI
{
    public class HudView : MonoBehaviour
    {
        [SerializeField]
        private Button _leaderboardButton;

        private IPopupManagerService _popupManagerServiceService;

        [Inject]
        private void Initialize(IPopupManagerService popupManagerService)
        {
            _popupManagerServiceService = popupManagerService;
            _leaderboardButton.onClick.AddListener(CreateWindow);
        }

        private void OnDestroy()
        {
            _leaderboardButton.onClick.RemoveListener(CreateWindow);
        }

        private void CreateWindow()
        {
            _popupManagerServiceService.OpenPopup(UIConstants.LeaderboardWindowName);
        }
    }
}
