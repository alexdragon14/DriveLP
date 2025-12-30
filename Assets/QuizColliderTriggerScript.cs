using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class QuizColliderTriggerScript : MonoBehaviour
{
    public bool isRight;
    public bool isFinish;
    public GameObject car;
    public GameObject finishWin;
    public QuizGameLogicScript gameLogicScript;
    public GameObject rightIcon;
    public GameObject wrongIcon;
    public GameObject rightText;
    public GameObject wrongText;
    public QuizGameLogicScript QuizGameLogicScript;
    public float delay;

    void Start()
    {
        gameLogicScript = car.GetComponent<QuizGameLogicScript>();
    }
    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (isRight)
        {
            gameLogicScript.quizScore = gameLogicScript.quizScore + 1000;
            rightIcon.SetActive(true);
            rightText.SetActive(true);
            StartCoroutine(DoSomething2(delay));
        }
        else
        {
            gameLogicScript.quizScore = gameLogicScript.quizScore - 500;
            wrongIcon.SetActive(true);
            wrongText.SetActive(true);
            StartCoroutine(DoSomething(delay));
        }

        if (isFinish)
        {
            Time.timeScale = 0;
            finishWin.SetActive(true);
            QuizGameLogicScript.storeScore();
        }
    }

    IEnumerator DoSomething(float duration)
    {
        yield return new WaitForSeconds(duration);
        wrongIcon.SetActive(false);
        wrongText.SetActive(false);
    }

    IEnumerator DoSomething2(float duration)
    {
        yield return new WaitForSeconds(duration);
        rightIcon.SetActive(false);
        rightText.SetActive(false);
    }
}
