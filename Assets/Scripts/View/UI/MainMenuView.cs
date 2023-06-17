using Installers.UISettings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace View.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _leaderboardButton;

        public void AddListener(UnityAction action)
        {
            _leaderboardButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            _leaderboardButton.onClick.RemoveListener(action);
        }

        public class Factory : PlaceholderFactory<MainMenuView>
        {
            private DiContainer _diContainer;
            private WindowSettings _windowSettings;

            public Factory(DiContainer diContainer, WindowSettings windowSettings)
            {
                _diContainer = diContainer;
                _windowSettings = windowSettings;
            }

            public override MainMenuView Create()
            {
                return _diContainer.InstantiatePrefabForComponent<MainMenuView>(_windowSettings.MainMenuUI);
            }
        }
    }
}
