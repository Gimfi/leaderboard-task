using System.Threading.Tasks;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using View.UI.Constants;

namespace View.UI.Leaderboards
{
    public class LeaderboardView : MonoBehaviour, IPopupInitialization
    {
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private LeaderboardPlayerRecordView _leaderboardPlayerRecordView;
        [SerializeField]
        private Transform _recordsContainer;

        private IPopupManagerService _popupManagerServiceService;

        public async Task Init(object param)
        {
            _popupManagerServiceService = param as IPopupManagerService;

            object leaderboardObject = await LoadLeaderboards();
            PlayerDataList playerDataList = GetPlayerDataList(leaderboardObject);
            CreateLeaderboardsView(playerDataList);

            AddListeners();
        }

        private async Task<object> LoadLeaderboards()
        {
            AsyncOperationHandle<Object> handle = Addressables.LoadAssetAsync<Object>(UIConstants.LeaderboardJSONName);
            await handle.Task;

            return handle.Result;
        }

        private PlayerDataList GetPlayerDataList(object param)
        {
            TextAsset jsonText = param as TextAsset;
            return JsonUtility.FromJson<PlayerDataList>(jsonText.text);
        }

        private void CreateLeaderboardsView(PlayerDataList playerDataList)
        {
            foreach (PlayerDataItem playerDataItem in playerDataList.leaderboard)
            {
                LeaderboardPlayerRecordView playerRecordView = Instantiate(_leaderboardPlayerRecordView, _recordsContainer);
                Task init = playerRecordView.Init(playerDataItem);
                playerRecordView.gameObject.SetActive(true);
            }
        }

        private void AddListeners()
        {
            _closeButton.onClick.AddListener(CloseWindow);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(CloseWindow);
        }

        private void CloseWindow()
        {
            _popupManagerServiceService.ClosePopup(UIConstants.LeaderboardWindowName);
        }
    }
}