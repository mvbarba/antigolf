using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject bigText;
    private static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OpenBigText()
    {
        bigText.SetActive(true);
    }

    public static UIManager Instance()
    {
        return instance;
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
