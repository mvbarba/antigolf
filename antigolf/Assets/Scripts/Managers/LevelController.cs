using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject transition;

    private static LevelController instance;

    public static LevelController Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeScene(Constants.Levels level)
    {
        StartCoroutine(SceneSwap(level));
    }

    public void NextLevel()
    {
        int num = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneSwap((Constants.Levels)num));
    }

    public void ReloadScene()
    {
        int num = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(SceneSwap((Constants.Levels)num));
    }

    IEnumerator SceneSwap(Constants.Levels level)
    {
        Instantiate(transition, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene((int)level);
    }

    public void UnlockNextLevel()
    {
        int num = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("L" + num, 1);
        PlayerPrefs.Save();
    }
}
