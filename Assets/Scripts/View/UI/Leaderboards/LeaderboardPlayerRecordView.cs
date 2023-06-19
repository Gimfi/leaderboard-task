using SimplePopupManager;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View.UI.Constants;
using Zenject;

namespace View.UI.Leaderboards
{
    public class LeaderboardPlayerRecordView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _name;
        [SerializeField]
        private TMP_Text _score;
        [SerializeField]
        private TMP_Text _loadText;
        [SerializeField]
        private Image _avatar;

        private ILoadImageService _loadImageService;

        [Inject]
        private void Initialize(ILoadImageService loadImageService)
        {
            _loadImageService = loadImageService;
        }

        public async Task Init(PlayerDataItem playerDataItem)
        {
            _name.text = playerDataItem.name;
            _score.text = playerDataItem.score.ToString();

            _avatar.gameObject.SetActive(false);
            _loadText.gameObject.SetActive(true);
            _avatar.sprite = await _loadImageService.GetRemoteTexture(playerDataItem.avatar);
            _loadText.gameObject.SetActive(false);
            _avatar.gameObject.SetActive(true);


            UpdateViewByType(playerDataItem.type);
        }

        private void UpdateViewByType(string type)
        {
            switch (type)
            {
                case UIConstants.DiamondName:
                    _name.color = UIConstants.DiamondColor;
                    _name.fontSize += UIConstants.DiamondSize;
                    _score.color = UIConstants.DiamondColor;
                    _score.fontSize += UIConstants.DiamondSize;
                    break;

                case UIConstants.GoldName:
                    _name.color = UIConstants.GoldColor;
                    _name.fontSize += UIConstants.GoldSize;
                    _score.color = UIConstants.GoldColor;
                    _score.fontSize += UIConstants.GoldSize;
                    break;

                case UIConstants.SilverName:
                    _name.color = UIConstants.SilverColor;
                    _name.fontSize += UIConstants.SilverSize;
                    _score.color = UIConstants.SilverColor;
                    _score.fontSize += UIConstants.SilverSize;
                    break;

                case UIConstants.BronzeName:
                    _name.color = UIConstants.BronzeColor;
                    _name.fontSize += UIConstants.BronzeSize;
                    _score.color = UIConstants.BronzeColor;
                    _score.fontSize += UIConstants.BronzeSize;
                    break;

                default:
                    break;
            }
        }
    }
}