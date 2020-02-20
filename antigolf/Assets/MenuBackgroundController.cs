using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuBackgroundController : MonoBehaviour
{
    [Serializable]
    public class SerializedColor
    {
        [Range(0f, 255f)]
        public float r;

        [Range(0f, 255f)]
        public float g;

        [Range(0f, 255f)]
        public float b;
    }

    public SerializedColor[] serializedColors;

    public GameObject holePrefab;

  

    private Color[] colors;
    private GameObject lastObject;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[serializedColors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(serializedColors[i].r / 255f, serializedColors[i].g / 255f, serializedColors[i].b / 255f);
        }
        StartCoroutine(CreateBackground());
    }

    IEnumerator CreateBackground()
    {
        if (lastObject)
            lastObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;

        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(UnityEngine.Random.value, UnityEngine.Random.value));
        GameObject newObject = Instantiate(holePrefab, randomPositionOnScreen, Quaternion.identity);
        newObject.transform.parent = this.transform;
        newObject.transform.SetAsFirstSibling();
        SpriteRenderer rend = newObject.GetComponentInChildren<SpriteRenderer>();
        rend.color = colors[i++];
        rend.sortingOrder = 1;
        if (i >= serializedColors.Length)
            i = 0;
        yield return new WaitForSeconds(1f);
        if (lastObject)
            Destroy(lastObject);
        lastObject = newObject;
        StartCoroutine(CreateBackground());
    }

    // Update is called once per frame
    void Update()
    {
        colors = new Color[serializedColors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(serializedColors[i].r / 255f, serializedColors[i].g / 255f, serializedColors[i].b / 255f);
        }
    }
}
