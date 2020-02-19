using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject blackScreenPrefab;
    GameObject blackScreen;

    private static GameplayManager instance;


    private void Awake()
    {
        instance = this;
    }

    public static GameplayManager Instance()
    {
        return instance;
    }

    // What position were you at when you lost?
    public void LoseRound(Vector2 position)
    {
        blackScreen = Instantiate(blackScreenPrefab.gameObject, position, Quaternion.identity);
        UIManager.Instance().OpenBigText();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
