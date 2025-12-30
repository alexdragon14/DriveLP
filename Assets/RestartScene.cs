using Goldmetal.UndeadSurvivor;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Restart : MonoBehaviour
{
    public int sectionId;
    public int levelId;
    public GameObject Panel;
    public float delay;

    public void RestartButton(int levelId)
    {
        StartCoroutine(LoadAsynchronously(levelId));
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronously(int levelId)
    {
        string levelName = "Level " + sectionId + "-" + levelId;
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        yield return null;

    }

    public void OpenPanel()
    {

        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (Panel.activeSelf == false)
            {

                Panel.SetActive(true);

                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");

                    animator.SetBool("open", !isOpen);
                    StartCoroutine(DoSomething2(delay));
                }
            }
            else if (Panel.activeSelf == true)
            {

                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");

                    animator.SetBool("open", !isOpen);

                    StartCoroutine(DoSomething(delay));
                    Time.timeScale = 1;
                }



            }

        }
    }

    IEnumerator DoSomething(float duration)
    {
        yield return new WaitForSeconds(duration);
        Panel.SetActive(false);
    }

    IEnumerator DoSomething2(float duration)
    {
        yield return new WaitForSeconds(duration);
        Time.timeScale = 0;
    }
}
