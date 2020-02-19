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
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(Constants.Levels level)
    {
        StartCoroutine(SceneSwap(level));
    }

    IEnumerator SceneSwap(Constants.Levels level)
    {
        Instantiate(transition, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene((int)level);
    }
}
