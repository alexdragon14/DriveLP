using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
