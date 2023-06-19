using System.Threading.Tasks;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using View.UI.Constants;
using Zenject;

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

        private DiContainer _container;
        private IPopupManagerService _popupManagerServiceService;
        private AsyncOperationHandle<Object> _leaderboardJSONHandle;

        [Inject]
        private void Initialize(DiContainer container, IPopupManagerService popupManagerService)
        {
            _container = container;
            _popupManagerServiceService = popupManagerService;
        }

        public async Task Init(object param)
        {
            object leaderboardObject = await LoadLeaderboards();
            PlayerDataList playerDataList = GetPlayerDataList(leaderboardObject);
            CreateLeaderboardsView(playerDataList);

            AddListeners();
        }

        private async Task<object> LoadLeaderboards()
        {
            _leaderboardJSONHandle = Addressables.LoadAssetAsync<Object>(UIConstants.LeaderboardJSONName);
            await _leaderboardJSONHandle.Task;

            return _leaderboardJSONHandle.Result;
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
                LeaderboardPlayerRecordView playerRecordView = _container.InstantiatePrefabForComponent<LeaderboardPlayerRecordView>(_leaderboardPlayerRecordView, _recordsContainer);
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
            Addressables.Release(_leaderboardJSONHandle);
            _closeButton.onClick.RemoveListener(CloseWindow);
        }

        private void CloseWindow()
        {
            _popupManagerServiceService.ClosePopup(UIConstants.LeaderboardWindowName);
        }
    }
}