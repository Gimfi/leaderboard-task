using UnityEngine;
using Zenject;

namespace Installers.UISettings
{
    [CreateAssetMenu(fileName = "UISettingsInstaller", menuName = "Installers/UISettingsInstaller")]
    public class UISettingsInstaller : ScriptableObjectInstaller<UISettingsInstaller>
    {
        [SerializeField]
        private WindowSettings _windowSettings;

        public override void InstallBindings()
        {
            Container.BindInstances(_windowSettings);
        }
    }
}