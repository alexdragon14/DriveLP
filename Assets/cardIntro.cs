using UnityEngine;

public class cardIntro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeStart()
    {
        Time.timeScale = 1;
    }
}
