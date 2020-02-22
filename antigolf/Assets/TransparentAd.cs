using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentAd : MonoBehaviour
{
    bool startNow;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        startNow = false;
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(startTime());
    }

    IEnumerator startTime()
    {
        yield return new WaitForSeconds(1f);
        startNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startNow)
        {
            float num = Mathf.Lerp(sprite.color.a, 0f, Time.deltaTime * 3);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, num);
        }
    }
}
