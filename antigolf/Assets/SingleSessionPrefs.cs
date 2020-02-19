using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSessionPrefs : MonoBehaviour
{
    private static SingleSessionPrefs instance;

    //Stores prefs that are deleted when you restart the game
    public bool SeenMenu;

    public static SingleSessionPrefs Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
