using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackgroundController : MonoBehaviour
{
    public GameObject holePrefab;

    private Color[] colors = { new Color(65f/255f, 58f/255f, 71/255f, 1), new Color(26f/255f, 4f/255f, 48f/255f, 1) };
    private GameObject lastObject;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBackground());
    }

    IEnumerator CreateBackground()
    {
        if (lastObject)
            lastObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;

        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        GameObject newObject = Instantiate(holePrefab, randomPositionOnScreen, Quaternion.identity);
        newObject.transform.parent = this.transform;
        newObject.transform.SetAsFirstSibling();
        SpriteRenderer rend = newObject.GetComponentInChildren<SpriteRenderer>();
        rend.color = colors[i++];
        rend.sortingOrder = 1;
        if (i >= colors.Length)
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
        
    }
}
