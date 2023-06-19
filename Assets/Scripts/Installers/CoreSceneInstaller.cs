using Binders.UI;
using SimplePopupManager;
using View.UI;
using Zenject;

namespace Installers
{
    public class CoreSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PopupManagerServiceService>().AsSingle();
            Container.BindInterfacesTo<HudController>().AsSingle();
            Container.BindInterfacesTo<LoadImageService>().AsSingle();
        }
    }
}