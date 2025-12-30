using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SectionMenu : MonoBehaviour
{
    public int sectionId;
    public Button[] buttons;

    public void Awake()
    {
        int unlockedSection = PlayerPrefs.GetInt("UnlockedSection", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedSection; i++)
        {
            buttons[i].interactable = true;
        }
    }

}
