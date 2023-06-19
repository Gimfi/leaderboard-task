using SimplePopupManager;
using View.UI.Constants;
using Zenject;

namespace Binders.UI
{
    public sealed class HudController : IInitializable
    {
        private readonly IPopupManagerService _popupManagerServiceService;

        public HudController(IPopupManagerService popupManagerServiceService)
        {
            _popupManagerServiceService = popupManagerServiceService;
        }

        public void Initialize()
        {
            _popupManagerServiceService.OpenPopup(UIConstants.MainMenuName);
        }
    }
}
