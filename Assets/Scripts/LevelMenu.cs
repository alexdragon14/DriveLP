using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public int sectionId;
    public Button[] buttons;
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public void Awake()
    {
        if (sectionId == 1)
        {
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;
            }
        }
        else if (sectionId == 2)
        {
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel2", 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;
            }
        }
        else if (sectionId == 3)
        {
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel3", 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;
            }
        }
        else if (sectionId == 4)
        {
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel4", 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void OpenLevel(int levelId)
    {
        StartCoroutine(LoadAsynchronously(levelId));
    }

    IEnumerator LoadAsynchronously(int levelId)
    {
        string levelName = "Level " + sectionId + "-" + levelId;
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
