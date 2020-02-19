using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject golfball;
    public GameObject[] holes;

    private PlayerController player;
    private HoleController[] holeControllers;

    public GameObject blackScreenPrefab;
    GameObject blackScreen;

    private UIManager ui;

    public bool lost;
    private static GameplayManager instance;

    public bool active;
    public int strokes;
    public float time;

    public void Update()
    {
        ui.SetStrokes(strokes);
    }

    private void Awake()
    {
        active = false;
        instance = this;
        lost = false;
    }

    private void Start()
    {
        TimerController.Instance().SetTimerText(time);
        ui = UIManager.Instance();
        player = golfball.GetComponent<PlayerController>();
        holeControllers = new HoleController[holes.Length];
        for (int i = 0; i < holes.Length; i++)
        {
            holeControllers[i] = holes[i].GetComponent<HoleController>();
        }
    }

    public void StartMatch()
    {
        TimerController.Instance().StartTimer(time);
    }

    public static GameplayManager Instance()
    {
        return instance;
    }

    // What position were you at when you lost?
    public void LoseRound(Vector2 position)
    {
        blackScreen = Instantiate(blackScreenPrefab.gameObject, position, Quaternion.identity);
        UIManager.Instance().OpenBigText(Color.yellow, "YOU LOSE!");
        lost = true;
        //UIManager.Instance().CloseBigText();
    }

    public void WinRound()
    {
        PlayerController.Instance().Disable();
        active = false;
        UIManager.Instance().OpenBigText(Color.cyan, "HOLE IN NONE!");
    }

}
