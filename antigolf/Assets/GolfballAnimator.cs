using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfballAnimator : MonoBehaviour
{

    public float minMagnitude;
    public Sprite spriteMove;
    public Sprite spriteStill;

    private Rigidbody2D rb;
    private ParticleSystem[] particles;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: PUBLIC float for checking the magnitude of velocity, 
        //and if it is above threshhold, animate movement 
        rb = GetComponentInParent<Rigidbody2D>();
        particles = transform.parent.GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = rb.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 9000 * Time.deltaTime);


        if (rb.velocity.magnitude <= minMagnitude)
        {
            particles[0].Stop();
            particles[1].Stop();
        }
        else
        {
            if (!particles[0].isPlaying)
            {
                particles[0].Play();
                particles[1].Play();
            }
        }
    }
}
