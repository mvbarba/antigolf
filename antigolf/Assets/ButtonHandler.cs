using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private ParticleSystem particles;
    private SpriteRenderer sprite;

    public GameObject objectToEnable;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        particles.Stop();
    }

    public void Hit()
    {
        particles.Emit(40);
        sprite.color = new Color(94f/255f, 5f/255f, 5f/255f, 1f);
        AudioManager.Instance().Play(Constants.SOUND_BUTTON);
        if (objectToEnable)
        {
            foreach (Transform child in objectToEnable.transform)
            {
                if (child.tag == Constants.TAG_TRANS)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
    }

    
}
