using UnityEngine;
using Unity.Services.Leaderboards;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using System;

public class LeaderboardMenu : Panel
{
    [SerializeField] private int playersPerPage = 25;
    [SerializeField] private LeaderboardsPlayerItem playerItemPrefab = null;
    [SerializeField] private RectTransform playersContainer = null;


    public async void AddScoreAsync(int score)
    {

    }

    private async void LoadPlayers()
    {

    }

    private void ClearPlayerList()
    {
        LeaderboardsPlayerItem[] items = playersContainer.GetComponentsInChildren<LeaderboardsPlayerItem>();
        if (items != null)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Destroy(items[i].gameObject);
            }
        }
    }

    private void Destroy(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
