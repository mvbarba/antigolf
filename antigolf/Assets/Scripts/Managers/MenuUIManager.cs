using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuUIManager : MonoBehaviour
{
    public enum UIType
    {
        StartMenu,
        LevelSelect
    }

    [Serializable]
    public struct MenuElement
    {
        public GameObject obj;
        public UIType type;
    }

    [SerializeField]
    public MenuElement[] menuElements;


    public void LoadLevel(int num)
    {
        LevelController.Instance().ChangeScene((Constants.Levels)num);
    }

    private void CloseAllUI()
    {
        foreach (MenuElement element in menuElements)
        {
            element.obj.SetActive(false);
        }
    }

    private void OpenUI(UIType type, bool closeAll = false)
    {
        foreach (MenuElement element in menuElements)
        {
            if (element.type == type)
                element.obj.SetActive(true);
            else
            {
                if (closeAll)
                    element.obj.SetActive(false);
            }
        }
    }

    public void StartButtonPressed()
    {
        OpenUI(UIType.LevelSelect, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SEEN MENU: " + SingleSessionPrefs.Instance().SeenMenu);
        if (!SingleSessionPrefs.Instance().SeenMenu)
        {
            OpenUI(UIType.StartMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
