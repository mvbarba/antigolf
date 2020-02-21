using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockCheck : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("L" + level, 0) == 1)
            GetComponent<Image>().color = Color.grey;
    }
}
