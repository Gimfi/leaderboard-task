using SimplePopupManager;
using View.UI;
using View.UI.Constants;
using Zenject;

namespace Binders.UI
{
    public class UIBinder : IInitializable
    {
        private readonly MainMenuView.Factory _mainMenuViewFactory;
        private readonly IPopupManagerService _popupManagerServiceService;

        private MainMenuView _mainMenuView;

        public UIBinder(MainMenuView.Factory mainMenuViewFactory, IPopupManagerService popupManagerServiceService)
        {
            _mainMenuViewFactory = mainMenuViewFactory;
            _popupManagerServiceService = popupManagerServiceService;
        }

        public void Initialize()
        {
            _mainMenuView = _mainMenuViewFactory.Create();
            _mainMenuView.AddListener(CreateWindow);
        }

        private void CreateWindow()
        {
            _popupManagerServiceService.OpenPopup(UIConstants.LeaderboardWindowName, _popupManagerServiceService);
        }
    }
}
