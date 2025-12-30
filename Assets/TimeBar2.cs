using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar2 : MonoBehaviour
{
    public Slider timerSlider;
    public float sliderTimer;
    float realTimer = 0;
    int timer;
    public bool stopTimer = false;
    public TextMeshProUGUI timerText;

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
            realTimer += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = realTimer;
                timer = (int)sliderTimer;
                timerText.text = timer.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}