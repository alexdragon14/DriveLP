using System.Collections;
using TMPro;
using UnityEngine;

public class QuizGameLogicScript : MonoBehaviour
{
    public int quizScore = 0;
    public int bonusScore;
    public int totalScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI bonusScoreText2;
    public TextMeshProUGUI totalScoreText;
    public float countdown;
    public bool stopTimer = false;
    public TextMeshProUGUI timerText;
    int timer;
    public GameObject countdownText;
    private Rigidbody2D rb;
    public GameObject[] questionPanel;
    public GameObject finishWin;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            countdown -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (stopTimer == false)
            {
                timer = (int)countdown;
                timerText.text = timer.ToString();
            }

            if (countdown < 1)
            {
                stopTimer = true;
            }
            
        }
        timerText.text = "GO!";
        yield return new WaitForSeconds(1);
        countdownText.SetActive(false);
        for (int i = 0; i < questionPanel.Length; i++)
        {
            questionPanel[i].SetActive(true);
            yield return new WaitForSeconds(5);
            questionPanel[i].SetActive(false);
            yield return new WaitForSeconds(9.5f);
        }

    }

    void Update()
    {
        totalScore = quizScore;
        totalScoreText.text = totalScore.ToString();
        scoreText.text = totalScore.ToString();
    }

    public void storeScore()
    {
        PlayerPrefs.SetInt("totalScore", (PlayerPrefs.GetInt("totalScore") + totalScore));
    }


}
