using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }
    public bool isGameStarted = false; // Tracks whether the game has started
    public int sectionId;
    public int levelId;
    public bool firstTimer = true;
    public GameObject firstTimerPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;

        if (firstTimer)
        {
            firstTimerPanel.SetActive(true);
        }
        else
        {
            firstTimerPanel.SetActive(false);
        }
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
        string levelName = "Level " + sectionId + "-" + (levelId + 1);
        SceneManager.LoadScene(levelName);
        
    }

    public void restartLevel()
    {
        StartCoroutine(LoadAsynchronously());
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronously()
    {
        string levelName = "Level " + sectionId + "-" + levelId;
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        yield return null;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

}
