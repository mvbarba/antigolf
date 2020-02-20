using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfballAnimator : MonoBehaviour
{

    private Rigidbody2D rb;
     
    // Start is called before the first frame update
    void Start()
    {
       //TODO: PUBLIC float for checking the magnitude of velocity, 
       //and if it is above threshhold, animate movement 
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = rb.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 9000 * Time.deltaTime);

    }
}
