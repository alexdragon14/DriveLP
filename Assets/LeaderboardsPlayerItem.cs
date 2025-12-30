using UnityEngine;
using Unity.Services.Leaderboards.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class LeaderboardsPlayerItem : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI rankText = null;
    [SerializeField] public TextMeshProUGUI nameText = null;
    [SerializeField] public TextMeshProUGUI scoreText = null;

    private LeaderboardEntry player = null;

    public void Initialize(LeaderboardEntry player)
    {
        this.player = player;
        rankText.text = (player.Rank + 1).ToString();
        nameText.text = player.PlayerName;
        scoreText.text = player.Score.ToString();
    }
}
