using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TimerController timer;
    public GameObject bigText;
    private static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OpenBigText(Color color, string text)
    {
        TextMeshProUGUI tmp = bigText.GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.color = color;
        bigText.SetActive(true);
    }

    public void CloseBigText()
    {
        StartCoroutine(CloseBigTextRoutine());
    }

    IEnumerator CloseBigTextRoutine()
    {
        bigText.GetComponent<Animator>().SetTrigger(Constants.ANIM_CLOSE);
        yield return new WaitForSeconds(5f);
        bigText.SetActive(false);
        yield break;
    }

    public static UIManager Instance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        //OpenBigText(Color.cyan, "TEST!!!!");
        timer.StartTimer(10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
