using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    public enum UITypeGame
    {
        BigText, 
        Menus,
        Level1A,
        Level2A,
        Level3A,
        Level4A,
    }

    [Serializable]
    public struct MenuElementGame
    {
        public GameObject obj;
        public UITypeGame type;
    }

    [SerializeField]
    public MenuElementGame[] menuElementsGame;

    public bool isPopups;
    public GameObject[] popups;
    private int i;

    public TimerController timer;
    public TextMeshProUGUI strokes;
    private static UIManager instance;


    private void Start()
    {
        StartPopups();
    }

    private void StartPopups()
    {
        if (isPopups)
        {
            popups[0].SetActive(true);
            i = 0;
        }
        else
        {
            PlayerController.Instance().active = true;
        }
    }

    public void NextPopup()
    {
        i++;
        if (popups.Length > i)
        {
            popups[i].SetActive(true);
        }
        else
        {
            PlayerController.Instance().active = true;
        }
        popups[i - 1].SetActive(false);
    }

    private void OpenUI(UITypeGame type, bool closeAll = false)
    {
        foreach (MenuElementGame element in menuElementsGame)
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

    private void CloseUI(UITypeGame type)
    {
        foreach (MenuElementGame element in menuElementsGame)
        {
            if (element.type == type)
                element.obj.SetActive(false);
        }
    }

    private GameObject GetUI(UITypeGame type)
    {
        foreach (MenuElementGame element in menuElementsGame)
        {
            if (element.type == type)
                return element.obj;
        }
        Debug.Log("Could not find UI matching type!");
        return null;
    }


    private void Awake()
    {
        instance = this;
    }

    public void OpenBigText(Color color, string text)
    {
        TextMeshProUGUI tmp = GetUI(UITypeGame.BigText).GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.color = color;
        OpenUI(UITypeGame.BigText);
    }

    public void OpenAndCloseBigText(String text)
    {
        StartCoroutine(OpenAndCloseBigTextRoutine(text));
    }

    IEnumerator OpenAndCloseBigTextRoutine(string text)
    {
        OpenBigText(Color.white, text);
        yield return new WaitForSeconds(2f);
        GetUI(UITypeGame.BigText).GetComponent<Animator>().SetTrigger(Constants.ANIM_CLOSE);
        yield return new WaitForSeconds(5f);
        CloseUI(UITypeGame.BigText);
        yield break;
    }

    public void CloseBigText()
    {
        StartCoroutine(CloseBigTextRoutine());
    }

    IEnumerator CloseBigTextRoutine()
    {
        GetUI(UITypeGame.BigText).GetComponent<Animator>().SetTrigger(Constants.ANIM_CLOSE);
        yield return new WaitForSeconds(5f);
        CloseUI(UITypeGame.BigText);
        yield break;
    }

    public void OpenMenus()
    {
        OpenUI(UITypeGame.Menus);
    }

    public void SetStrokes(int count)
    {
        strokes.text = (count < 0) ? "infinite" : count.ToString();
    }

    public static UIManager Instance()
    {
        return instance;
    }

    public void MenuButtonPress()
    {
        LevelController.Instance().ChangeScene(0);
    }

    public void ContinueButtonPress()
    {
        if (GameplayManager.Instance().lost)
            LevelController.Instance().ReloadScene();
        else
            LevelController.Instance().NextLevel();
    }

}