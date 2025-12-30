using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timeBar : MonoBehaviour
{
    public Slider timerSlider;
    public float sliderTimer;
    int timer;
    public bool stopTimer = false;
    public TextMeshProUGUI timerText;
    public GameObject winMenu;
    public QuizGameLogicScript gameLogicScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
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
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if(sliderTimer <= 0)
            {
                stopTimer = true;
            }

            if(stopTimer == false)
            {
                timerSlider.value = sliderTimer;
                timer = (int)sliderTimer;
                timerText.text = timer.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimer)
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);
            gameLogicScript.storeScore();
        }
    }
}
