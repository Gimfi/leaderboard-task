using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using View.UI.Constants;

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

        public async Task Init(PlayerDataItem playerDataItem)
        {
            _name.text = playerDataItem.name;
            _score.text = playerDataItem.score.ToString();

            _avatar.gameObject.SetActive(false);
            _loadText.gameObject.SetActive(true);
            Texture2D avatar = await GetRemoteTexture(playerDataItem.avatar);
            _loadText.gameObject.SetActive(false);
            _avatar.gameObject.SetActive(true);
            _avatar.sprite = Sprite.Create(avatar, new Rect(0, 0, avatar.width, avatar.height), new Vector2(0, 0));

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

        public async Task<Texture2D> GetRemoteTexture(string url)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
            {
                UnityWebRequestAsyncOperation asyncOp = www.SendWebRequest();
                while (asyncOp.isDone == false)
                {
                    await Task.Delay(100);
                }

                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }
}