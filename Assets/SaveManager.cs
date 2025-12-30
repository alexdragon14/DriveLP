using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using Unity.Services.CloudSave.Models;

public class SaveManager : MonoBehaviour
{
    public async Task SaveDataAsync(Game game, PlayerData playerData)
    {
        SaveData saveData = new SaveData(game, playerData);
        string json = JsonUtility.ToJson(saveData);

        try
        {
            await CloudSaveService.Instance.Data.ForceSaveAsync(new Dictionary<string, object>
            {
                { "saveData", json }
            });
            Debug.Log("Data saved successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save data: {e.Message}");
        }
    }

    public async Task<SaveData> LoadDataAsync()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync();
            if (savedData.ContainsKey("saveData"))
            {
                string json = savedData["saveData"];
                SaveData saveData = JsonUtility.FromJson<SaveData>(json);
                Debug.Log("Data loaded successfully!");
                return saveData;
            }
            else
            {
                Debug.LogWarning("No save data found.");
                return null;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load data: {e.Message}");
            return null;
        }
    }

    public async Task SaveData(string key, object value)
    {
        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(new System.Collections.Generic.Dictionary<string, object>
        {
            { key, value }
        });

            Debug.Log("Data saved: " + key + " = " + value);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }

    public async Task RetrieveData(string key)
    {
        try
        {
            var data = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { key });

            if (data.TryGetValue(key, out Item item))
            {
                Debug.Log($"Retrieved Data: {key} = {item.Value}");
            }
            else
            {
                Debug.Log("No data found for key: " + key);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to retrieve data: " + e.Message);
        }
    }

    public async Task DeleteData(string key)
    {
        try
        {
            await CloudSaveService.Instance.Data.Player.DeleteAsync(key); // Pass string directly
            Debug.Log($"Deleted data for key: {key}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to delete data: {e.Message}");
        }
    }
}

[System.Serializable]
public class Game
{
    public string level;
    public int score;

    public Game(string level, int score)
    {
        this.level = level;
        this.score = score;
    }
}

[System.Serializable]
public class PlayerData
{
    public string userId;
    public string username;
    public string charname;
    public string character;
    public int totalScore;

    public PlayerData(string userId, string username, string charname, string character, int totalScore)
    {
        this.userId = userId;
        this.username = username;
        this.charname = charname;
        this.character = character;
        this.totalScore = totalScore;
    }
}

[System.Serializable]
public class SaveData
{
    public Game game;
    public PlayerData playerData;

    public SaveData(Game game, PlayerData playerData)
    {
        this.game = game;
        this.playerData = playerData;
    }
}

[System.Serializable]
public class TreeNode
{
    public string NodeName;
    public List<TreeNode> Children = new List<TreeNode>();

    public TreeNode(string name)
    {
        NodeName = name;
    }
}

[System.Serializable]
public class TreeData
{
    public Dictionary<string, object> DataTree = new Dictionary<string, object>();
}