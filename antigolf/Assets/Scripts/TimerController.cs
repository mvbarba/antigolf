using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 1f;
    public bool timing;

    public TextMeshProUGUI timerText;
    private float startingFont;
    private float timeToTarget;
    float t;

    private static TimerController instance;

    private void Awake()
    {
        timing = false;
        instance = this;
    }

    public static TimerController Instance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        startingFont = timerText.fontSize;
    }

    public void SetTimerText(float num)
    {
        timerText.text = num.ToString("#0.00") + "s";
    }

    public void StartTimer(float seconds)
    {
        timeToTarget = seconds;
        timeRemaining = seconds;
        timing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timing)
        {
            if (timeRemaining <= 0f)
            {
                timeRemaining = 0.0f;
                timing = false;
                GameplayManager.Instance().WinRound();
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }

            timerText.text = (timeRemaining < 0) ? "0.00s" : timeRemaining.ToString("#0.00") + "s";
            t += Time.deltaTime / timeToTarget;
            timerText.fontSize = Mathf.Lerp(startingFont, 65f, t);
        }

    }
}
