using System;
using UnityEngine;
using View.UI;

namespace Installers.UISettings
{
    [Serializable]
    public class WindowSettings
    {
        public MainMenuView MainMenuUI => _mainMenuUI;
        [SerializeField]
        private MainMenuView _mainMenuUI;
    }
}