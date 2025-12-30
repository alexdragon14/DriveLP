using System.Threading.Tasks;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [HideInInspector] public PlayerControl playerScript;

    [SerializeField] private GameObject leaderboardParent;
    [SerializeField] private Transform leaderboardContentParent;
    [SerializeField] private Transform leaderboardItemPrefab;

    private string leaderboardID = "Learning_Score";

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardID, 0);
    }
    private async void Update()
    {
        if (leaderboardParent.activeInHierarchy)
        {
            UpdateLeaderboard();
        }
    }

    private async void UpdateLeaderboard()
    {
        while (Application.isPlaying && leaderboardParent.activeInHierarchy)
        {
            LeaderboardScoresPage leaderboardScoresPage = await LeaderboardsService.Instance.GetScoresAsync(leaderboardID);
            
            foreach (Transform t in leaderboardContentParent)
            {
                Destroy(t.gameObject);
            }

            foreach (LeaderboardEntry entry in leaderboardScoresPage.Results)
            {
                Transform leaderboardItem = Instantiate(leaderboardItemPrefab, leaderboardContentParent);
                leaderboardItem.GetChild(1).GetComponent<TextMeshProUGUI>().text = entry.PlayerName;
                leaderboardItem.GetChild(2).GetComponent<TextMeshProUGUI>().text = entry.Score.ToString();
            }
            
            await Task.Delay(500);
        }
    }
}
