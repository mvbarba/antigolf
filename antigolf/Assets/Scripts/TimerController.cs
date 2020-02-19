using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 1f;
    bool timing = false;

    private TextMeshProUGUI timerText;
    private float startingFont;
    private float timeToTarget;
    float t; 

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        startingFont = timerText.fontSize;
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
                UIManager.Instance().OpenBigText(Color.cyan, "HOLE IN NONE!");
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }

            timerText.text = timeRemaining.ToString("#0.00") + "s";
            t += Time.deltaTime / timeToTarget;
            timerText.fontSize = Mathf.Lerp(startingFont, 65f, t);
        }

    }
}
